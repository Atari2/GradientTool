// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.DoubleBufferedPanel
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System.Windows.Forms;

namespace SFXProductions.GradientTool
{
    internal sealed class DoubleBufferedPanel : Control
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.ResetTransform();
            ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.SunkenOuter);
        }
    }
}
