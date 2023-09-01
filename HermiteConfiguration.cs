// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HermiteConfiguration
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SFXProductions.GradientTool
{
    internal class HermiteConfiguration : Form
    {
        private IContainer components;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Button closeButton;
        private NumericUpDown biasNumericUpDown;
        private NumericUpDown tensionTumericUpDown;
        private Action m_updater;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.label1 = new Label();
            this.label2 = new Label();
            this.biasNumericUpDown = new NumericUpDown();
            this.tensionTumericUpDown = new NumericUpDown();
            this.closeButton = new Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.biasNumericUpDown.BeginInit();
            this.tensionTumericUpDown.BeginInit();
            this.SuspendLayout();
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
            this.tableLayoutPanel1.Controls.Add((Control)this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add((Control)this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add((Control)this.biasNumericUpDown, 1, 0);
            this.tableLayoutPanel1.Controls.Add((Control)this.tensionTumericUpDown, 1, 1);
            this.tableLayoutPanel1.Controls.Add((Control)this.closeButton, 0, 3);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(9, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.Size = new Size(160, 87);
            this.tableLayoutPanel1.TabIndex = 0;
            this.label1.Anchor = AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(21, 6);
            this.label1.Name = "label1";
            this.label1.Size = new Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bias:";
            this.label2.Anchor = AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tension:";
            this.biasNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.biasNumericUpDown.DecimalPlaces = 3;
            this.biasNumericUpDown.Increment = new Decimal(new int[4]
            {
        5,
        0,
        0,
        65536
            });
            this.biasNumericUpDown.Location = new Point(57, 3);
            this.biasNumericUpDown.Maximum = new Decimal(new int[4]
            {
        20,
        0,
        0,
        0
            });
            this.biasNumericUpDown.Minimum = new Decimal(new int[4]
            {
        20,
        0,
        0,
        int.MinValue
            });
            this.biasNumericUpDown.Name = "biasNumericUpDown";
            this.biasNumericUpDown.Size = new Size(100, 20);
            this.biasNumericUpDown.TabIndex = 4;
            this.biasNumericUpDown.ValueChanged += new EventHandler(this.biasNumericUpDown_ValueChanged);
            this.tensionTumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.tensionTumericUpDown.DecimalPlaces = 3;
            this.tensionTumericUpDown.Increment = new Decimal(new int[4]
            {
        5,
        0,
        0,
        65536
            });
            this.tensionTumericUpDown.Location = new Point(57, 29);
            this.tensionTumericUpDown.Minimum = new Decimal(new int[4]
            {
        100,
        0,
        0,
        int.MinValue
            });
            this.tensionTumericUpDown.Name = "tensionTumericUpDown";
            this.tensionTumericUpDown.Size = new Size(100, 20);
            this.tensionTumericUpDown.TabIndex = 5;
            this.tensionTumericUpDown.ValueChanged += new EventHandler(this.tensionTumericUpDown_ValueChanged);
            this.closeButton.Anchor = AnchorStyles.Right;
            this.tableLayoutPanel1.SetColumnSpan((Control)this.closeButton, 2);
            this.closeButton.DialogResult = DialogResult.Cancel;
            this.closeButton.Location = new Point(82, 61);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.AcceptButton = (IButtonControl)this.closeButton;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = (IButtonControl)this.closeButton;
            this.ClientSize = new Size(178, 105);
            this.Controls.Add((Control)this.tableLayoutPanel1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(HermiteConfiguration);
            this.Padding = new Padding(9);
            this.Text = "Interpolation Settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.biasNumericUpDown.EndInit();
            this.tensionTumericUpDown.EndInit();
            this.ResumeLayout(false);
        }

        public HermiteConfiguration(Action updatedCallback)
        {
            this.InitializeComponent();
            this.biasNumericUpDown.Value = (Decimal)(HermiteSettings.Bias * 10.0);
            this.tensionTumericUpDown.Value = (Decimal)(HermiteSettings.Tension * 10.0);
            this.m_updater = updatedCallback;
        }

        private void biasNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            HermiteSettings.Bias = (double)(this.biasNumericUpDown.Value / 10M);
            if (this.m_updater == null)
                return;
            this.m_updater();
        }

        private void tensionTumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            HermiteSettings.Tension = (double)(this.tensionTumericUpDown.Value / 10M);
            if (this.m_updater == null)
                return;
            this.m_updater();
        }
    }
}
