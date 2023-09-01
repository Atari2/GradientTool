// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HDMA.Configuration.Mode2ChannelPropertyTab
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace SFXProductions.GradientTool.HDMA.Configuration
{
    internal class Mode2ChannelPropertyTab : TabPage
    {
        private IContainer components;
        private Label chtypeLabel;
        private Label destRegLabel;
        private NumericUpDown hdmaChannelNumericUpDown;
        private Button swapButton;
        private ToolTip toolTip;
        private ListBox coloursListBox;
        private Mode0Channel m_sib;
        private ColourChannelsRef m_sibChtype;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new System.ComponentModel.Container();
            this.chtypeLabel = new Label();
            this.destRegLabel = new Label();
            this.hdmaChannelNumericUpDown = new NumericUpDown();
            this.swapButton = new Button();
            this.coloursListBox = new ListBox();
            this.toolTip = new ToolTip(this.components);
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            Label label4 = new Label();
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.SuspendLayout();
            this.hdmaChannelNumericUpDown.BeginInit();
            this.SuspendLayout();
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(20, 5);
            label1.Name = "label1";
            label1.Size = new Size(76, 13);
            label1.TabIndex = 0;
            label1.Text = "Channel &Type:";
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(40, 29);
            label2.Name = "label2";
            label2.Size = new Size(56, 13);
            label2.TabIndex = 1;
            label2.Text = "&Writes To:";
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(3, 53);
            label3.Name = "label3";
            label3.Size = new Size(93, 13);
            label3.TabIndex = 2;
            label3.Text = "&Colour Channel(s):";
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(12, 119);
            label4.Name = "label4";
            label4.Size = new Size(84, 13);
            label4.TabIndex = 3;
            label4.Text = "HDMA Cha&nnel:";
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            tableLayoutPanel.Controls.Add((Control)label1, 0, 0);
            tableLayoutPanel.Controls.Add((Control)label2, 0, 1);
            tableLayoutPanel.Controls.Add((Control)label3, 0, 2);
            tableLayoutPanel.Controls.Add((Control)label4, 0, 6);
            tableLayoutPanel.Controls.Add((Control)this.chtypeLabel, 1, 0);
            tableLayoutPanel.Controls.Add((Control)this.destRegLabel, 1, 1);
            tableLayoutPanel.Controls.Add((Control)this.hdmaChannelNumericUpDown, 1, 6);
            tableLayoutPanel.Controls.Add((Control)this.swapButton, 1, 4);
            tableLayoutPanel.Controls.Add((Control)this.coloursListBox, 1, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel1";
            tableLayoutPanel.RowCount = 7;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Size = new Size(238, 139);
            tableLayoutPanel.TabIndex = 0;
            this.chtypeLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.chtypeLabel.BackColor = SystemColors.Control;
            this.chtypeLabel.BorderStyle = BorderStyle.Fixed3D;
            this.chtypeLabel.Location = new Point(102, 3);
            this.chtypeLabel.Margin = new Padding(3);
            this.chtypeLabel.Name = "chtypeLabel";
            this.chtypeLabel.Size = new Size(133, 18);
            this.chtypeLabel.TabIndex = 4;
            this.chtypeLabel.Text = "Transfer Mode 2 HDMA";
            this.chtypeLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.destRegLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.destRegLabel.BackColor = SystemColors.Control;
            this.destRegLabel.BorderStyle = BorderStyle.Fixed3D;
            this.destRegLabel.Location = new Point(102, 27);
            this.destRegLabel.Margin = new Padding(3);
            this.destRegLabel.Name = "destRegLabel";
            this.destRegLabel.Size = new Size(133, 18);
            this.destRegLabel.TabIndex = 5;
            this.destRegLabel.Text = "COLDATA ($2132)";
            this.destRegLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.hdmaChannelNumericUpDown.Anchor = AnchorStyles.Left;
            this.hdmaChannelNumericUpDown.Location = new Point(102, 116);
            this.hdmaChannelNumericUpDown.Maximum = new Decimal(new int[4]
            {
        7,
        0,
        0,
        0
            });
            this.hdmaChannelNumericUpDown.Name = "hdmaChannelNumericUpDown";
            this.hdmaChannelNumericUpDown.Size = new Size(50, 20);
            this.hdmaChannelNumericUpDown.TabIndex = 6;
            this.swapButton.Anchor = AnchorStyles.Left;
            this.swapButton.Enabled = false;
            this.swapButton.Location = new Point(102, 87);
            this.swapButton.Name = "swapButton";
            this.swapButton.Size = new Size(75, 23);
            this.swapButton.TabIndex = 7;
            this.swapButton.Text = "Swap";
            this.toolTip.SetToolTip((Control)this.swapButton, "Swap the selected colour channel with the independent colour channel.");
            this.swapButton.UseVisualStyleBackColor = true;
            this.swapButton.Click += new EventHandler(this.swapButton_Click);
            this.coloursListBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.coloursListBox.FormattingEnabled = true;
            this.coloursListBox.Location = new Point(102, 51);
            this.coloursListBox.Name = "coloursListBox";
            tableLayoutPanel.SetRowSpan((Control)this.coloursListBox, 2);
            this.coloursListBox.Size = new Size(133, 30);
            this.coloursListBox.TabIndex = 8;
            this.BackColor = Color.Transparent;
            this.Controls.Add((Control)tableLayoutPanel);
            this.Size = new Size(238, 139);
            this.UseVisualStyleBackColor = true;
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            this.hdmaChannelNumericUpDown.EndInit();
            this.ResumeLayout(false);
        }

        public Mode2ChannelPropertyTab(
          Mode2Channel channel,
          Mode0Channel siblingChannel,
          ColourChannelsRef siblingChtypeRef)
        {
            this.InitializeComponent();
            this.coloursListBox.Items.AddRange(new object[2]
            {
        (object) channel.FirstWriteType,
        (object) channel.SecondWriteType
            });
            if (siblingChannel != null && siblingChtypeRef != null)
            {
                this.swapButton.Enabled = true;
                this.m_sib = siblingChannel;
                this.m_sibChtype = siblingChtypeRef;
            }
            this.Text = string.Format("{0}, {1}", (object)channel.FirstWriteType, (object)channel.SecondWriteType);
            this.hdmaChannelNumericUpDown.Value = (Decimal)channel.HDMAChannel;
        }

        private void swapButton_Click(object sender, EventArgs e)
        {
            if (this.coloursListBox.SelectedIndex < 0)
            {
                SystemSounds.Beep.Play();
            }
            else
            {
                ChannelType selectedItem = (ChannelType)this.coloursListBox.SelectedItem;
                this.coloursListBox.Items[this.coloursListBox.SelectedIndex] = (object)this.m_sibChtype.Value;
                this.m_sibChtype.Value = selectedItem;
                this.Text = string.Format("{0}, {1}", this.coloursListBox.Items[0], this.coloursListBox.Items[1]);
            }
        }

        public void ApplyChanges(Mode2Channel channel)
        {
            if (this.m_sib != null)
                this.m_sib.FirstWriteType = this.m_sibChtype.Value;
            channel.FirstWriteType = (ChannelType)this.coloursListBox.Items[0];
            channel.SecondWriteType = (ChannelType)this.coloursListBox.Items[1];
            channel.HDMAChannel = (int)this.hdmaChannelNumericUpDown.Value;
        }
    }
}
