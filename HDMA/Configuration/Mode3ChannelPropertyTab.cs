// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HDMA.Configuration.Mode3ChannelPropertyTab
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SFXProductions.GradientTool.HDMA.Configuration
{
    internal class Mode3ChannelPropertyTab : TabPage
    {
        private IContainer components;
        private Label chtypeLabel;
        private Label destRegLabel;
        private Label coloursLabel;
        private NumericUpDown palIndexNumericUpDown;
        private NumericUpDown hdmaChannelNumericUpDown;

        public Mode3ChannelPropertyTab(Mode3Channel channel)
        {
            this.InitializeComponent();
            this.palIndexNumericUpDown.Value = (Decimal)channel.PaletteIndex;
            this.hdmaChannelNumericUpDown.Value = (Decimal)channel.HDMAChannel;
        }

        public void ApplyChanges(Mode3Channel channel)
        {
            channel.PaletteIndex = (byte)this.palIndexNumericUpDown.Value;
            channel.HDMAChannel = (int)this.hdmaChannelNumericUpDown.Value;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.chtypeLabel = new Label();
            this.destRegLabel = new Label();
            this.coloursLabel = new Label();
            this.palIndexNumericUpDown = new NumericUpDown();
            this.hdmaChannelNumericUpDown = new NumericUpDown();
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            Label label4 = new Label();
            Label label5 = new Label();
            tableLayoutPanel.SuspendLayout();
            this.palIndexNumericUpDown.BeginInit();
            this.hdmaChannelNumericUpDown.BeginInit();
            this.SuspendLayout();
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            tableLayoutPanel.Controls.Add((Control)label1, 0, 0);
            tableLayoutPanel.Controls.Add((Control)label2, 0, 1);
            tableLayoutPanel.Controls.Add((Control)label3, 0, 2);
            tableLayoutPanel.Controls.Add((Control)label4, 0, 4);
            tableLayoutPanel.Controls.Add((Control)label5, 0, 5);
            tableLayoutPanel.Controls.Add((Control)this.chtypeLabel, 1, 0);
            tableLayoutPanel.Controls.Add((Control)this.destRegLabel, 1, 1);
            tableLayoutPanel.Controls.Add((Control)this.coloursLabel, 1, 2);
            tableLayoutPanel.Controls.Add((Control)this.palIndexNumericUpDown, 1, 4);
            tableLayoutPanel.Controls.Add((Control)this.hdmaChannelNumericUpDown, 1, 5);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel1";
            tableLayoutPanel.RowCount = 6;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Size = new Size(286, 124);
            tableLayoutPanel.TabIndex = 0;
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
            label2.TabIndex = 2;
            label2.Text = "&Writes To:";
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(3, 53);
            label3.Name = "label3";
            label3.Size = new Size(93, 13);
            label3.TabIndex = 4;
            label3.Text = "&Colour Channel(s):";
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(24, 78);
            label4.Name = "label4";
            label4.Size = new Size(72, 13);
            label4.TabIndex = 6;
            label4.Text = "Palette &Index:";
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(12, 104);
            label5.Name = "label5";
            label5.Size = new Size(84, 13);
            label5.TabIndex = 8;
            label5.Text = "HDMA Cha&nnel:";
            this.chtypeLabel.AutoEllipsis = true;
            this.chtypeLabel.BackColor = SystemColors.Control;
            this.chtypeLabel.BorderStyle = BorderStyle.Fixed3D;
            this.chtypeLabel.Dock = DockStyle.Fill;
            this.chtypeLabel.Location = new Point(102, 3);
            this.chtypeLabel.Margin = new Padding(3);
            this.chtypeLabel.Name = "chtypeLabel";
            this.chtypeLabel.Size = new Size(181, 18);
            this.chtypeLabel.TabIndex = 1;
            this.chtypeLabel.Text = "Transfer Mode 3 HDMA";
            this.chtypeLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.destRegLabel.AutoEllipsis = true;
            this.destRegLabel.BackColor = SystemColors.Control;
            this.destRegLabel.BorderStyle = BorderStyle.Fixed3D;
            this.destRegLabel.Dock = DockStyle.Fill;
            this.destRegLabel.Location = new Point(102, 27);
            this.destRegLabel.Margin = new Padding(3);
            this.destRegLabel.Name = "destRegLabel";
            this.destRegLabel.Size = new Size(181, 18);
            this.destRegLabel.TabIndex = 3;
            this.destRegLabel.Text = "CGADD, CGDATA ($2121, $2122)";
            this.destRegLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.coloursLabel.AutoEllipsis = true;
            this.coloursLabel.BackColor = SystemColors.Control;
            this.coloursLabel.BorderStyle = BorderStyle.Fixed3D;
            this.coloursLabel.Dock = DockStyle.Fill;
            this.coloursLabel.Location = new Point(102, 51);
            this.coloursLabel.Margin = new Padding(3);
            this.coloursLabel.Name = "coloursLabel";
            this.coloursLabel.Size = new Size(181, 18);
            this.coloursLabel.TabIndex = 5;
            this.coloursLabel.Text = "Red, Green, Blue";
            this.coloursLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.palIndexNumericUpDown.Anchor = AnchorStyles.Left;
            this.palIndexNumericUpDown.Hexadecimal = true;
            this.palIndexNumericUpDown.Location = new Point(102, 75);
            this.palIndexNumericUpDown.Maximum = new Decimal(new int[4]
            {
        (int) byte.MaxValue,
        0,
        0,
        0
            });
            this.palIndexNumericUpDown.Name = "palIndexNumericUpDown";
            this.palIndexNumericUpDown.Size = new Size(50, 20);
            this.palIndexNumericUpDown.TabIndex = 7;
            this.hdmaChannelNumericUpDown.Anchor = AnchorStyles.Left;
            this.hdmaChannelNumericUpDown.Location = new Point(102, 101);
            this.hdmaChannelNumericUpDown.Maximum = new Decimal(new int[4]
            {
        7,
        0,
        0,
        0
            });
            this.hdmaChannelNumericUpDown.Name = "hdmaChannelNumericUpDown";
            this.hdmaChannelNumericUpDown.Size = new Size(50, 20);
            this.hdmaChannelNumericUpDown.TabIndex = 9;
            this.Controls.Add((Control)tableLayoutPanel);
            this.Size = new Size(286, 124);
            this.UseVisualStyleBackColor = true;
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            this.palIndexNumericUpDown.EndInit();
            this.hdmaChannelNumericUpDown.EndInit();
            this.ResumeLayout(false);
        }
    }
}
