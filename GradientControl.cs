// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.GradientControl
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using SFXProductions.GradientTool.HDMA;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace SFXProductions.GradientTool
{
    internal sealed class GradientControl : Control
    {
        private int m_sizeOfGradient = 224;
        private Gradient m_gradient;
        private Bitmap m_realGradient;
        private Bitmap m_emuGradient;
        private Bitmap m_briGradient;
        private double[] m_rPrebuffer;
        private double[] m_gPrebuffer;
        private double[] m_bPrebuffer;
        private bool m_enableGrid = true;
        private static readonly Size s_minSize = new Size(10, 0);
        private ulong m_movingId;
        private Settings2 m_settings = Settings2.CreateMode2Mode0(GradientChannels.RedGreenBlue, "Gradient1");

        public GradientControl()
        {
            this.m_gradient = new Gradient();
            this.InitBuffers();
            this.Recalculate();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private static Bitmap CreateB4Bitmap(int height, int width = 1)
        {
            Bitmap b4Bitmap = new Bitmap(width, height, PixelFormat.Format4bppIndexed);
            ColorPalette palette = b4Bitmap.Palette;
            for (int index = 0; index < 16; ++index)
                palette.Entries[index] = Color.FromArgb(index * 17, index * 17, index * 17);
            b4Bitmap.Palette = palette;
            return b4Bitmap;
        }

        private void InitBuffers(int resize = -1)
        {
            if (resize < 0)
                resize = this.m_sizeOfGradient;
            Bitmap bitmap1 = (Bitmap)null;
            Bitmap bitmap2 = (Bitmap)null;
            Bitmap bitmap3 = (Bitmap)null;
            double[] numArray1;
            double[] numArray2;
            double[] numArray3;
            try
            {
                bitmap1 = new Bitmap(2, resize + 2, PixelFormat.Format24bppRgb);
                bitmap2 = new Bitmap(1, resize, PixelFormat.Format16bppRgb555);
                bitmap3 = GradientControl.CreateB4Bitmap(resize);
                numArray1 = new double[resize];
                numArray2 = new double[resize];
                numArray3 = new double[resize];
            }
            catch (Exception ex)
            {
                bitmap1?.Dispose();
                bitmap2?.Dispose();
                bitmap3?.Dispose();
                if (ex is ArgumentException)
                    throw new InsufficientMemoryException();
                throw;
            }
            if (this.m_realGradient != null)
                this.m_realGradient.Dispose();
            if (this.m_emuGradient != null)
                this.m_emuGradient.Dispose();
            if (this.m_briGradient != null)
                this.m_briGradient.Dispose();
            this.m_realGradient = bitmap1;
            this.m_emuGradient = bitmap2;
            this.m_briGradient = bitmap3;
            this.m_rPrebuffer = numArray1;
            this.m_gPrebuffer = numArray2;
            this.m_bPrebuffer = numArray3;
        }

        protected override Size DefaultMinimumSize => GradientControl.s_minSize;

        public GradientColourspace Colourspace
        {
            get => this.m_gradient.Colourspace;
            set
            {
                if (this.m_gradient.Colourspace == value)
                    return;
                this.m_gradient.Colourspace = value;
                this.Recalculate();
                this.RedrawGradientRegion();
                this.OnGradientChanged(EventArgs.Empty);
            }
        }

        public GradientType Type
        {
            get => this.m_gradient.Type;
            set
            {
                if (this.m_gradient.Type == value)
                    return;
                this.m_gradient.Type = value;
                this.Recalculate();
                this.RedrawGradientRegion();
                this.OnGradientChanged(EventArgs.Empty);
            }
        }

        public GradientChannels Channels
        {
            get => this.m_settings.Channels;
            set
            {
                if (this.m_settings.Channels == value)
                    return;
                this.m_settings.Channels = value;
                this.Recalculate();
                int num1 = (this.ClientSize.Width - 38) / 2;
                int num2 = this.ClientSize.Height - 16;
                this.Invalidate(new Rectangle(this.ClientSize.Width - num1 - 8, 9, num1 - 2, num2 - 2));
                this.OnGradientChanged(EventArgs.Empty);
            }
        }

        public bool ShowGrid
        {
            get => this.m_enableGrid;
            set
            {
                if (this.m_enableGrid == value)
                    return;
                this.m_enableGrid = value;
                this.RedrawGradientRegion();
            }
        }

        public int SizeOfGradient => this.m_sizeOfGradient;

        public void SetSizeOfGradient(int nSize)
        {
            if (nSize < 4 || nSize > (int)short.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(nSize), "Size of gradient must be a number between 4 and 32,767.");
            if (this.m_sizeOfGradient == nSize)
                return;
            this.InitBuffers(nSize);
            this.m_sizeOfGradient = nSize;
            this.Recalculate();
            this.RedrawGradientRegion();
            this.OnGradientChanged(EventArgs.Empty);
        }

        public bool GenerateHDMAInitializationCode
        {
            get => this.m_settings.GenerateInitializationCode;
            set
            {
                if (this.m_settings.GenerateInitializationCode == value)
                    return;
                this.m_settings.GenerateInitializationCode = value;
                this.OnGradientChanged(EventArgs.Empty);
            }
        }

        public void UpdateGradient()
        {
            this.Recalculate();
            this.RedrawGradientRegion();
        }

        private void Recalculate()
        {
            this.m_gradient.Calculate(this.m_sizeOfGradient, this.m_rPrebuffer, this.m_gPrebuffer, this.m_bPrebuffer);
            this.m_realGradient.Fill24BppBitmap(this.m_rPrebuffer, this.m_gPrebuffer, this.m_bPrebuffer);
            this.m_emuGradient.Fill15BppBitmap(this.m_rPrebuffer, this.m_gPrebuffer, this.m_bPrebuffer, this.m_settings.Channels);
            if (this.m_settings.Channels != GradientChannels.Brightness)
                return;
            this.m_briGradient.Fill4BppBitmap(this.m_rPrebuffer, this.m_gPrebuffer, this.m_bPrebuffer);
        }

        private Region GetGradientRedrawRegion()
        {
            int num1 = (this.ClientSize.Width - 38) / 2;
            int num2 = this.ClientSize.Height - 16;
            Region gradientRedrawRegion = new Region(new Rectangle(9, 9, num1 - 2, num2 - 2));
            gradientRedrawRegion.Union(new Rectangle(this.ClientSize.Width - num1 - 8, 9, num1 - 2, num2 - 2));
            return gradientRedrawRegion;
        }

        private void RedrawGradientRegion()
        {
            using (Region gradientRedrawRegion = this.GetGradientRedrawRegion())
                this.Invalidate(gradientRedrawRegion);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int width = (this.ClientSize.Width - 38) / 2;
            int height1 = this.ClientSize.Height - 16;
            int height2 = this.ClientSize.Height - 24;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = InterpolationMode.Bilinear;
            e.Graphics.DrawImage((Image)this.m_realGradient, new Rectangle(9, 9, width - 2, height1 - 2), 0.5f, 1f, 1f, (float)this.m_sizeOfGradient, GraphicsUnit.Pixel);
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(this.m_settings.Channels != GradientChannels.Brightness ? (Image)this.m_emuGradient : (Image)this.m_briGradient, this.ClientSize.Width - width - 8, 9, width - 2, height1 - 2);
            if (this.m_enableGrid && this.Height >= this.m_sizeOfGradient * 6)
            {
                double num1 = (double)height1 / (double)this.m_sizeOfGradient;
                double num2 = (double)Math.Max(e.ClipRectangle.Top - 9, 0);
                double num3 = num2 - num2 % num1 + 9.0;
                int num4 = this.ClientSize.Height - 9;
                using (Pen pen1 = new Pen(Color.Black))
                {
                    using (Pen pen2 = new Pen(Color.White))
                    {
                        pen1.DashStyle = DashStyle.Dot;
                        for (double num5 = num3; num5 <= (double)num4; num5 += num1)
                        {
                            int num6 = (int)num5;
                            e.Graphics.DrawLine(pen2, 9, num6, width + 7, num6);
                            e.Graphics.DrawLine(pen1, 9, num6, width + 7, num6);
                            e.Graphics.DrawLine(pen2, this.ClientSize.Width - width - 8, num6, this.ClientSize.Width - 9, num6);
                            e.Graphics.DrawLine(pen1, this.ClientSize.Width - width - 8, num6, this.ClientSize.Width - 9, num6);
                        }
                    }
                }
            }
            ControlPaint.DrawBorder3D(e.Graphics, 8, 8, width, height1, Border3DStyle.SunkenOuter);
            ControlPaint.DrawBorder3D(e.Graphics, this.ClientSize.Width - width - 9, 8, width, height1, Border3DStyle.SunkenOuter);
            ControlPaint.DrawBorder3D(e.Graphics, this.ClientSize.Width / 2 - 1, 12, 2, height2, Border3DStyle.SunkenOuter);
            Rectangle rectangle = new Rectangle(this.ClientSize.Width / 2 - 8, 0, 16, 8);
            using (SolidBrush solidBrush = new SolidBrush(Color.Black))
            {
                for (int index = 0; index < this.m_gradient.Stops.Count; ++index)
                {
                    solidBrush.Color = this.m_gradient.Stops[index].Colour.ToRGB(GradientColourspace.RGB);
                    rectangle.Y = 8 + (int)(this.m_gradient.Stops[index].Position * (double)height2 + 0.5);
                    e.Graphics.FillRectangle((Brush)solidBrush, rectangle);
                    ControlPaint.DrawBorder3D(e.Graphics, rectangle, Border3DStyle.RaisedInner);
                }
            }
            base.OnPaint(e);
        }

        public event EventHandler GradientChanged;

        private void OnGradientChanged(EventArgs e)
        {
            if (this.GradientChanged == null)
                return;
            this.GradientChanged((object)this, e);
        }

        private static bool IsPointInRect(Rectangle rect, Point point) => point.X >= rect.Left && point.X <= rect.Right && point.Y >= rect.Top && point.Y <= rect.Bottom;

        private Rectangle GetSliderHitArea() => new Rectangle(this.ClientSize.Width / 2 - 8, 8, 16, this.ClientSize.Height - 16);

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && GradientControl.IsPointInRect(this.GetSliderHitArea(), e.Location))
            {
                int num1 = this.ClientSize.Height - 24;
                Rectangle rect = new Rectangle(this.ClientSize.Width / 2 - 8, 0, 16, 8);
                bool flag = false;
                for (int index = 0; index < this.m_gradient.Stops.Count; ++index)
                {
                    GradientStop stop = this.m_gradient.Stops[index];
                    rect.Y = 8 + (int)(stop.Position * (double)num1 + 0.5);
                    if (GradientControl.IsPointInRect(rect, e.Location))
                    {
                        flag = true;
                        if (Utils.EditGradientStop((IWin32Window)this, ref stop))
                        {
                            this.m_gradient.Stops[index] = stop;
                            this.Recalculate();
                            using (Region gradientRedrawRegion = this.GetGradientRedrawRegion())
                            {
                                gradientRedrawRegion.Union(rect);
                                rect.Y = 8 + (int)(stop.Position * (double)num1 + 0.5);
                                gradientRedrawRegion.Union(rect);
                                this.Invalidate(gradientRedrawRegion);
                            }
                            this.OnGradientChanged(EventArgs.Empty);
                            break;
                        }
                        break;
                    }
                }
                if (!flag)
                {
                    double num2 = (double)(e.Y - 12) / (double)num1;
                    if (num2 < 0.0)
                        num2 = 0.0;
                    else if (num2 > 1.0)
                        num2 = 1.0;
                    int index = ((int)(num2 * (double)(this.m_sizeOfGradient - 1) + 0.5)).Clamp(this.m_sizeOfGradient - 1);
                    double num3 = (double)index / (double)(this.m_sizeOfGradient - 1);
                    GradientStop gradientStop = new GradientStop()
                    {
                        Colour = new Vector()
                        {
                            X = this.m_rPrebuffer[index],
                            Y = this.m_gPrebuffer[index],
                            Z = this.m_bPrebuffer[index]
                        },
                        Position = num3
                    };
                    if (Utils.EditGradientStop((IWin32Window)this, ref gradientStop, "Add Gradient Stop"))
                    {
                        this.m_gradient.Stops.Add(new GradientStop(gradientStop.Position, gradientStop.Colour));
                        this.Recalculate();
                        using (Region gradientRedrawRegion = this.GetGradientRedrawRegion())
                        {
                            rect.Y = 8 + (int)(gradientStop.Position * (double)num1 + 0.5);
                            gradientRedrawRegion.Union(rect);
                            this.Invalidate(gradientRedrawRegion);
                        }
                        this.OnGradientChanged(EventArgs.Empty);
                    }
                }
            }
            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (GradientControl.IsPointInRect(this.GetSliderHitArea(), e.Location))
            {
                int num = this.ClientSize.Height - 24;
                Rectangle rect = new Rectangle(this.ClientSize.Width / 2 - 8, 0, 16, 8);
                for (int index = 0; index < this.m_gradient.Stops.Count; ++index)
                {
                    GradientStop stop = this.m_gradient.Stops[index];
                    rect.Y = 8 + (int)(stop.Position * (double)num + 0.5);
                    if (GradientControl.IsPointInRect(rect, e.Location))
                    {
                        if (e.Button == MouseButtons.Right && MessageBox.Show((IWin32Window)this, string.Format("Remove the gradient stop at {0:P1}?", (object)this.m_gradient.Stops[index].Position), "GradientTool", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.m_gradient.Stops.RemoveAt(index);
                            this.Recalculate();
                            using (Region gradientRedrawRegion = this.GetGradientRedrawRegion())
                            {
                                gradientRedrawRegion.Union(rect);
                                this.Invalidate(gradientRedrawRegion);
                            }
                            this.OnGradientChanged(EventArgs.Empty);
                            break;
                        }
                        break;
                    }
                }
            }
            base.OnMouseClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && GradientControl.IsPointInRect(this.GetSliderHitArea(), e.Location))
            {
                int num = this.ClientSize.Height - 24;
                Rectangle rect = new Rectangle(this.ClientSize.Width / 2 - 8, 0, 16, 8);
                for (int index = 0; index < this.m_gradient.Stops.Count; ++index)
                {
                    GradientStop stop = this.m_gradient.Stops[index];
                    rect.Y = 8 + (int)(stop.Position * (double)num + 0.5);
                    if (GradientControl.IsPointInRect(rect, e.Location))
                    {
                        this.m_movingId = stop.Id;
                        break;
                    }
                }
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.m_movingId = 0UL;
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this.m_movingId != 0UL && (e.Button & MouseButtons.Left) != MouseButtons.None)
            {
                int num1 = this.ClientSize.Height - 24;
                int index = this.m_gradient.Stops.IndexOfGradientStop(this.m_movingId);
                GradientStop stop = this.m_gradient.Stops[index];
                Rectangle rect = new Rectangle(this.ClientSize.Width / 2 - 8, 8 + (int)(stop.Position * (double)num1 + 0.5), 16, 8);
                double num2 = (double)(e.Y - 12) / (double)num1;
                if (num2 < 0.0)
                    num2 = 0.0;
                else if (num2 > 1.0)
                    num2 = 1.0;
                stop.Position = num2;
                this.m_gradient.Stops[index] = stop;
                this.Recalculate();
                using (Region gradientRedrawRegion = this.GetGradientRedrawRegion())
                {
                    gradientRedrawRegion.Union(rect);
                    rect.Y = 8 + (int)(num2 * (double)num1 + 0.5);
                    gradientRedrawRegion.Union(rect);
                    this.Invalidate(gradientRedrawRegion);
                }
                this.OnGradientChanged(EventArgs.Empty);
            }
            base.OnMouseMove(e);
        }

        public Settings2 Settings
        {
            get => this.m_settings;
            set
            {
                this.m_settings = value;
                this.Recalculate();
                this.RedrawGradientRegion();
                this.OnGradientChanged(EventArgs.Empty);
            }
        }

        public string GradientName
        {
            get => this.m_settings.Name;
            set
            {
                if (!(this.m_settings.Name != value))
                    return;
                this.m_settings.Name = value;
                this.OnGradientChanged(EventArgs.Empty);
            }
        }

        public void GenerateASM(CodeGen code) => Generator2.GenerateCode(this.m_rPrebuffer, this.m_gPrebuffer, this.m_bPrebuffer, this.m_settings, code);

        public bool SaveGradient(string filename, bool is24Bit)
        {
            bool flag = false;
            ImageFormat format;
            switch (Path.GetExtension(filename).ToLowerInvariant())
            {
                case ".bmp":
                case ".dib":
                    format = ImageFormat.Bmp;
                    break;
                case ".jpeg":
                case ".jpg":
                case ".jpe":
                    flag = true;
                    format = ImageFormat.Jpeg;
                    break;
                case ".gif":
                    flag = true;
                    format = ImageFormat.Gif;
                    break;
                default:
                    format = ImageFormat.Png;
                    break;
            }
            if (flag && MessageBox.Show((IWin32Window)this, "Saving in this format may cause quality loss.\r\nDo you want to continue?", "GradientTool", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                return false;
            if (is24Bit)
            {
                using (Bitmap bmp = new Bitmap(24, this.m_sizeOfGradient, PixelFormat.Format24bppRgb))
                {
                    bmp.Fill24BppBitmap(this.m_rPrebuffer, this.m_gPrebuffer, this.m_bPrebuffer, false);
                    bmp.Save(filename, format);
                }
            }
            else if (this.m_settings.Channels != GradientChannels.Brightness)
            {
                using (Bitmap bmp = new Bitmap(24, this.m_sizeOfGradient, PixelFormat.Format16bppRgb555))
                {
                    bmp.Fill15BppBitmap(this.m_rPrebuffer, this.m_gPrebuffer, this.m_bPrebuffer, this.m_settings.Channels);
                    bmp.Save(filename, format);
                }
            }
            else
            {
                using (Bitmap b4Bitmap = GradientControl.CreateB4Bitmap(this.m_sizeOfGradient, 24))
                {
                    b4Bitmap.Fill4BppBitmap(this.m_rPrebuffer, this.m_gPrebuffer, this.m_bPrebuffer);
                    b4Bitmap.Save(filename, format);
                }
            }
            return true;
        }
    }
}
