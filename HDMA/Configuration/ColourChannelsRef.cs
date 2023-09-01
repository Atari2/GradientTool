// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HDMA.Configuration.ColourChannelsRef
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System.Windows.Forms;

namespace SFXProductions.GradientTool.HDMA.Configuration
{
    internal sealed class ColourChannelsRef
    {
        private ChannelType m_channel;
        private Label m_label;
        private TabPage m_tabPage;

        public ChannelType Value
        {
            get => this.m_channel;
            set
            {
                if (value == this.m_channel)
                    return;
                this.m_channel = value;
                if (this.m_label != null)
                    this.m_label.Text = this.m_channel.ToString();
                if (this.m_tabPage == null)
                    return;
                this.m_tabPage.Text = this.m_channel.ToString();
            }
        }

        public void Bind(Label label, TabPage tabPage, ChannelType initialValue)
        {
            this.m_channel = initialValue;
            if ((this.m_label = label) != null)
                this.m_label.Text = initialValue.ToString();
            if ((this.m_tabPage = tabPage) == null)
                return;
            this.m_tabPage.Text = initialValue.ToString();
        }
    }
}
