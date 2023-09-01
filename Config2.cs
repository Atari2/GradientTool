// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.Config2
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using SFXProductions.GradientTool.HDMA;
using SFXProductions.GradientTool.HDMA.Configuration;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SFXProductions.GradientTool
{
    internal class Config2 : Form
    {
        private Settings2 m_settings;
        private IContainer components;
        private Button okButton;
        private Button cancelButton;
        private TabControl optionsTabControl;
        private CheckBox generateInitCheckBox;
        private TextBox gradientNameTextBox;
        private NumericUpDown nWritesNumericUpDown;
        private CheckBox hexCheckBox;

        private Config2(Settings2 settings)
        {
            this.InitializeComponent();
            this.m_settings = settings;
            this.generateInitCheckBox.Checked = settings.GenerateInitializationCode;
            this.gradientNameTextBox.Text = settings.Name;
            ColourChannelsRef channelsReference = (ColourChannelsRef)null;
            this.optionsTabControl.TabPages.Add(this.m_settings.Channel1.CreatePropertiesPage(this.m_settings.Channel2 as Mode0Channel, ref channelsReference));
            if (this.m_settings.Channel2 != null)
                this.optionsTabControl.TabPages.Add(this.m_settings.Channel2.CreatePropertiesPage((Mode0Channel)null, ref channelsReference));
            if (this.m_settings.Channel3 == null)
                return;
            this.optionsTabControl.TabPages.Add(this.m_settings.Channel3.CreatePropertiesPage((Mode0Channel)null, ref channelsReference));
        }

        private void ApplySettings()
        {
            this.m_settings.Channel1.ApplySettings(this.optionsTabControl.TabPages[0]);
            if (this.m_settings.Channel2 != null)
                this.m_settings.Channel2.ApplySettings(this.optionsTabControl.TabPages[1]);
            if (this.m_settings.Channel3 == null)
                return;
            this.m_settings.Channel2.ApplySettings(this.optionsTabControl.TabPages[2]);
        }

        public static bool ConfigureSettings(
          IWin32Window owner,
          ref Settings2 settings,
          ref int nWrites)
        {
            using (Config2 config2 = new Config2(settings))
            {
                config2.nWritesNumericUpDown.Value = (Decimal)nWrites;
                if (config2.ShowDialog(owner) == DialogResult.OK)
                {
                    config2.ApplySettings();
                    settings.GenerateInitializationCode = config2.generateInitCheckBox.Checked;
                    settings.Name = config2.gradientNameTextBox.Text;
                    nWrites = (int)config2.nWritesNumericUpDown.Value;
                    return true;
                }
            }
            return false;
        }

        private void hexCheckBox_CheckedChanged(object sender, EventArgs e) => this.nWritesNumericUpDown.Hexadecimal = this.hexCheckBox.Checked;

        private void gradientNameTextBox_TextChanged(object sender, EventArgs e) => this.okButton.Enabled = Settings2.ValidateName(this.gradientNameTextBox.Text = this.gradientNameTextBox.Text.Trim());

        private void generateInitCheckBox_CheckedChanged(object sender, EventArgs e) => this.optionsTabControl.Enabled = this.generateInitCheckBox.Checked;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.nWritesNumericUpDown = new NumericUpDown();
            this.hexCheckBox = new CheckBox();
            this.okButton = new Button();
            this.cancelButton = new Button();
            this.optionsTabControl = new TabControl();
            this.generateInitCheckBox = new CheckBox();
            this.gradientNameTextBox = new TextBox();
            Label label1 = new Label();
            Label label2 = new Label();
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            this.nWritesNumericUpDown.BeginInit();
            this.SuspendLayout();
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(18, 6);
            label1.Name = "label1";
            label1.Size = new Size(66, 13);
            label1.TabIndex = 0;
            label1.Text = "№ of Wri&tes:";
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(3, 32);
            label2.Name = "label2";
            label2.Size = new Size(81, 13);
            label2.TabIndex = 2;
            label2.Text = "Gradient N&ame:";
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add((Control)tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add((Control)this.okButton, 0, 4);
            tableLayoutPanel1.Controls.Add((Control)this.cancelButton, 2, 4);
            tableLayoutPanel1.Controls.Add((Control)this.optionsTabControl, 0, 3);
            tableLayoutPanel1.Controls.Add((Control)label1, 0, 0);
            tableLayoutPanel1.Controls.Add((Control)this.generateInitCheckBox, 1, 2);
            tableLayoutPanel1.Controls.Add((Control)label2, 0, 1);
            tableLayoutPanel1.Controls.Add((Control)this.gradientNameTextBox, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(9, 9);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            tableLayoutPanel1.Size = new Size(282, 322);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel2.Anchor = AnchorStyles.Left;
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel1.SetColumnSpan((Control)tableLayoutPanel2, 2);
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add((Control)this.nWritesNumericUpDown, 0, 0);
            tableLayoutPanel2.Controls.Add((Control)this.hexCheckBox, 1, 0);
            tableLayoutPanel2.Location = new Point(87, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(132, 26);
            tableLayoutPanel2.TabIndex = 1;
            this.nWritesNumericUpDown.Anchor = AnchorStyles.Left;
            this.nWritesNumericUpDown.Location = new Point(3, 3);
            this.nWritesNumericUpDown.Maximum = new Decimal(new int[4]
            {
        (int) short.MaxValue,
        0,
        0,
        0
            });
            this.nWritesNumericUpDown.Name = "nWritesNumericUpDown";
            this.nWritesNumericUpDown.Size = new Size(75, 20);
            this.nWritesNumericUpDown.TabIndex = 0;
            this.nWritesNumericUpDown.Value = new Decimal(new int[4]
            {
        224,
        0,
        0,
        0
            });
            this.hexCheckBox.AutoSize = true;
            this.hexCheckBox.Location = new Point(84, 3);
            this.hexCheckBox.Name = "hexCheckBox";
            this.hexCheckBox.Size = new Size(45, 17);
            this.hexCheckBox.TabIndex = 1;
            this.hexCheckBox.Text = "&Hex";
            this.hexCheckBox.UseVisualStyleBackColor = true;
            this.hexCheckBox.CheckedChanged += new EventHandler(this.hexCheckBox_CheckedChanged);
            this.okButton.Anchor = AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan((Control)this.okButton, 2);
            this.okButton.DialogResult = DialogResult.OK;
            this.okButton.Location = new Point(123, 296);
            this.okButton.Name = "okButton";
            this.okButton.Size = new Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.cancelButton.Anchor = AnchorStyles.None;
            this.cancelButton.DialogResult = DialogResult.Cancel;
            this.cancelButton.Location = new Point(204, 296);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            tableLayoutPanel1.SetColumnSpan((Control)this.optionsTabControl, 3);
            this.optionsTabControl.Dock = DockStyle.Fill;
            this.optionsTabControl.Location = new Point(3, 83);
            this.optionsTabControl.Margin = new Padding(3, 8, 3, 3);
            this.optionsTabControl.Name = "optionsTabControl";
            this.optionsTabControl.SelectedIndex = 0;
            this.optionsTabControl.Size = new Size(276, 207);
            this.optionsTabControl.TabIndex = 5;
            this.generateInitCheckBox.Anchor = AnchorStyles.Left;
            this.generateInitCheckBox.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan((Control)this.generateInitCheckBox, 2);
            this.generateInitCheckBox.Location = new Point(90, 55);
            this.generateInitCheckBox.Name = "generateInitCheckBox";
            this.generateInitCheckBox.Size = new Size(155, 17);
            this.generateInitCheckBox.TabIndex = 4;
            this.generateInitCheckBox.Text = "&Generate Initialization Code";
            this.generateInitCheckBox.UseVisualStyleBackColor = true;
            this.gradientNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan((Control)this.gradientNameTextBox, 2);
            this.gradientNameTextBox.Location = new Point(90, 29);
            this.gradientNameTextBox.Name = "gradientNameTextBox";
            this.gradientNameTextBox.Size = new Size(189, 20);
            this.gradientNameTextBox.TabIndex = 3;
            this.gradientNameTextBox.Text = "Gradient1";
            this.gradientNameTextBox.TextChanged += new EventHandler(this.gradientNameTextBox_TextChanged);
            this.AcceptButton = (IButtonControl)this.okButton;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = (IButtonControl)this.cancelButton;
            this.ClientSize = new Size(300, 340);
            this.Controls.Add((Control)tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new Size(432, 371);
            this.MinimumSize = new Size(276, 326);
            this.Name = nameof(Config2);
            this.Padding = new Padding(9);
            this.ShowIcon = false;
            this.Text = "Configure HDMA";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            this.nWritesNumericUpDown.EndInit();
            this.ResumeLayout(false);
        }
    }
}
