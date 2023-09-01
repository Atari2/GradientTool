// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HDMA.Configuration.UnconfigurablePropertyTab
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System.Windows.Forms;

namespace SFXProductions.GradientTool.HDMA.Configuration
{
    internal sealed class UnconfigurablePropertyTab : TabPage
    {
        private Label m_label;

        public UnconfigurablePropertyTab()
        {
            Label label = new Label();
            label.AutoEllipsis = true;
            label.AutoSize = false;
            label.Dock = DockStyle.Fill;
            label.Text = "This HDMA gradient cannot be configured.";
            this.m_label = label;
            this.Padding = new Padding(3);
            this.Controls.Add((Control)this.m_label);
            this.UseVisualStyleBackColor = true;
        }

        public string Message
        {
            get => this.m_label.Text;
            set => this.m_label.Text = value;
        }
    }
}
