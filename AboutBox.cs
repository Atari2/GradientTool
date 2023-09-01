// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.AboutBox
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SFXProductions.GradientTool
{
    internal class AboutBox : Form
    {
        private IContainer components;
        private TableLayoutPanel tableLayoutPanel;
        private Label labelProductName;
        private Label labelVersion;
        private Label labelCopyright;
        private Button okButton;
        private LinkLabel linkLabel1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel = new TableLayoutPanel();
            this.labelProductName = new Label();
            this.labelVersion = new Label();
            this.labelCopyright = new Label();
            this.okButton = new Button();
            this.linkLabel1 = new LinkLabel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel.Controls.Add((Control)this.labelProductName, 0, 0);
            this.tableLayoutPanel.Controls.Add((Control)this.labelVersion, 0, 1);
            this.tableLayoutPanel.Controls.Add((Control)this.labelCopyright, 0, 2);
            this.tableLayoutPanel.Controls.Add((Control)this.okButton, 0, 4);
            this.tableLayoutPanel.Controls.Add((Control)this.linkLabel1, 0, 3);
            this.tableLayoutPanel.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Location = new Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25.00001f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 24.99999f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel.Size = new Size(246, 124);
            this.tableLayoutPanel.TabIndex = 0;
            this.labelProductName.AutoEllipsis = true;
            this.labelProductName.Dock = DockStyle.Fill;
            this.labelProductName.Location = new Point(6, 0);
            this.labelProductName.Margin = new Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new Size(0, 17);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new Size(237, 17);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "Product Name";
            this.labelProductName.TextAlign = ContentAlignment.MiddleLeft;
            this.labelVersion.AutoEllipsis = true;
            this.labelVersion.Dock = DockStyle.Fill;
            this.labelVersion.Location = new Point(6, 23);
            this.labelVersion.Margin = new Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new Size(0, 17);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new Size(237, 17);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = ContentAlignment.MiddleLeft;
            this.labelCopyright.AutoEllipsis = true;
            this.labelCopyright.Dock = DockStyle.Fill;
            this.labelCopyright.Location = new Point(6, 46);
            this.labelCopyright.Margin = new Padding(6, 0, 3, 0);
            this.labelCopyright.MaximumSize = new Size(0, 17);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new Size(237, 17);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Text = "Copyright";
            this.labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
            this.okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.okButton.DialogResult = DialogResult.Cancel;
            this.okButton.Location = new Point(168, 98);
            this.okButton.Name = "okButton";
            this.okButton.Size = new Size(75, 23);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            this.linkLabel1.AutoEllipsis = true;
            this.linkLabel1.Dock = DockStyle.Fill;
            this.linkLabel1.LinkArea = new LinkArea(14, 17);
            this.linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            this.linkLabel1.Location = new Point(6, 69);
            this.linkLabel1.Margin = new Padding(6, 0, 3, 0);
            this.linkLabel1.MaximumSize = new Size(0, 17);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(237, 17);
            this.linkLabel1.TabIndex = 25;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Some icons by Yusuke Kamiyamane.";
            this.linkLabel1.TextAlign = ContentAlignment.MiddleLeft;
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.AcceptButton = (IButtonControl)this.okButton;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(264, 142);
            this.Controls.Add((Control)this.tableLayoutPanel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(AboutBox);
            this.Padding = new Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "About GradientTool";
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public AboutBox()
        {
            this.InitializeComponent();
            this.labelProductName.Text = this.AssemblyProduct;
            this.labelVersion.Text = string.Format("Version {0}", (object)this.AssemblyVersion);
            this.labelCopyright.Text = this.AssemblyCopyright;
        }

        public string AssemblyTitle
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (customAttributes.Length > 0)
                {
                    AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute)customAttributes[0];
                    if (assemblyTitleAttribute.Title != "")
                        return assemblyTitleAttribute.Title;
                }
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
            }
        }

        public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public string AssemblyDescription
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                return customAttributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                return customAttributes.Length == 0 ? "" : ((AssemblyProductAttribute)customAttributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return customAttributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                return customAttributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)customAttributes[0]).Company;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("http://p.yusukekamiyamane.com/");
    }
}
