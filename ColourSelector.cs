// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.ColourSelector
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using SFXProductions.GradientTool.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SFXProductions.GradientTool
{
    internal class ColourSelector : Form
    {
        private const int c_hueChange = 1;
        private const int c_satChange = 2;
        private const int c_lgtChange = 4;
        private int m_scalar = 100;
        private int m_deg = 360;
        private Bitmap m_hues = Resources.hues;
        private LinearGradientBrush m_lightnessPanelBrush = new LinearGradientBrush(Point.Empty, new Point(0, 1), Color.White, Color.Black);
        private Vector m_hsl;
        private static readonly Point[] s_rightMarker = new Point[5]
        {
      new Point(3, 0),
      new Point(4, 1),
      new Point(9, 2),
      new Point(9, -2),
      new Point(4, -1)
        };
        private static readonly Point[] s_rightLightnessMarker = new Point[5]
        {
      new Point(3, 0),
      new Point(4, 1),
      new Point(9, 3),
      new Point(9, -3),
      new Point(4, -1)
        };
        private bool m_isChanging;
        private IContainer components;
        private Button okButton;
        private Button cancelButton;
        private NumericUpDown hueUpDown;
        private NumericUpDown redUpDown;
        private NumericUpDown satUpDown;
        private NumericUpDown greenUpDown;
        private NumericUpDown lightUpDown;
        private NumericUpDown blueUpDown;
        private NumericUpDown posUpDown;
        private ToolTip toolTip;
        private Button eyedropperButton;
        private DoubleBufferedPanel colourPanel;
        private DoubleBufferedPanel hueSaturationPanel;
        private DoubleBufferedPanel lightnessPanel;
        private TableLayoutPanel tableLayoutPanel5;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;

        public ColourSelector()
        {
            this.InitializeComponent();
            this.m_lightnessPanelBrush.InterpolationColors = new ColorBlend(3)
            {
                Colors = new Color[3]
              {
          Color.White,
          Color.Gray,
          Color.Black
              },
                Positions = new float[3] { 0.0f, 0.5f, 1f }
            };
        }

        private int GetMarkerPosFromHue(double hue) => (int)(1.5 + hue * (double)(this.hueSaturationPanel.ClientSize.Width - 3));

        private int GetMarkerPosFromSat(double saturation) => (int)(1.5 + (1.0 - saturation) * (double)(this.hueSaturationPanel.ClientSize.Height - 3));

        private int HueMarkerPos => this.GetMarkerPosFromHue(this.m_hsl.X);

        private int SatMarkerPos => this.GetMarkerPosFromSat(this.m_hsl.Y);

        private void RefreshHueSatMarkerPos(int oldHuePos, int oldSatPos)
        {
            using (Region region = new Region(new Rectangle(this.HueMarkerPos - 9, this.SatMarkerPos - 9, 19, 19)))
            {
                region.Union(new Rectangle(oldHuePos - 9, oldSatPos - 9, 19, 19));
                this.hueSaturationPanel.Invalidate(region);
            }
        }

        private void PaintHueSaturationPanel(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage((Image)this.m_hues, Rectangle.Inflate(this.hueSaturationPanel.ClientRectangle, -1, -1), new Rectangle(0, 0, 6, 1), GraphicsUnit.Pixel);
            e.Graphics.TranslateTransform((float)this.HueMarkerPos, (float)this.SatMarkerPos);
            e.Graphics.FillPolygon(Brushes.Black, ColourSelector.s_rightMarker);
            e.Graphics.DrawPolygon(Pens.White, ColourSelector.s_rightMarker);
            e.Graphics.RotateTransform(90f);
            e.Graphics.FillPolygon(Brushes.Black, ColourSelector.s_rightMarker);
            e.Graphics.DrawPolygon(Pens.White, ColourSelector.s_rightMarker);
            e.Graphics.RotateTransform(90f);
            e.Graphics.FillPolygon(Brushes.Black, ColourSelector.s_rightMarker);
            e.Graphics.DrawPolygon(Pens.White, ColourSelector.s_rightMarker);
            e.Graphics.RotateTransform(90f);
            e.Graphics.FillPolygon(Brushes.Black, ColourSelector.s_rightMarker);
            e.Graphics.DrawPolygon(Pens.White, ColourSelector.s_rightMarker);
            e.Graphics.ResetTransform();
        }

        private void MoveHueSatMarker(MouseEventArgs e)
        {
            bool isChanging = this.m_isChanging;
            this.m_isChanging = true;
            double d = (double)(e.X - 1) / ((double)this.hueSaturationPanel.ClientSize.Width - 3.0);
            double num = 1.0 - ((double)(e.Y - 1) / ((double)this.hueSaturationPanel.ClientSize.Height - 3.0)).Clamp();
            if (d < 0.0 || d > 1.0)
                d -= Math.Floor(d);
            int hueMarkerPos = this.HueMarkerPos;
            int satMarkerPos = this.SatMarkerPos;
            this.m_hsl.X = d;
            this.m_hsl.Y = num;
            this.RefreshHueSatMarkerPos(hueMarkerPos, satMarkerPos);
            this.lightnessPanel.Invalidate();
            Vector hdr = this.m_hsl.ToHDR(GradientColourspace.HSL);
            this.hueUpDown.Value = (Decimal)(this.m_hsl.X * (double)this.m_deg);
            this.satUpDown.Value = ((Decimal)(this.m_hsl.Y * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.redUpDown.Value = ((Decimal)(hdr.X.Clamp() * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.greenUpDown.Value = ((Decimal)(hdr.Y.Clamp() * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.blueUpDown.Value = ((Decimal)(hdr.Z.Clamp() * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.UpdateColourPreview();
            this.m_isChanging = isChanging;
        }

        private void HueSatPanelMouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.None)
                return;
            this.hueSaturationPanel.Capture = true;
            this.hueSaturationPanel.Cursor = Eyedropper.s_blank;
            Cursor.Clip = this.hueSaturationPanel.RectangleToScreen(Rectangle.Inflate(this.hueSaturationPanel.ClientRectangle, -1, -1));
            this.MoveHueSatMarker(e);
        }

        private void HueSatPanelMouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.None)
                return;
            this.MoveHueSatMarker(e);
        }

        private void HueSatPanelMouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.None)
                return;
            Cursor.Clip = Rectangle.Empty;
            this.hueSaturationPanel.Cursor = Cursors.Cross;
            this.hueSaturationPanel.Capture = false;
        }

        private int GetMarkerPosFromLightness(double lightness) => (int)(1.5 + (1.0 - lightness) * (double)(this.lightnessPanel.ClientSize.Height - 3));

        private int LightnessMarkerPos => this.GetMarkerPosFromLightness(this.m_hsl.Z);

        private void RefreshLightnessMarker(int oldPos)
        {
            using (Region region = new Region(new Rectangle(1, this.LightnessMarkerPos - 3, this.lightnessPanel.ClientSize.Width - 2, 7)))
            {
                region.Union(new Rectangle(1, oldPos - 3, this.lightnessPanel.ClientSize.Width - 2, 7));
                this.lightnessPanel.Invalidate(region);
            }
        }

        private void PaintLightnessPanel(object sender, PaintEventArgs e)
        {
            Vector hsl = this.m_hsl with { Z = 0.5 };
            ColorBlend interpolationColors = this.m_lightnessPanelBrush.InterpolationColors;
            interpolationColors.Colors[1] = hsl.ToRGB(GradientColourspace.HSL);
            this.m_lightnessPanelBrush.InterpolationColors = interpolationColors;
            e.Graphics.TranslateTransform(1f, 1f);
            e.Graphics.ScaleTransform((float)(this.lightnessPanel.ClientSize.Width - 2), (float)(this.lightnessPanel.ClientSize.Height - 2));
            e.Graphics.FillRectangle((Brush)this.m_lightnessPanelBrush, new Rectangle(0, 0, 1, 1));
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform((float)(this.lightnessPanel.ClientSize.Width / 2), (float)this.LightnessMarkerPos);
            e.Graphics.FillPolygon(Brushes.Black, ColourSelector.s_rightLightnessMarker);
            e.Graphics.DrawPolygon(Pens.White, ColourSelector.s_rightLightnessMarker);
            e.Graphics.ScaleTransform(-1f, 1f);
            e.Graphics.FillPolygon(Brushes.Black, ColourSelector.s_rightLightnessMarker);
            e.Graphics.DrawPolygon(Pens.White, ColourSelector.s_rightLightnessMarker);
            e.Graphics.ResetTransform();
        }

        private void MoveLightnessMarker(MouseEventArgs e)
        {
            bool isChanging = this.m_isChanging;
            this.m_isChanging = true;
            double num = 1.0 - ((double)(e.Y - 1) / ((double)this.hueSaturationPanel.ClientSize.Height - 3.0)).Clamp();
            int lightnessMarkerPos = this.LightnessMarkerPos;
            this.m_hsl.Z = num;
            this.RefreshLightnessMarker(lightnessMarkerPos);
            Vector hdr = this.m_hsl.ToHDR(GradientColourspace.HSL);
            this.lightUpDown.Value = ((Decimal)(this.m_hsl.Z * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.redUpDown.Value = ((Decimal)(hdr.X * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.greenUpDown.Value = ((Decimal)(hdr.Y * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.blueUpDown.Value = ((Decimal)(hdr.Z * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.UpdateColourPreview();
            this.m_isChanging = isChanging;
        }

        private void LghtPanelMouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.None)
                return;
            this.lightnessPanel.Capture = true;
            this.lightnessPanel.Cursor = Eyedropper.s_blank;
            Cursor.Clip = this.lightnessPanel.RectangleToScreen(new Rectangle(this.lightnessPanel.ClientSize.Width / 2, 1, 1, this.lightnessPanel.ClientSize.Height - 2));
            this.MoveLightnessMarker(e);
        }

        private void LghtPanelMouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.None)
                return;
            this.MoveLightnessMarker(e);
        }

        private void LghtPanelMouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.None)
                return;
            Cursor.Clip = Rectangle.Empty;
            this.lightnessPanel.Cursor = Cursors.Cross;
            this.lightnessPanel.Capture = false;
        }

        private void UpdateColourPreview() => this.colourPanel.BackColor = this.m_hsl.ToRGB(GradientColourspace.HSL);

        private void DoRGBChange()
        {
            if (this.m_isChanging)
                return;
            this.m_isChanging = true;
            int hueMarkerPos = this.HueMarkerPos;
            int satMarkerPos = this.SatMarkerPos;
            Vector vector = new Vector()
            {
                X = (double)(this.redUpDown.Value / (Decimal)this.m_scalar),
                Y = (double)(this.greenUpDown.Value / (Decimal)this.m_scalar),
                Z = (double)(this.blueUpDown.Value / (Decimal)this.m_scalar)
            };
            double x = this.m_hsl.X;
            double y = this.m_hsl.Y;
            this.m_hsl = vector.HDRToColourspace(GradientColourspace.HSL);
            if (double.IsNaN(this.m_hsl.X))
                this.m_hsl.X = x;
            if (double.IsNaN(this.m_hsl.Y))
                this.m_hsl.Y = y;
            this.hueUpDown.Value = (Decimal)(this.m_hsl.X * (double)this.m_deg);
            this.satUpDown.Value = ((Decimal)(this.m_hsl.Y * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.lightUpDown.Value = ((Decimal)(this.m_hsl.Z * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.RefreshHueSatMarkerPos(hueMarkerPos, satMarkerPos);
            this.lightnessPanel.Invalidate();
            this.UpdateColourPreview();
            this.m_isChanging = false;
        }

        private void DoHSLChange(object sender, bool all = false)
        {
            if (this.m_isChanging)
                return;
            this.m_isChanging = true;
            int num1 = 0;
            Decimal d = this.hueUpDown.Value / (Decimal)this.m_deg;
            int hueMarkerPos = this.HueMarkerPos;
            int num2 = this.SatMarkerPos;
            if (all || object.ReferenceEquals(sender, (object)this.hueUpDown))
            {
                num1 = 1;
                if (d < 0M || d > 1M)
                {
                    d -= Math.Floor(d);
                    this.hueUpDown.Value = d * (Decimal)this.m_deg;
                }
            }
            if (all || object.ReferenceEquals(sender, (object)this.satUpDown))
            {
                num1 = 2;
                this.satUpDown.Value = this.satUpDown.Value.Clamp((Decimal)this.m_scalar);
            }
            if (all || object.ReferenceEquals(sender, (object)this.lightUpDown))
            {
                num1 = 4;
                this.lightUpDown.Value = this.lightUpDown.Value.Clamp((Decimal)this.m_scalar);
                num2 = this.LightnessMarkerPos;
            }
            this.m_hsl = new Vector()
            {
                X = (double)d,
                Y = ((double)(this.satUpDown.Value / (Decimal)this.m_scalar)).Clamp(),
                Z = ((double)(this.lightUpDown.Value / (Decimal)this.m_scalar)).Clamp()
            };
            switch (num1)
            {
                case 1:
                case 2:
                    this.RefreshHueSatMarkerPos(hueMarkerPos, num2);
                    this.lightnessPanel.Invalidate();
                    break;
                case 4:
                    this.RefreshLightnessMarker(num2);
                    break;
            }
            Vector hdr = this.m_hsl.ToHDR(GradientColourspace.HSL);
            this.redUpDown.Value = ((Decimal)(hdr.X * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.greenUpDown.Value = ((Decimal)(hdr.Y * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.blueUpDown.Value = ((Decimal)(hdr.Z * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.UpdateColourPreview();
            this.m_isChanging = false;
        }

        private void posUpDown_ValueChanged(object sender, EventArgs e)
        {
        }

        private void RGBUpDownsChanged(object sender, EventArgs e) => this.DoRGBChange();

        private void HSLUpDownsChanged(object sender, EventArgs e) => this.DoHSLChange(sender);

        public void SetColour(Vector hdr)
        {
            this.m_isChanging = true;
            this.redUpDown.Value = ((Decimal)(hdr.X * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.greenUpDown.Value = ((Decimal)(hdr.Y * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.blueUpDown.Value = ((Decimal)(hdr.Z * (double)this.m_scalar)).Clamp((Decimal)this.m_scalar);
            this.m_isChanging = false;
            this.DoRGBChange();
        }

        public Vector GetColour() => this.m_hsl.ToHDR(GradientColourspace.HSL);

        public void SetOffset(double offset) => this.posUpDown.Value = ((Decimal)(offset * 100.0)).Clamp();

        public double GetOffset() => (double)(this.posUpDown.Value / 100M);

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (e.Cancel)
                return;
            Cursor.Clip = Rectangle.Empty;
        }

        private void EyedropperClicked(object sender, EventArgs e) => Eyedropper.PickAColour((Form)this, (Action<Color>)(c => this.SetColour(c.ToColourspace(GradientColourspace.RGB))));

        private void SetScalar(int scalar, int deg)
        {
            if (this.m_scalar == scalar && this.m_deg == deg)
                return;
            bool isChanging = this.m_isChanging;
            this.m_isChanging = true;
            this.m_scalar = scalar;
            this.m_deg = deg;
            this.satUpDown.Maximum = (Decimal)scalar;
            this.lightUpDown.Maximum = (Decimal)scalar;
            this.redUpDown.Maximum = (Decimal)scalar;
            this.greenUpDown.Maximum = (Decimal)scalar;
            this.blueUpDown.Maximum = (Decimal)scalar;
            Vector hdr = this.m_hsl.ToHDR(GradientColourspace.HSL);
            this.hueUpDown.Value = (Decimal)(this.m_hsl.X * (double)deg);
            this.satUpDown.Value = ((Decimal)(this.m_hsl.Y * (double)scalar)).Clamp((Decimal)scalar);
            this.lightUpDown.Value = ((Decimal)(this.m_hsl.Z * (double)scalar)).Clamp((Decimal)scalar);
            this.redUpDown.Value = ((Decimal)(hdr.X * (double)scalar)).Clamp((Decimal)scalar);
            this.greenUpDown.Value = ((Decimal)(hdr.Y * (double)scalar)).Clamp((Decimal)scalar);
            this.blueUpDown.Value = ((Decimal)(hdr.Z * (double)scalar)).Clamp((Decimal)scalar);
            this.m_isChanging = isChanging;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) => this.SetScalar(100, 360);

        private void radioButton2_CheckedChanged(object sender, EventArgs e) => this.SetScalar((int)byte.MaxValue, (int)byte.MaxValue);

        private void radioButton3_CheckedChanged(object sender, EventArgs e) => this.SetScalar(240, 240);

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new System.ComponentModel.Container();
            this.redUpDown = new NumericUpDown();
            this.greenUpDown = new NumericUpDown();
            this.blueUpDown = new NumericUpDown();
            this.lightUpDown = new NumericUpDown();
            this.satUpDown = new NumericUpDown();
            this.hueUpDown = new NumericUpDown();
            this.okButton = new Button();
            this.cancelButton = new Button();
            this.posUpDown = new NumericUpDown();
            this.colourPanel = new DoubleBufferedPanel();
            this.eyedropperButton = new Button();
            this.hueSaturationPanel = new DoubleBufferedPanel();
            this.lightnessPanel = new DoubleBufferedPanel();
            this.tableLayoutPanel5 = new TableLayoutPanel();
            this.radioButton1 = new RadioButton();
            this.radioButton2 = new RadioButton();
            this.radioButton3 = new RadioButton();
            this.toolTip = new ToolTip(this.components);
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            Label label4 = new Label();
            Label label5 = new Label();
            Label label6 = new Label();
            TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
            TableLayoutPanel tableLayoutPanel3 = new TableLayoutPanel();
            Label label7 = new Label();
            Label label8 = new Label();
            TableLayoutPanel tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            this.redUpDown.BeginInit();
            this.greenUpDown.BeginInit();
            this.blueUpDown.BeginInit();
            this.lightUpDown.BeginInit();
            this.satUpDown.BeginInit();
            this.hueUpDown.BeginInit();
            tableLayoutPanel2.SuspendLayout();
            this.posUpDown.BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add((Control)label1, 1, 5);
            tableLayoutPanel1.Controls.Add((Control)label2, 1, 4);
            tableLayoutPanel1.Controls.Add((Control)label3, 1, 3);
            tableLayoutPanel1.Controls.Add((Control)label4, 3, 3);
            tableLayoutPanel1.Controls.Add((Control)this.redUpDown, 4, 3);
            tableLayoutPanel1.Controls.Add((Control)label5, 3, 4);
            tableLayoutPanel1.Controls.Add((Control)this.greenUpDown, 4, 4);
            tableLayoutPanel1.Controls.Add((Control)label6, 3, 5);
            tableLayoutPanel1.Controls.Add((Control)this.blueUpDown, 4, 5);
            tableLayoutPanel1.Controls.Add((Control)this.lightUpDown, 2, 5);
            tableLayoutPanel1.Controls.Add((Control)this.satUpDown, 2, 4);
            tableLayoutPanel1.Controls.Add((Control)this.hueUpDown, 2, 3);
            tableLayoutPanel1.Controls.Add((Control)tableLayoutPanel2, 0, 7);
            tableLayoutPanel1.Controls.Add((Control)this.posUpDown, 3, 6);
            tableLayoutPanel1.Controls.Add((Control)tableLayoutPanel3, 0, 3);
            tableLayoutPanel1.Controls.Add((Control)label8, 2, 6);
            tableLayoutPanel1.Controls.Add((Control)this.eyedropperButton, 1, 6);
            tableLayoutPanel1.Controls.Add((Control)tableLayoutPanel4, 0, 0);
            tableLayoutPanel1.Controls.Add((Control)this.tableLayoutPanel5, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(9, 9);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(282, 365);
            tableLayoutPanel1.TabIndex = 0;
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(78, 279);
            label1.Margin = new Padding(3, 2, 3, 2);
            label1.Name = "label5";
            label1.Size = new Size(13, 13);
            label1.TabIndex = 6;
            label1.Text = "&L";
            this.toolTip.SetToolTip((Control)label1, "Lightness");
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(77, 253);
            label2.Margin = new Padding(3, 2, 3, 2);
            label2.Name = "label3";
            label2.Size = new Size(14, 13);
            label2.TabIndex = 4;
            label2.Text = "&S";
            this.toolTip.SetToolTip((Control)label2, "Saturation");
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(76, 227);
            label3.Margin = new Padding(3, 2, 3, 2);
            label3.Name = "label1";
            label3.Size = new Size(15, 13);
            label3.TabIndex = 2;
            label3.Text = "&H";
            this.toolTip.SetToolTip((Control)label3, "Hue");
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(183, 227);
            label4.Margin = new Padding(8, 2, 3, 2);
            label4.Name = "label2";
            label4.Size = new Size(15, 13);
            label4.TabIndex = 8;
            label4.Text = "&R";
            this.toolTip.SetToolTip((Control)label4, "Red");
            this.redUpDown.DecimalPlaces = 3;
            this.redUpDown.Location = new Point(204, 224);
            this.redUpDown.Name = "redUpDown";
            this.redUpDown.Size = new Size(75, 20);
            this.redUpDown.TabIndex = 9;
            this.toolTip.SetToolTip((Control)this.redUpDown, "Red");
            this.redUpDown.ValueChanged += new EventHandler(this.RGBUpDownsChanged);
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(183, 253);
            label5.Margin = new Padding(8, 2, 3, 2);
            label5.Name = "label4";
            label5.Size = new Size(15, 13);
            label5.TabIndex = 10;
            label5.Text = "&G";
            this.toolTip.SetToolTip((Control)label5, "Green");
            this.greenUpDown.DecimalPlaces = 3;
            this.greenUpDown.Location = new Point(204, 250);
            this.greenUpDown.Name = "greenUpDown";
            this.greenUpDown.Size = new Size(75, 20);
            this.greenUpDown.TabIndex = 11;
            this.toolTip.SetToolTip((Control)this.greenUpDown, "Green");
            this.greenUpDown.ValueChanged += new EventHandler(this.RGBUpDownsChanged);
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(183, 279);
            label6.Margin = new Padding(8, 2, 3, 2);
            label6.Name = "label6";
            label6.Size = new Size(14, 13);
            label6.TabIndex = 12;
            label6.Text = "&B";
            this.toolTip.SetToolTip((Control)label6, "Blue");
            this.blueUpDown.DecimalPlaces = 3;
            this.blueUpDown.Location = new Point(204, 276);
            this.blueUpDown.Name = "blueUpDown";
            this.blueUpDown.Size = new Size(75, 20);
            this.blueUpDown.TabIndex = 13;
            this.toolTip.SetToolTip((Control)this.blueUpDown, "Blue");
            this.blueUpDown.ValueChanged += new EventHandler(this.RGBUpDownsChanged);
            this.lightUpDown.DecimalPlaces = 3;
            this.lightUpDown.Location = new Point(97, 276);
            this.lightUpDown.Name = "lightUpDown";
            this.lightUpDown.Size = new Size(75, 20);
            this.lightUpDown.TabIndex = 7;
            this.toolTip.SetToolTip((Control)this.lightUpDown, "Lightness");
            this.lightUpDown.ValueChanged += new EventHandler(this.HSLUpDownsChanged);
            this.satUpDown.DecimalPlaces = 3;
            this.satUpDown.Location = new Point(97, 250);
            this.satUpDown.Name = "satUpDown";
            this.satUpDown.Size = new Size(75, 20);
            this.satUpDown.TabIndex = 5;
            this.toolTip.SetToolTip((Control)this.satUpDown, "Saturation");
            this.satUpDown.ValueChanged += new EventHandler(this.HSLUpDownsChanged);
            this.hueUpDown.DecimalPlaces = 3;
            this.hueUpDown.Location = new Point(97, 224);
            this.hueUpDown.Maximum = new Decimal(new int[4]
            {
        -1,
        -1,
        -1,
        0
            });
            this.hueUpDown.Minimum = new Decimal(new int[4]
            {
        -1,
        -1,
        -1,
        int.MinValue
            });
            this.hueUpDown.Name = "hueUpDown";
            this.hueUpDown.Size = new Size(75, 20);
            this.hueUpDown.TabIndex = 3;
            this.toolTip.SetToolTip((Control)this.hueUpDown, "Hue");
            this.hueUpDown.ValueChanged += new EventHandler(this.HSLUpDownsChanged);
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel1.SetColumnSpan((Control)tableLayoutPanel2, 5);
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
            tableLayoutPanel2.Controls.Add((Control)this.okButton, 0, 0);
            tableLayoutPanel2.Controls.Add((Control)this.cancelButton, 1, 0);
            tableLayoutPanel2.Location = new Point(120, 336);
            tableLayoutPanel2.Margin = new Padding(0, 6, 0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            tableLayoutPanel2.Size = new Size(162, 29);
            tableLayoutPanel2.TabIndex = 17;
            this.okButton.DialogResult = DialogResult.OK;
            this.okButton.Location = new Point(3, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.cancelButton.DialogResult = DialogResult.Cancel;
            this.cancelButton.Location = new Point(84, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.posUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan((Control)this.posUpDown, 2);
            this.posUpDown.DecimalPlaces = 6;
            this.posUpDown.Location = new Point(183, 307);
            this.posUpDown.Margin = new Padding(8, 8, 3, 3);
            this.posUpDown.Name = "posUpDown";
            this.posUpDown.Size = new Size(96, 20);
            this.posUpDown.TabIndex = 16;
            this.toolTip.SetToolTip((Control)this.posUpDown, "Position of gradient stop");
            this.posUpDown.ValueChanged += new EventHandler(this.posUpDown_ValueChanged);
            tableLayoutPanel3.Anchor = AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            tableLayoutPanel3.Controls.Add((Control)label7, 0, 1);
            tableLayoutPanel3.Controls.Add((Control)this.colourPanel, 0, 0);
            tableLayoutPanel3.Location = new Point(0, 221);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel1.SetRowSpan((Control)tableLayoutPanel3, 3);
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            tableLayoutPanel3.Size = new Size(66, 78);
            tableLayoutPanel3.TabIndex = 1;
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Location = new Point(14, 63);
            label7.Margin = new Padding(3, 2, 3, 2);
            label7.Name = "label8";
            label7.Size = new Size(37, 13);
            label7.TabIndex = 1;
            label7.Text = "Colour";
            this.toolTip.SetToolTip((Control)label7, "Gradient stop colour");
            this.colourPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.colourPanel.BackColor = Color.Black;
            this.colourPanel.Location = new Point(8, 8);
            this.colourPanel.Margin = new Padding(8);
            this.colourPanel.Name = "colourPanel";
            this.colourPanel.Size = new Size(50, 45);
            this.colourPanel.TabIndex = 0;
            this.toolTip.SetToolTip((Control)this.colourPanel, "Gradient stop colour");
            label8.Anchor = AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(125, 310);
            label8.Margin = new Padding(3, 6, 3, 2);
            label8.Name = "label7";
            label8.Size = new Size(47, 13);
            label8.TabIndex = 15;
            label8.Text = "&Position:";
            this.toolTip.SetToolTip((Control)label8, "Position of gradient stop");
            this.eyedropperButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.eyedropperButton.Image = (Image)Resources.pipette;
            this.eyedropperButton.Location = new Point(69, 305);
            this.eyedropperButton.Name = "eyedropperButton";
            this.eyedropperButton.Size = new Size(22, 22);
            this.eyedropperButton.TabIndex = 14;
            this.toolTip.SetToolTip((Control)this.eyedropperButton, "Pick Colour from Screen");
            this.eyedropperButton.UseVisualStyleBackColor = true;
            this.eyedropperButton.Click += new EventHandler(this.EyedropperClicked);
            tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel1.SetColumnSpan((Control)tableLayoutPanel4, 5);
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32f));
            tableLayoutPanel4.Controls.Add((Control)this.hueSaturationPanel, 0, 0);
            tableLayoutPanel4.Controls.Add((Control)this.lightnessPanel, 1, 0);
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            tableLayoutPanel4.Size = new Size(282, 198);
            tableLayoutPanel4.TabIndex = 0;
            this.hueSaturationPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.hueSaturationPanel.BackColor = Color.Gray;
            this.hueSaturationPanel.Cursor = Cursors.Cross;
            this.hueSaturationPanel.Location = new Point(3, 3);
            this.hueSaturationPanel.Margin = new Padding(3, 3, 6, 3);
            this.hueSaturationPanel.Name = "hueSaturationPanel";
            this.hueSaturationPanel.Size = new Size(241, 192);
            this.hueSaturationPanel.TabIndex = 0;
            this.hueSaturationPanel.Paint += new PaintEventHandler(this.PaintHueSaturationPanel);
            this.hueSaturationPanel.MouseDown += new MouseEventHandler(this.HueSatPanelMouseDown);
            this.hueSaturationPanel.MouseMove += new MouseEventHandler(this.HueSatPanelMouseMove);
            this.hueSaturationPanel.MouseUp += new MouseEventHandler(this.HueSatPanelMouseUp);
            this.lightnessPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.lightnessPanel.Cursor = Cursors.Cross;
            this.lightnessPanel.Location = new Point(256, 3);
            this.lightnessPanel.Margin = new Padding(6, 3, 3, 3);
            this.lightnessPanel.Name = "lightnessPanel";
            this.lightnessPanel.Size = new Size(23, 192);
            this.lightnessPanel.TabIndex = 1;
            this.lightnessPanel.Paint += new PaintEventHandler(this.PaintLightnessPanel);
            this.lightnessPanel.MouseDown += new MouseEventHandler(this.LghtPanelMouseDown);
            this.lightnessPanel.MouseMove += new MouseEventHandler(this.LghtPanelMouseMove);
            this.lightnessPanel.MouseUp += new MouseEventHandler(this.LghtPanelMouseUp);
            this.tableLayoutPanel5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel1.SetColumnSpan((Control)this.tableLayoutPanel5, 5);
            this.tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
            this.tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334f));
            this.tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334f));
            this.tableLayoutPanel5.Controls.Add((Control)this.radioButton1, 0, 0);
            this.tableLayoutPanel5.Controls.Add((Control)this.radioButton2, 2, 0);
            this.tableLayoutPanel5.Controls.Add((Control)this.radioButton3, 1, 0);
            this.tableLayoutPanel5.Location = new Point(0, 198);
            this.tableLayoutPanel5.Margin = new Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel5.Size = new Size(282, 23);
            this.tableLayoutPanel5.TabIndex = 18;
            this.radioButton1.Anchor = AnchorStyles.None;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new Point(25, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(43, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "°, %";
            this.toolTip.SetToolTip((Control)this.radioButton1, "H will be degrees; RGB, S, and L values will be a percentage.");
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
            this.radioButton2.Anchor = AnchorStyles.None;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new Point(204, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(61, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "0 .. 255";
            this.toolTip.SetToolTip((Control)this.radioButton2, "HSL and RGB values will be in the range of 0 to 255.");
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
            this.radioButton3.Anchor = AnchorStyles.None;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new Point(109, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new Size(61, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "0 .. 240";
            this.toolTip.SetToolTip((Control)this.radioButton3, "HSL and RGB values will be in the range of 0 to 240.");
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new EventHandler(this.radioButton3_CheckedChanged);
            this.AcceptButton = (IButtonControl)this.okButton;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = (IButtonControl)this.cancelButton;
            this.ClientSize = new Size(300, 383);
            this.Controls.Add((Control)tableLayoutPanel1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(ColourSelector);
            this.Padding = new Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Edit Gradient Stop";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            this.redUpDown.EndInit();
            this.greenUpDown.EndInit();
            this.blueUpDown.EndInit();
            this.lightUpDown.EndInit();
            this.satUpDown.EndInit();
            this.hueUpDown.EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            this.posUpDown.EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
