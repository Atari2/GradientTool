// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.Eyedropper
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SFXProductions.GradientTool
{
    internal sealed class Eyedropper : Form
    {
        private const int c_zoom = 9;
        private const int c_reg = 9;
        private const int c_offset = 4;
        private const int INPUT_MOUSE = 0;
        private const uint MOUSEEVENTF_MIDDLEDOWN = 32;
        private const uint MOUSEEVENTF_MIDDLEUP = 64;
        private const int c_sleepTime = 20;
        private const double c_step = 0.2;
        private const int WM_WINDOWPOSCHANGING = 70;
        private const int WM_GETMINMAXINFO = 36;
        private Bitmap m_buffer = new Bitmap(9, 9);
        private System.Windows.Forms.Timer m_timer = new System.Windows.Forms.Timer()
        {
            Interval = 1
        };
        internal static readonly Cursor s_blank = Eyedropper.LoadCursor("SFXProductions.GradientTool.Resources.blank.cur");
        private static readonly Cursor s_crosshair = Eyedropper.LoadCursor("SFXProductions.GradientTool.Resources.InvertedCrosshair.cur");
        private Color m_selectedColour;
        private static readonly Size s_minSize = new Size(5, 5);

        private static Cursor LoadCursor(string name)
        {
            using (Stream manifestResourceStream = typeof(Eyedropper).Assembly.GetManifestResourceStream(name))
                return new Cursor(manifestResourceStream);
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, Eyedropper.INPUT[] pInputs, int cbSize);

        private static void MiddleClick()
        {
            unsafe
            {
                int num = (int)Eyedropper.SendInput(2U, new Eyedropper.INPUT[2]
                {
        new Eyedropper.INPUT()
        {
          type = 0,
          mi = new Eyedropper.MOUSEINPUT() { dwFlags = 32U }
        },
        new Eyedropper.INPUT()
        {
          type = 0,
          mi = new Eyedropper.MOUSEINPUT() { dwFlags = 64U }
        }
                }, sizeof(Eyedropper.INPUT));
            }
        }

        private Eyedropper(string text)
        {
            this.DoubleBuffered = true;
            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ClientSize = new Size(81, 81);
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Capture = true;
            this.Opacity = 0.0;
            this.Text = text;
            this.m_timer.Tick += (EventHandler)((s, e2) =>
            {
                this.CenterOnMouse();
                if (this.Focused)
                    return;
                Eyedropper.MiddleClick();
            });
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (this.m_buffer != null)
                        this.m_buffer.Dispose();
                    if (this.m_timer != null)
                        this.m_timer.Dispose();
                }
                this.m_buffer = (Bitmap)null;
                this.m_timer = (System.Windows.Forms.Timer)null;
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void CenterOnMouse()
        {
            int num1 = Control.MousePosition.X - this.ClientSize.Width / 2;
            int num2 = Control.MousePosition.Y - this.ClientSize.Height / 2;
            if (num1 < 0)
                num1 = 0;
            else if (num1 + this.ClientSize.Width >= SystemInformation.PrimaryMonitorSize.Width)
                num1 = SystemInformation.PrimaryMonitorSize.Width - this.ClientSize.Width;
            if (num2 < 0)
                num2 = 0;
            else if (num2 + this.ClientSize.Height >= SystemInformation.PrimaryMonitorSize.Height)
                num2 = SystemInformation.PrimaryMonitorSize.Height - this.ClientSize.Height;
            this.Left = num1;
            this.Top = num2;
            this.UpdateBuffer();
            this.Invalidate();
        }

        private void UpdateBuffer()
        {
            Rectangle rectangle = new Rectangle(Control.MousePosition.X - 4, Control.MousePosition.Y - 4, 9, 9);
            if (rectangle.Left < 0)
                rectangle.X = 0;
            else if (rectangle.Right > SystemInformation.PrimaryMonitorSize.Width)
                rectangle.X = SystemInformation.PrimaryMonitorSize.Width - rectangle.Width;
            if (rectangle.Top < 0)
                rectangle.Y = 0;
            else if (rectangle.Bottom > SystemInformation.PrimaryMonitorSize.Height)
                rectangle.Y = SystemInformation.PrimaryMonitorSize.Height - rectangle.Height;
            using (Graphics graphics = Graphics.FromImage((Image)this.m_buffer))
                graphics.CopyFromScreen(rectangle.Location, Point.Empty, new Size(9, 9), CopyPixelOperation.SourceCopy);
            Point mousePosition = Control.MousePosition;
            mousePosition.Offset(-rectangle.X, -rectangle.Y);
            if (mousePosition.X < 0)
                mousePosition.X = 0;
            else if (mousePosition.X >= 9)
                mousePosition.X = 8;
            if (mousePosition.Y < 0)
                mousePosition.Y = 0;
            else if (mousePosition.Y >= 9)
                mousePosition.Y = 8;
            this.m_selectedColour = this.m_buffer.GetPixel(mousePosition.X, mousePosition.Y);
        }

        protected override void OnShown(EventArgs e)
        {
            for (double num = this.Opacity + 0.2; num <= 0.999; num += 0.2)
            {
                this.CenterOnMouse();
                if ((Control.ModifierKeys & Keys.Control) != Keys.None)
                {
                    if (!object.ReferenceEquals((object)this.Cursor, (object)Eyedropper.s_crosshair))
                        this.Cursor = Eyedropper.s_crosshair;
                    if (num >= 0.3)
                    {
                        this.Opacity = 0.3;
                        goto label_9;
                    }
                }
                this.Opacity = num;
                Application.DoEvents();
                Thread.Sleep(20);
            }
            this.Opacity = 0.999;
        label_9:
            this.m_timer.Start();
            base.OnShown(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (e.Cancel)
                return;
            this.m_timer.Stop();
            for (double num = this.Opacity - 0.2; num >= 0.0; num -= 0.2)
            {
                this.Opacity = num;
                this.Update();
                Thread.Sleep(20);
            }
            this.Opacity = 0.0;
        }

        protected override Cursor DefaultCursor => Eyedropper.s_blank;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.CenterOnMouse();
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.CenterOnMouse();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            bool flag;
            if (flag = (e.Button & MouseButtons.Left) != MouseButtons.None)
                this.CenterOnMouse();
            base.OnMouseClick(e);
            if (!flag)
                return;
            this.DialogResult = DialogResult.OK;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if ((e.Modifiers & Keys.Control) == Keys.None)
                return;
            this.Opacity = 0.3;
            this.Cursor = Eyedropper.s_crosshair;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if ((e.Modifiers & Keys.Control) != Keys.None)
                return;
            this.Cursor = Eyedropper.s_blank;
            this.Opacity = 0.999;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != '\u001B')
                return;
            this.DialogResult = DialogResult.Cancel;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage((Image)this.m_buffer, this.ClientRectangle);
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;
            e.Graphics.InterpolationMode = InterpolationMode.Default;
            IntPtr hdc = e.Graphics.GetHdc();
            try
            {
                Rectangle rect = Rectangle.Inflate(new Rectangle(Control.MousePosition.X, Control.MousePosition.Y, 1, 1), 4, 4);
                if (rect.Left < 0)
                    rect.X = 0;
                else if (rect.Right > SystemInformation.PrimaryMonitorSize.Width)
                    rect.X = SystemInformation.PrimaryMonitorSize.Width - rect.Width;
                if (rect.Top < 0)
                    rect.Y = 0;
                else if (rect.Bottom > SystemInformation.PrimaryMonitorSize.Height)
                    rect.Y = SystemInformation.PrimaryMonitorSize.Height - rect.Height;
                Point mousePosition = Control.MousePosition;
                mousePosition.Offset(-rect.X, -rect.Y);
                if (mousePosition.X < 0)
                    mousePosition.X = 0;
                else if (mousePosition.X >= 9)
                    mousePosition.X = 8;
                if (mousePosition.Y < 0)
                    mousePosition.Y = 0;
                else if (mousePosition.Y >= 9)
                    mousePosition.Y = 8;
                rect = this.ClientRectangle;
                Eyedropper.RECT lprc = (Eyedropper.RECT)rect;
                Eyedropper.InvertRect(hdc, ref lprc);
                lprc = (Eyedropper.RECT)(rect = Rectangle.Inflate(rect, -1, -1));
                Eyedropper.InvertRect(hdc, ref lprc);
                rect = new Rectangle(mousePosition.X * 9 + 1, mousePosition.Y * 9 + 1, 7, 7);
                lprc = (Eyedropper.RECT)rect;
                Eyedropper.InvertRect(hdc, ref lprc);
                rect.Inflate(-1, -1);
                lprc = (Eyedropper.RECT)rect;
                Eyedropper.InvertRect(hdc, ref lprc);
            }
            finally
            {
                e.Graphics.ReleaseHdc(hdc);
            }
            base.OnPaint(e);
        }

        protected override Size DefaultMinimumSize => Eyedropper.s_minSize;

        protected override unsafe void WndProc(ref Message m)
        {
            if (m.Msg == 70)
            {
                Eyedropper.WindowPos windowPos = *(Eyedropper.WindowPos*)(void*)m.LParam;
            }
            base.WndProc(ref m);
            if (m.Msg != 36)
                return;
            Eyedropper.MinMaxInfo* lparam = (Eyedropper.MinMaxInfo*)(void*)m.LParam;
            lparam->ptMinTrackSize.x = this.MinimumSize.Width;
            lparam->ptMinTrackSize.y = this.MinimumSize.Height;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool InvertRect(IntPtr hDC, ref Eyedropper.RECT lprc);

        public static void PickAColour(Form owner, Action<Color> acceptCallback)
        {
            for (double num = 1.0; num >= 0.0; num -= 0.2)
            {
                Thread.Sleep(20);
                owner.Opacity = num;
                owner.Update();
                if (owner.Owner != null)
                {
                    owner.Owner.Opacity = num;
                    owner.Owner.Update();
                }
            }
            owner.Opacity = 0.0;
            if (owner.Owner != null)
                owner.Owner.Opacity = 0.0;
            Eyedropper eyedropper = new Eyedropper("GradientTool Eyedropper");
            if (eyedropper.ShowDialog((IWin32Window)owner) != DialogResult.Cancel)
                acceptCallback(eyedropper.m_selectedColour);
            try
            {
                for (double num = 0.0; num <= 1.0; num += 0.2)
                {
                    owner.Opacity = num;
                    if (owner.Owner != null)
                        owner.Owner.Opacity = num;
                    Application.DoEvents();
                    Thread.Sleep(20);
                }
                owner.Opacity = 1.0;
                if (owner.Owner != null)
                {
                    owner.Owner.Opacity = 1.0;
                    owner.Owner.Refresh();
                }
                if (owner.Focused)
                    return;
                owner.Activate();
            }
            catch (ObjectDisposedException)
            {
            }
        }

        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct INPUT
        {
            [FieldOffset(0)]
            public int type;
            [FieldOffset(4)]
            public Eyedropper.MOUSEINPUT mi;
        }

        private struct WindowPos
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int width;
            public int height;
            public uint flags;
        }

        private struct POINT
        {
            public int x;
            public int y;
        }

        private struct MinMaxInfo
        {
            public Eyedropper.POINT ptReserved;
            public Eyedropper.POINT ptMaxSize;
            public Eyedropper.POINT ptMaxPosition;
            public Eyedropper.POINT ptMinTrackSize;
            public Eyedropper.POINT ptMaxTrackSize;
        }

        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public static implicit operator Eyedropper.RECT(Rectangle rectangle) => new Eyedropper.RECT()
            {
                left = rectangle.Left,
                top = rectangle.Top,
                right = rectangle.Right,
                bottom = rectangle.Bottom
            };

            public static implicit operator Rectangle(Eyedropper.RECT rect) => Rectangle.FromLTRB(rect.left, rect.top, rect.right, rect.bottom);
        }
    }
}
