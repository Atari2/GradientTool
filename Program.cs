// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.Program
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using SFXProductions.GradientTool.HDMA;
using SFXProductions.GradientTool.Properties;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace SFXProductions.GradientTool
{
    internal class Program : Form
    {
        private IContainer components;
        private ToolStrip toolStrip1;
        private ToolStripButton generateToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripButton aboutToolStripButton;
        private ToolStripDropDownButton typeToolStripDropDownButton;
        private ToolStripDropDownButton colourspaceToolStripDropDownButton;
        private ToolStripDropDownButton channelsToolStripDropDownButton;
        private ToolStripMenuItem rgbToolStripMenuItem;
        private ToolStripMenuItem hsvToolStripMenuItem;
        private ToolStripMenuItem hslToolStripMenuItem;
        private ToolStripMenuItem redGreenBlueToolStripMenuItem;
        private ToolStripMenuItem yellowBlueToolStripMenuItem;
        private ToolStripMenuItem redCyanToolStripMenuItem;
        private ToolStripMenuItem magentaGreenToolStripMenuItem;
        private ToolStripMenuItem redGreenToolStripMenuItem;
        private ToolStripMenuItem redBlueToolStripMenuItem;
        private ToolStripMenuItem greenBlueToolStripMenuItem;
        private ToolStripMenuItem greyToolStripMenuItem;
        private ToolStripMenuItem redToolStripMenuItem;
        private ToolStripMenuItem greenToolStripMenuItem;
        private ToolStripMenuItem blueToolStripMenuItem;
        private ToolStripMenuItem cyanToolStripMenuItem;
        private ToolStripMenuItem yellowToolStripMenuItem;
        private ToolStripMenuItem magentaToolStripMenuItem;
        private RichTextBox richTextBox1;
        private ContextMenuStrip viewerContextMenuStrip;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripButton exportImgToolStripButton;
        private Panel panel2;
        private ToolStripDropDownButton zoomToolStripDropDownButton;
        private ToolStripMenuItem x1ToolStripMenuItem;
        private ToolStripMenuItem x2ToolStripMenuItem;
        private ToolStripMenuItem x3ToolStripMenuItem;
        private ToolStripMenuItem x4ToolStripMenuItem;
        private ToolStripMenuItem x6ToolStripMenuItem;
        private ToolStripMenuItem x8ToolStripMenuItem;
        private ToolStripMenuItem x10ToolStripMenuItem;
        private ToolStripMenuItem fitToWindowToolStripMenuItem;
        private GradientControl gradientControl1;
        private ToolStripMenuItem hsyToolStripMenuItem;
        private ToolStripSplitButton configToolStripSplitButton;
        private ToolStripTextBox nWritesToolStripTextBox;
        private ToolStripTextBox gradientNameToolStripTextBox;
        private ToolStripMenuItem linearToolStripMenuItem;
        private ToolStripMenuItem circularToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem generateInitializationCodeToolStripMenuItem;
        private ToolStripMenuItem configureChannelSetupToolStripMenuItem;
        private ToolStripMenuItem brightnessToolStripMenuItem;
        private ToolStripMenuItem cubicToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripMenuItem gradientTypeToolStripMenuItem;
        private ToolStripMenuItem mode0ToolStripMenuItem;
        private ToolStripMenuItem mode2ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripMenuItem scrollableGradientToolStripMenuItem;
        private ToolStripMenuItem writeToPaletteToolStripMenuItem;
        private ToolStripTextBox paletteIndexToolStripTextBox;
        private ToolStripMenuItem catmullRomToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripMenuItem hermiteToolStripMenuItem;
        private ToolStripMenuItem configureToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripMenuItem showGridToolStripMenuItem;
        private ToolStripMenuItem rgbvToolStripMenuItem;
        private ToolStripMenuItem rgblToolStripMenuItem;
        private ToolStripMenuItem rgbbToolStripMenuItem;
        private string m_asm;
        private int m_zoom;
        private bool m_dirty = true;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new System.ComponentModel.Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Program));
            this.toolStrip1 = new ToolStrip();
            this.typeToolStripDropDownButton = new ToolStripDropDownButton();
            this.linearToolStripMenuItem = new ToolStripMenuItem();
            this.circularToolStripMenuItem = new ToolStripMenuItem();
            this.cubicToolStripMenuItem = new ToolStripMenuItem();
            this.catmullRomToolStripMenuItem = new ToolStripMenuItem();
            this.hermiteToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator17 = new ToolStripSeparator();
            this.configureToolStripMenuItem = new ToolStripMenuItem();
            this.colourspaceToolStripDropDownButton = new ToolStripDropDownButton();
            this.rgbToolStripMenuItem = new ToolStripMenuItem();
            this.rgbvToolStripMenuItem = new ToolStripMenuItem();
            this.rgbbToolStripMenuItem = new ToolStripMenuItem();
            this.rgblToolStripMenuItem = new ToolStripMenuItem();
            this.hsvToolStripMenuItem = new ToolStripMenuItem();
            this.hslToolStripMenuItem = new ToolStripMenuItem();
            this.hsyToolStripMenuItem = new ToolStripMenuItem();
            this.channelsToolStripDropDownButton = new ToolStripDropDownButton();
            this.redGreenBlueToolStripMenuItem = new ToolStripMenuItem();
            this.redCyanToolStripMenuItem = new ToolStripMenuItem();
            this.yellowBlueToolStripMenuItem = new ToolStripMenuItem();
            this.magentaGreenToolStripMenuItem = new ToolStripMenuItem();
            this.redBlueToolStripMenuItem = new ToolStripMenuItem();
            this.redGreenToolStripMenuItem = new ToolStripMenuItem();
            this.greenBlueToolStripMenuItem = new ToolStripMenuItem();
            this.redToolStripMenuItem = new ToolStripMenuItem();
            this.greenToolStripMenuItem = new ToolStripMenuItem();
            this.blueToolStripMenuItem = new ToolStripMenuItem();
            this.cyanToolStripMenuItem = new ToolStripMenuItem();
            this.yellowToolStripMenuItem = new ToolStripMenuItem();
            this.magentaToolStripMenuItem = new ToolStripMenuItem();
            this.brightnessToolStripMenuItem = new ToolStripMenuItem();
            this.greyToolStripMenuItem = new ToolStripMenuItem();
            this.zoomToolStripDropDownButton = new ToolStripDropDownButton();
            this.x1ToolStripMenuItem = new ToolStripMenuItem();
            this.fitToWindowToolStripMenuItem = new ToolStripMenuItem();
            this.x2ToolStripMenuItem = new ToolStripMenuItem();
            this.x3ToolStripMenuItem = new ToolStripMenuItem();
            this.x4ToolStripMenuItem = new ToolStripMenuItem();
            this.x6ToolStripMenuItem = new ToolStripMenuItem();
            this.x8ToolStripMenuItem = new ToolStripMenuItem();
            this.x10ToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator18 = new ToolStripSeparator();
            this.showGridToolStripMenuItem = new ToolStripMenuItem();
            this.configToolStripSplitButton = new ToolStripSplitButton();
            this.nWritesToolStripTextBox = new ToolStripTextBox();
            this.gradientNameToolStripTextBox = new ToolStripTextBox();
            this.gradientTypeToolStripMenuItem = new ToolStripMenuItem();
            this.mode0ToolStripMenuItem = new ToolStripMenuItem();
            this.mode2ToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator16 = new ToolStripSeparator();
            this.scrollableGradientToolStripMenuItem = new ToolStripMenuItem();
            this.writeToPaletteToolStripMenuItem = new ToolStripMenuItem();
            this.paletteIndexToolStripTextBox = new ToolStripTextBox();
            this.toolStripSeparator14 = new ToolStripSeparator();
            this.generateInitializationCodeToolStripMenuItem = new ToolStripMenuItem();
            this.configureChannelSetupToolStripMenuItem = new ToolStripMenuItem();
            this.generateToolStripButton = new ToolStripButton();
            this.exportImgToolStripButton = new ToolStripButton();
            this.saveToolStripButton = new ToolStripButton();
            this.aboutToolStripButton = new ToolStripButton();
            this.richTextBox1 = new RichTextBox();
            this.viewerContextMenuStrip = new ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator9 = new ToolStripSeparator();
            this.selectAllToolStripMenuItem = new ToolStripMenuItem();
            this.panel2 = new Panel();
            this.statusStrip1 = new StatusStrip();
            this.gradientControl1 = new GradientControl();
            ToolStripSeparator toolStripSeparator1 = new ToolStripSeparator();
            ToolStripSeparator toolStripSeparator2 = new ToolStripSeparator();
            ToolStripSeparator toolStripSeparator3 = new ToolStripSeparator();
            ToolStripSeparator toolStripSeparator4 = new ToolStripSeparator();
            ToolStripSeparator toolStripSeparator5 = new ToolStripSeparator();
            ToolStripSeparator toolStripSeparator6 = new ToolStripSeparator();
            ToolStripSeparator toolStripSeparator7 = new ToolStripSeparator();
            ToolStripSeparator toolStripSeparator8 = new ToolStripSeparator();
            ToolStripSeparator toolStripSeparator9 = new ToolStripSeparator();
            ToolStripSeparator toolStripSeparator10 = new ToolStripSeparator();
            ToolStripLabel toolStripLabel1 = new ToolStripLabel();
            ToolStripSeparator toolStripSeparator11 = new ToolStripSeparator();
            ToolStripLabel toolStripLabel2 = new ToolStripLabel();
            ToolStripSeparator toolStripSeparator12 = new ToolStripSeparator();
            ToolStripSeparator toolStripSeparator13 = new ToolStripSeparator();
            ToolStripLabel toolStripLabel3 = new ToolStripLabel();
            ToolStripLabel toolStripLabel4 = new ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.viewerContextMenuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            toolStripSeparator1.Name = "toolStripSeparator5";
            toolStripSeparator1.Size = new Size(6, 25);
            toolStripSeparator2.Name = "toolStripSeparator6";
            toolStripSeparator2.Size = new Size(6, 25);
            toolStripSeparator3.Name = "toolStripSeparator4";
            toolStripSeparator3.Size = new Size(153, 6);
            toolStripSeparator4.Name = "toolStripSeparator1";
            toolStripSeparator4.Size = new Size(219, 6);
            toolStripSeparator5.Name = "toolStripSeparator2";
            toolStripSeparator5.Size = new Size(153, 6);
            toolStripSeparator6.Name = "toolStripSeparator3";
            toolStripSeparator6.Size = new Size(153, 6);
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(153, 6);
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(153, 6);
            toolStripSeparator9.Name = "toolStripSeparator12";
            toolStripSeparator9.Size = new Size(137, 6);
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(6, 25);
            toolStripLabel1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(94, 13);
            toolStripLabel1.Text = "Gradient Name:";
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(204, 6);
            toolStripLabel2.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(78, 13);
            toolStripLabel2.Text = "№ of Writes:";
            toolStripSeparator12.Name = "toolStripSeparator13";
            toolStripSeparator12.Size = new Size(6, 25);
            toolStripSeparator13.Name = "toolStripSeparator15";
            toolStripSeparator13.Size = new Size(204, 6);
            toolStripLabel3.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(35, 13);
            toolStripLabel3.Text = "Misc.";
            toolStripLabel4.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(57, 13);
            toolStripLabel4.Text = "Common";
            this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new ToolStripItem[13]
            {
        (ToolStripItem) this.typeToolStripDropDownButton,
        (ToolStripItem) this.colourspaceToolStripDropDownButton,
        (ToolStripItem) this.channelsToolStripDropDownButton,
        (ToolStripItem) toolStripSeparator1,
        (ToolStripItem) this.zoomToolStripDropDownButton,
        (ToolStripItem) toolStripSeparator12,
        (ToolStripItem) this.configToolStripSplitButton,
        (ToolStripItem) this.generateToolStripButton,
        (ToolStripItem) toolStripSeparator10,
        (ToolStripItem) this.exportImgToolStripButton,
        (ToolStripItem) this.saveToolStripButton,
        (ToolStripItem) toolStripSeparator2,
        (ToolStripItem) this.aboutToolStripButton
            });
            this.toolStrip1.Location = new Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new Size(488, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.typeToolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.typeToolStripDropDownButton.DropDownItems.AddRange(new ToolStripItem[7]
            {
        (ToolStripItem) this.linearToolStripMenuItem,
        (ToolStripItem) this.circularToolStripMenuItem,
        (ToolStripItem) this.cubicToolStripMenuItem,
        (ToolStripItem) this.catmullRomToolStripMenuItem,
        (ToolStripItem) this.hermiteToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator17,
        (ToolStripItem) this.configureToolStripMenuItem
            });
            this.typeToolStripDropDownButton.Image = (Image)Resources.layer_shape_curve;
            this.typeToolStripDropDownButton.Name = "typeToolStripDropDownButton";
            this.typeToolStripDropDownButton.Size = new Size(29, 22);
            this.typeToolStripDropDownButton.Text = "Gradient Interpolation";
            this.linearToolStripMenuItem.Checked = true;
            this.linearToolStripMenuItem.CheckState = CheckState.Checked;
            this.linearToolStripMenuItem.Name = "linearToolStripMenuItem";
            this.linearToolStripMenuItem.Size = new Size(165, 22);
            this.linearToolStripMenuItem.Text = "Linear";
            this.linearToolStripMenuItem.Click += new EventHandler(this.InterpolationGroupChanged);
            this.circularToolStripMenuItem.Name = "circularToolStripMenuItem";
            this.circularToolStripMenuItem.Size = new Size(165, 22);
            this.circularToolStripMenuItem.Text = "Smooth";
            this.circularToolStripMenuItem.Click += new EventHandler(this.InterpolationGroupChanged);
            this.cubicToolStripMenuItem.Name = "cubicToolStripMenuItem";
            this.cubicToolStripMenuItem.Size = new Size(165, 22);
            this.cubicToolStripMenuItem.Text = "Cubic";
            this.cubicToolStripMenuItem.Click += new EventHandler(this.InterpolationGroupChanged);
            this.catmullRomToolStripMenuItem.Name = "catmullRomToolStripMenuItem";
            this.catmullRomToolStripMenuItem.Size = new Size(165, 22);
            this.catmullRomToolStripMenuItem.Text = "Catmull-Rom";
            this.catmullRomToolStripMenuItem.Click += new EventHandler(this.InterpolationGroupChanged);
            this.hermiteToolStripMenuItem.Name = "hermiteToolStripMenuItem";
            this.hermiteToolStripMenuItem.Size = new Size(165, 22);
            this.hermiteToolStripMenuItem.Text = "Hermite";
            this.hermiteToolStripMenuItem.Click += new EventHandler(this.InterpolationGroupChanged);
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new Size(162, 6);
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new Size(165, 22);
            this.configureToolStripMenuItem.Text = "Hermite Settings...";
            this.configureToolStripMenuItem.Click += new EventHandler(this.configureToolStripMenuItem_Click);
            this.colourspaceToolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.colourspaceToolStripDropDownButton.DropDownItems.AddRange(new ToolStripItem[8]
            {
        (ToolStripItem) this.rgbToolStripMenuItem,
        (ToolStripItem) this.rgbvToolStripMenuItem,
        (ToolStripItem) this.rgbbToolStripMenuItem,
        (ToolStripItem) this.rgblToolStripMenuItem,
        (ToolStripItem) toolStripSeparator4,
        (ToolStripItem) this.hsvToolStripMenuItem,
        (ToolStripItem) this.hslToolStripMenuItem,
        (ToolStripItem) this.hsyToolStripMenuItem
            });
            this.colourspaceToolStripDropDownButton.Image = (Image)Resources.color;
            this.colourspaceToolStripDropDownButton.Name = "colourspaceToolStripDropDownButton";
            this.colourspaceToolStripDropDownButton.Size = new Size(29, 22);
            this.colourspaceToolStripDropDownButton.Text = "Gradient Colourspace";
            this.rgbToolStripMenuItem.Name = "rgbToolStripMenuItem";
            this.rgbToolStripMenuItem.Size = new Size(222, 22);
            this.rgbToolStripMenuItem.Text = "Red / Green / Blue";
            this.rgbToolStripMenuItem.Click += new EventHandler(this.ColourspaceGroupChanged);
            this.rgbvToolStripMenuItem.Checked = true;
            this.rgbvToolStripMenuItem.CheckState = CheckState.Checked;
            this.rgbvToolStripMenuItem.Name = "rgbvToolStripMenuItem";
            this.rgbvToolStripMenuItem.Size = new Size(222, 22);
            this.rgbvToolStripMenuItem.Text = "Red / Green / Blue / Value";
            this.rgbvToolStripMenuItem.Click += new EventHandler(this.ColourspaceGroupChanged);
            this.rgbbToolStripMenuItem.Name = "rgbbToolStripMenuItem";
            this.rgbbToolStripMenuItem.Size = new Size(222, 22);
            this.rgbbToolStripMenuItem.Text = "Red / Green / Blue / Brightness";
            this.rgbbToolStripMenuItem.Visible = false;
            this.rgbbToolStripMenuItem.Click += new EventHandler(this.ColourspaceGroupChanged);
            this.rgblToolStripMenuItem.Name = "rgblToolStripMenuItem";
            this.rgblToolStripMenuItem.Size = new Size(222, 22);
            this.rgblToolStripMenuItem.Text = "Red / Green / Blue / Lightness";
            this.rgblToolStripMenuItem.Click += new EventHandler(this.ColourspaceGroupChanged);
            this.hsvToolStripMenuItem.Name = "hsvToolStripMenuItem";
            this.hsvToolStripMenuItem.Size = new Size(222, 22);
            this.hsvToolStripMenuItem.Text = "Hue / Saturation / Value";
            this.hsvToolStripMenuItem.Click += new EventHandler(this.ColourspaceGroupChanged);
            this.hslToolStripMenuItem.Name = "hslToolStripMenuItem";
            this.hslToolStripMenuItem.Size = new Size(222, 22);
            this.hslToolStripMenuItem.Text = "Hue / Saturation / Lightness";
            this.hslToolStripMenuItem.Click += new EventHandler(this.ColourspaceGroupChanged);
            this.hsyToolStripMenuItem.Name = "hsyToolStripMenuItem";
            this.hsyToolStripMenuItem.Size = new Size(222, 22);
            this.hsyToolStripMenuItem.Text = "Hue / Saturation / Luminance";
            this.hsyToolStripMenuItem.Visible = false;
            this.hsyToolStripMenuItem.Click += new EventHandler(this.ColourspaceGroupChanged);
            this.channelsToolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.channelsToolStripDropDownButton.DropDownItems.AddRange(new ToolStripItem[20]
            {
        (ToolStripItem) this.redGreenBlueToolStripMenuItem,
        (ToolStripItem) toolStripSeparator5,
        (ToolStripItem) this.redCyanToolStripMenuItem,
        (ToolStripItem) this.yellowBlueToolStripMenuItem,
        (ToolStripItem) this.magentaGreenToolStripMenuItem,
        (ToolStripItem) toolStripSeparator6,
        (ToolStripItem) this.redBlueToolStripMenuItem,
        (ToolStripItem) this.redGreenToolStripMenuItem,
        (ToolStripItem) this.greenBlueToolStripMenuItem,
        (ToolStripItem) toolStripSeparator3,
        (ToolStripItem) this.redToolStripMenuItem,
        (ToolStripItem) this.greenToolStripMenuItem,
        (ToolStripItem) this.blueToolStripMenuItem,
        (ToolStripItem) toolStripSeparator7,
        (ToolStripItem) this.cyanToolStripMenuItem,
        (ToolStripItem) this.yellowToolStripMenuItem,
        (ToolStripItem) this.magentaToolStripMenuItem,
        (ToolStripItem) toolStripSeparator8,
        (ToolStripItem) this.brightnessToolStripMenuItem,
        (ToolStripItem) this.greyToolStripMenuItem
            });
            this.channelsToolStripDropDownButton.Image = (Image)Resources.block;
            this.channelsToolStripDropDownButton.Name = "channelsToolStripDropDownButton";
            this.channelsToolStripDropDownButton.Size = new Size(29, 22);
            this.channelsToolStripDropDownButton.Text = "Gradient Channels";
            this.channelsToolStripDropDownButton.DropDownOpening += new EventHandler(this.channelsToolStripDropDownButton_DropDownOpening);
            this.redGreenBlueToolStripMenuItem.Checked = true;
            this.redGreenBlueToolStripMenuItem.CheckState = CheckState.Checked;
            this.redGreenBlueToolStripMenuItem.Name = "redGreenBlueToolStripMenuItem";
            this.redGreenBlueToolStripMenuItem.Size = new Size(156, 22);
            this.redGreenBlueToolStripMenuItem.Text = "Red, Green, Blue";
            this.redGreenBlueToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.redCyanToolStripMenuItem.Name = "redCyanToolStripMenuItem";
            this.redCyanToolStripMenuItem.Size = new Size(156, 22);
            this.redCyanToolStripMenuItem.Text = "Cyan, Red";
            this.redCyanToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.yellowBlueToolStripMenuItem.Name = "yellowBlueToolStripMenuItem";
            this.yellowBlueToolStripMenuItem.Size = new Size(156, 22);
            this.yellowBlueToolStripMenuItem.Text = "Yellow, Blue";
            this.yellowBlueToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.magentaGreenToolStripMenuItem.Name = "magentaGreenToolStripMenuItem";
            this.magentaGreenToolStripMenuItem.Size = new Size(156, 22);
            this.magentaGreenToolStripMenuItem.Text = "Magenta, Green";
            this.magentaGreenToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.redBlueToolStripMenuItem.Name = "redBlueToolStripMenuItem";
            this.redBlueToolStripMenuItem.Size = new Size(156, 22);
            this.redBlueToolStripMenuItem.Text = "Red, Blue";
            this.redBlueToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.redGreenToolStripMenuItem.Name = "redGreenToolStripMenuItem";
            this.redGreenToolStripMenuItem.Size = new Size(156, 22);
            this.redGreenToolStripMenuItem.Text = "Red, Green";
            this.redGreenToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.greenBlueToolStripMenuItem.Name = "greenBlueToolStripMenuItem";
            this.greenBlueToolStripMenuItem.Size = new Size(156, 22);
            this.greenBlueToolStripMenuItem.Text = "Green, Blue";
            this.greenBlueToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new Size(156, 22);
            this.redToolStripMenuItem.Text = "Red";
            this.redToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Size = new Size(156, 22);
            this.greenToolStripMenuItem.Text = "Green";
            this.greenToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new Size(156, 22);
            this.blueToolStripMenuItem.Text = "Blue";
            this.blueToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.cyanToolStripMenuItem.Name = "cyanToolStripMenuItem";
            this.cyanToolStripMenuItem.Size = new Size(156, 22);
            this.cyanToolStripMenuItem.Text = "Cyan";
            this.cyanToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.yellowToolStripMenuItem.Name = "yellowToolStripMenuItem";
            this.yellowToolStripMenuItem.Size = new Size(156, 22);
            this.yellowToolStripMenuItem.Text = "Yellow";
            this.yellowToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.magentaToolStripMenuItem.Name = "magentaToolStripMenuItem";
            this.magentaToolStripMenuItem.Size = new Size(156, 22);
            this.magentaToolStripMenuItem.Text = "Magenta";
            this.magentaToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            this.brightnessToolStripMenuItem.Size = new Size(156, 22);
            this.brightnessToolStripMenuItem.Text = "Brightness";
            this.brightnessToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.greyToolStripMenuItem.Name = "greyToolStripMenuItem";
            this.greyToolStripMenuItem.Size = new Size(156, 22);
            this.greyToolStripMenuItem.Text = "Grey";
            this.greyToolStripMenuItem.Click += new EventHandler(this.ChannelsGroupChanged);
            this.zoomToolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.zoomToolStripDropDownButton.DropDownItems.AddRange(new ToolStripItem[11]
            {
        (ToolStripItem) this.x1ToolStripMenuItem,
        (ToolStripItem) this.fitToWindowToolStripMenuItem,
        (ToolStripItem) toolStripSeparator9,
        (ToolStripItem) this.x2ToolStripMenuItem,
        (ToolStripItem) this.x3ToolStripMenuItem,
        (ToolStripItem) this.x4ToolStripMenuItem,
        (ToolStripItem) this.x6ToolStripMenuItem,
        (ToolStripItem) this.x8ToolStripMenuItem,
        (ToolStripItem) this.x10ToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator18,
        (ToolStripItem) this.showGridToolStripMenuItem
            });
            this.zoomToolStripDropDownButton.Image = (Image)Resources.magnifier_zoom;
            this.zoomToolStripDropDownButton.Name = "zoomToolStripDropDownButton";
            this.zoomToolStripDropDownButton.Size = new Size(29, 22);
            this.zoomToolStripDropDownButton.Text = "Zoom";
            this.x1ToolStripMenuItem.Image = (Image)Resources.magnifier_zoom_actual;
            this.x1ToolStripMenuItem.Name = "x1ToolStripMenuItem";
            this.x1ToolStripMenuItem.Size = new Size(140, 22);
            this.x1ToolStripMenuItem.Text = "Actual Size";
            this.x1ToolStripMenuItem.Click += new EventHandler(this.actualSizeToolStripMenuItem_Click);
            this.fitToWindowToolStripMenuItem.Checked = true;
            this.fitToWindowToolStripMenuItem.CheckState = CheckState.Checked;
            this.fitToWindowToolStripMenuItem.Image = (Image)Resources.magnifier_zoom_fit;
            this.fitToWindowToolStripMenuItem.Name = "fitToWindowToolStripMenuItem";
            this.fitToWindowToolStripMenuItem.Size = new Size(140, 22);
            this.fitToWindowToolStripMenuItem.Text = "Fit to Window";
            this.fitToWindowToolStripMenuItem.Click += new EventHandler(this.actualSizeToolStripMenuItem_Click);
            this.x2ToolStripMenuItem.Name = "x2ToolStripMenuItem";
            this.x2ToolStripMenuItem.Size = new Size(140, 22);
            this.x2ToolStripMenuItem.Text = "2x";
            this.x2ToolStripMenuItem.Click += new EventHandler(this.actualSizeToolStripMenuItem_Click);
            this.x3ToolStripMenuItem.Name = "x3ToolStripMenuItem";
            this.x3ToolStripMenuItem.Size = new Size(140, 22);
            this.x3ToolStripMenuItem.Text = "3x";
            this.x3ToolStripMenuItem.Click += new EventHandler(this.actualSizeToolStripMenuItem_Click);
            this.x4ToolStripMenuItem.Name = "x4ToolStripMenuItem";
            this.x4ToolStripMenuItem.Size = new Size(140, 22);
            this.x4ToolStripMenuItem.Text = "4x";
            this.x4ToolStripMenuItem.Click += new EventHandler(this.actualSizeToolStripMenuItem_Click);
            this.x6ToolStripMenuItem.Name = "x6ToolStripMenuItem";
            this.x6ToolStripMenuItem.Size = new Size(140, 22);
            this.x6ToolStripMenuItem.Text = "6x";
            this.x6ToolStripMenuItem.Click += new EventHandler(this.actualSizeToolStripMenuItem_Click);
            this.x8ToolStripMenuItem.Name = "x8ToolStripMenuItem";
            this.x8ToolStripMenuItem.Size = new Size(140, 22);
            this.x8ToolStripMenuItem.Text = "8x";
            this.x8ToolStripMenuItem.Click += new EventHandler(this.actualSizeToolStripMenuItem_Click);
            this.x10ToolStripMenuItem.Name = "x10ToolStripMenuItem";
            this.x10ToolStripMenuItem.Size = new Size(140, 22);
            this.x10ToolStripMenuItem.Text = "10x";
            this.x10ToolStripMenuItem.Click += new EventHandler(this.actualSizeToolStripMenuItem_Click);
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new Size(137, 6);
            this.showGridToolStripMenuItem.Checked = true;
            this.showGridToolStripMenuItem.CheckOnClick = true;
            this.showGridToolStripMenuItem.CheckState = CheckState.Checked;
            this.showGridToolStripMenuItem.Name = "showGridToolStripMenuItem";
            this.showGridToolStripMenuItem.Size = new Size(140, 22);
            this.showGridToolStripMenuItem.Text = "Show Grid";
            this.showGridToolStripMenuItem.CheckedChanged += new EventHandler(this.showGridToolStripMenuItem_CheckedChanged);
            this.configToolStripSplitButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.configToolStripSplitButton.DropDownItems.AddRange(new ToolStripItem[10]
            {
        (ToolStripItem) toolStripLabel2,
        (ToolStripItem) this.nWritesToolStripTextBox,
        (ToolStripItem) toolStripSeparator11,
        (ToolStripItem) toolStripLabel1,
        (ToolStripItem) this.gradientNameToolStripTextBox,
        (ToolStripItem) toolStripSeparator13,
        (ToolStripItem) this.gradientTypeToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator14,
        (ToolStripItem) this.generateInitializationCodeToolStripMenuItem,
        (ToolStripItem) this.configureChannelSetupToolStripMenuItem
            });
            this.configToolStripSplitButton.Image = (Image)Resources.wrench_screwdriver;
            this.configToolStripSplitButton.Name = "configToolStripSplitButton";
            this.configToolStripSplitButton.Size = new Size(32, 22);
            this.configToolStripSplitButton.Text = "Configure HDMA";
            this.configToolStripSplitButton.ButtonClick += new EventHandler(this.configToolStripSplitButton_Click);
            this.configToolStripSplitButton.DropDownClosed += new EventHandler(this.channelsToolStripDropDownButton_DropDownClosed);
            this.configToolStripSplitButton.DropDownOpening += new EventHandler(this.configToolStripSplitButton_DropDownOpening);
            this.nWritesToolStripTextBox.Name = "nWritesToolStripTextBox";
            this.nWritesToolStripTextBox.Size = new Size(100, 21);
            this.nWritesToolStripTextBox.Text = "224";
            this.nWritesToolStripTextBox.ToolTipText = "Number of Writes";
            this.gradientNameToolStripTextBox.Name = "gradientNameToolStripTextBox";
            this.gradientNameToolStripTextBox.Size = new Size(100, 21);
            this.gradientNameToolStripTextBox.Text = "Gradient1";
            this.gradientNameToolStripTextBox.ToolTipText = "Gradient Name";
            this.gradientTypeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[8]
            {
        (ToolStripItem) toolStripLabel4,
        (ToolStripItem) this.mode0ToolStripMenuItem,
        (ToolStripItem) this.mode2ToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator16,
        (ToolStripItem) toolStripLabel3,
        (ToolStripItem) this.scrollableGradientToolStripMenuItem,
        (ToolStripItem) this.writeToPaletteToolStripMenuItem,
        (ToolStripItem) this.paletteIndexToolStripTextBox
            });
            this.gradientTypeToolStripMenuItem.Name = "gradientTypeToolStripMenuItem";
            this.gradientTypeToolStripMenuItem.Size = new Size(207, 22);
            this.gradientTypeToolStripMenuItem.Text = "Gradient Type";
            this.gradientTypeToolStripMenuItem.DropDownClosed += new EventHandler(this.gradientTypeToolStripMenuItem_DropDownClosed);
            this.gradientTypeToolStripMenuItem.DropDownOpening += new EventHandler(this.gradientTypeToolStripMenuItem_DropDownOpening);
            this.mode0ToolStripMenuItem.Name = "mode0ToolStripMenuItem";
            this.mode0ToolStripMenuItem.Size = new Size(163, 22);
            this.mode0ToolStripMenuItem.Text = "Mode 0";
            this.mode0ToolStripMenuItem.Click += new EventHandler(this.GradientModeClicked);
            this.mode2ToolStripMenuItem.Checked = true;
            this.mode2ToolStripMenuItem.CheckState = CheckState.Checked;
            this.mode2ToolStripMenuItem.Name = "mode2ToolStripMenuItem";
            this.mode2ToolStripMenuItem.Size = new Size(163, 22);
            this.mode2ToolStripMenuItem.Text = "Mode 2";
            this.mode2ToolStripMenuItem.Click += new EventHandler(this.GradientModeClicked);
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new Size(160, 6);
            this.scrollableGradientToolStripMenuItem.Name = "scrollableGradientToolStripMenuItem";
            this.scrollableGradientToolStripMenuItem.Size = new Size(163, 22);
            this.scrollableGradientToolStripMenuItem.Text = "Scrollable Gradient";
            this.scrollableGradientToolStripMenuItem.Click += new EventHandler(this.GradientModeClicked);
            this.writeToPaletteToolStripMenuItem.Name = "writeToPaletteToolStripMenuItem";
            this.writeToPaletteToolStripMenuItem.Size = new Size(163, 22);
            this.writeToPaletteToolStripMenuItem.Text = "Write to Palette:";
            this.writeToPaletteToolStripMenuItem.Click += new EventHandler(this.GradientModeClicked);
            this.paletteIndexToolStripTextBox.Name = "paletteIndexToolStripTextBox";
            this.paletteIndexToolStripTextBox.Size = new Size(100, 21);
            this.paletteIndexToolStripTextBox.Text = "00";
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new Size(204, 6);
            this.generateInitializationCodeToolStripMenuItem.CheckOnClick = true;
            this.generateInitializationCodeToolStripMenuItem.Name = "generateInitializationCodeToolStripMenuItem";
            this.generateInitializationCodeToolStripMenuItem.Size = new Size(207, 22);
            this.generateInitializationCodeToolStripMenuItem.Text = "Generate Initialization Code";
            this.generateInitializationCodeToolStripMenuItem.CheckedChanged += new EventHandler(this.generateInitializationCodeToolStripMenuItem_CheckedChanged);
            this.configureChannelSetupToolStripMenuItem.Name = "configureChannelSetupToolStripMenuItem";
            this.configureChannelSetupToolStripMenuItem.Size = new Size(207, 22);
            this.configureChannelSetupToolStripMenuItem.Text = "Configure Channel Setup...";
            this.configureChannelSetupToolStripMenuItem.Click += new EventHandler(this.configToolStripSplitButton_Click);
            this.generateToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.generateToolStripButton.Image = (Image)Resources.gear__arrow;
            this.generateToolStripButton.Name = "generateToolStripButton";
            this.generateToolStripButton.Size = new Size(23, 22);
            this.generateToolStripButton.Text = "Generate HDMA Code";
            this.generateToolStripButton.Click += new EventHandler(this.GenerateToolStripButtonClicked);
            this.exportImgToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.exportImgToolStripButton.Image = (Image)Resources.image_export;
            this.exportImgToolStripButton.Name = "exportImgToolStripButton";
            this.exportImgToolStripButton.Size = new Size(23, 22);
            this.exportImgToolStripButton.Text = "Export as Bitmap";
            this.exportImgToolStripButton.Click += new EventHandler(this.ExportToolStripButtonClicked);
            this.saveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Enabled = false;
            this.saveToolStripButton.Image = (Image)Resources.disk;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new Size(23, 22);
            this.saveToolStripButton.Text = "Save HDMA";
            this.saveToolStripButton.Click += new EventHandler(this.SaveToolStripButtonClicked);
            this.aboutToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.aboutToolStripButton.Image = (Image)Resources.information_frame;
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            this.aboutToolStripButton.Size = new Size(23, 22);
            this.aboutToolStripButton.Text = "About GradientTool";
            this.aboutToolStripButton.Click += new EventHandler(this.AboutToolStripButtonClicked);
            this.richTextBox1.BackColor = Color.White;
            this.richTextBox1.ContextMenuStrip = this.viewerContextMenuStrip;
            this.richTextBox1.Dock = DockStyle.Fill;
            this.richTextBox1.Font = new Font("Courier New", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.richTextBox1.ForeColor = Color.Black;
            this.richTextBox1.Location = new Point(83, 25);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new Size(405, 518);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.viewerContextMenuStrip.Items.AddRange(new ToolStripItem[3]
            {
        (ToolStripItem) this.copyToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator9,
        (ToolStripItem) this.selectAllToolStripMenuItem
            });
            this.viewerContextMenuStrip.Name = "contextMenuStrip1";
            this.viewerContextMenuStrip.ShowImageMargin = false;
            this.viewerContextMenuStrip.Size = new Size(93, 54);
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = Keys.C | Keys.Control;
            this.copyToolStripMenuItem.ShowShortcutKeys = false;
            this.copyToolStripMenuItem.Size = new Size(92, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new EventHandler(this.CopyClicked);
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new Size(89, 6);
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new Size(92, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            this.selectAllToolStripMenuItem.Click += new EventHandler(this.SelectAllClicked);
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add((Control)this.gradientControl1);
            this.panel2.Dock = DockStyle.Left;
            this.panel2.Location = new Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new Padding(2, 2, 0, 2);
            this.panel2.Size = new Size(83, 518);
            this.panel2.TabIndex = 6;
            this.panel2.Resize += new EventHandler(this.panel2_Resize);
            this.statusStrip1.Location = new Point(0, 543);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new Size(488, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            this.gradientControl1.Channels = GradientChannels.RedGreenBlue;
            this.gradientControl1.Colourspace = GradientColourspace.RGBV;
            this.gradientControl1.Dock = DockStyle.Fill;
            this.gradientControl1.GenerateHDMAInitializationCode = false;
            this.gradientControl1.GradientName = "Gradient1";
            this.gradientControl1.Location = new Point(2, 2);
            this.gradientControl1.Name = "gradientControl1";
            this.gradientControl1.ShowGrid = true;
            this.gradientControl1.Size = new Size(81, 514);
            this.gradientControl1.TabIndex = 4;
            this.gradientControl1.Text = "gradientControl1";
            this.gradientControl1.Type = GradientType.Linear;
            this.gradientControl1.GradientChanged += new EventHandler(this.gradientControl1_GradientChanged);
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(488, 565);
            this.Controls.Add((Control)this.richTextBox1);
            this.Controls.Add((Control)this.panel2);
            this.Controls.Add((Control)this.toolStrip1);
            this.Controls.Add((Control)this.statusStrip1);
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MinimumSize = new Size(250, 350);
            this.Name = nameof(Program);
            this.Text = "GradientTool*";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.viewerContextMenuStrip.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public Program()
        {
            this.InitializeComponent();
            this.richTextBox1.Rtf = Resources.NoCodeGeneratedMessage;
        }

        private void InterpolationGroupChanged(object sender, EventArgs e)
        {
            foreach (object dropDownItem in (ArrangedElementCollection)this.typeToolStripDropDownButton.DropDownItems)
            {
                if (dropDownItem is ToolStripMenuItem objA)
                {
                    if (!object.ReferenceEquals((object)objA, sender))
                    {
                        objA.Checked = false;
                    }
                    else
                    {
                        objA.Checked = true;
                        if (object.ReferenceEquals((object)objA, (object)this.linearToolStripMenuItem))
                            this.gradientControl1.Type = GradientType.Linear;
                        else if (object.ReferenceEquals((object)objA, (object)this.circularToolStripMenuItem))
                            this.gradientControl1.Type = GradientType.Circular;
                        else if (object.ReferenceEquals((object)objA, (object)this.cubicToolStripMenuItem))
                            this.gradientControl1.Type = GradientType.Cubic;
                        else if (object.ReferenceEquals((object)objA, (object)this.catmullRomToolStripMenuItem))
                            this.gradientControl1.Type = GradientType.CatmullRom;
                        else if (object.ReferenceEquals((object)objA, (object)this.hermiteToolStripMenuItem))
                            this.gradientControl1.Type = GradientType.Hermite;
                    }
                }
            }
        }

        private void ColourspaceGroupChanged(object sender, EventArgs e)
        {
            foreach (object dropDownItem in (ArrangedElementCollection)this.colourspaceToolStripDropDownButton.DropDownItems)
            {
                if (dropDownItem is ToolStripMenuItem objA)
                {
                    if (!object.ReferenceEquals((object)objA, sender))
                    {
                        objA.Checked = false;
                    }
                    else
                    {
                        objA.Checked = true;
                        if (object.ReferenceEquals((object)objA, (object)this.rgbToolStripMenuItem))
                            this.gradientControl1.Colourspace = GradientColourspace.RGB;
                        else if (object.ReferenceEquals((object)objA, (object)this.rgbvToolStripMenuItem))
                            this.gradientControl1.Colourspace = GradientColourspace.RGBV;
                        else if (object.ReferenceEquals((object)objA, (object)this.rgbbToolStripMenuItem))
                            this.gradientControl1.Colourspace = GradientColourspace.RGBB;
                        else if (object.ReferenceEquals((object)objA, (object)this.rgblToolStripMenuItem))
                            this.gradientControl1.Colourspace = GradientColourspace.RGBL;
                        else if (object.ReferenceEquals((object)objA, (object)this.hsvToolStripMenuItem))
                            this.gradientControl1.Colourspace = GradientColourspace.HSV;
                        else if (object.ReferenceEquals((object)objA, (object)this.hslToolStripMenuItem))
                            this.gradientControl1.Colourspace = GradientColourspace.HSL;
                        else if (object.ReferenceEquals((object)objA, (object)this.hsyToolStripMenuItem))
                            this.gradientControl1.Colourspace = GradientColourspace.HSY;
                    }
                }
            }
        }

        private void ChannelsGroupChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)null;
            bool flag = true;
            try
            {
                foreach (object dropDownItem in (ArrangedElementCollection)this.channelsToolStripDropDownButton.DropDownItems)
                {
                    if (dropDownItem is ToolStripMenuItem objA)
                    {
                        if (!object.ReferenceEquals((object)objA, sender))
                        {
                            if (objA.Checked)
                                toolStripMenuItem = objA;
                            objA.Checked = false;
                        }
                        else
                        {
                            if (object.ReferenceEquals((object)objA, (object)this.redGreenBlueToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.RedGreenBlue;
                            else if (object.ReferenceEquals((object)objA, (object)this.redGreenToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.RedGreen;
                            else if (object.ReferenceEquals((object)objA, (object)this.greenBlueToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.GreenBlue;
                            else if (object.ReferenceEquals((object)objA, (object)this.redBlueToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.RedBlue;
                            else if (object.ReferenceEquals((object)objA, (object)this.redCyanToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.CyanRed;
                            else if (object.ReferenceEquals((object)objA, (object)this.yellowBlueToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.YellowBlue;
                            else if (object.ReferenceEquals((object)objA, (object)this.magentaGreenToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.MagentaGreen;
                            else if (object.ReferenceEquals((object)objA, (object)this.redToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.Red;
                            else if (object.ReferenceEquals((object)objA, (object)this.greenToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.Green;
                            else if (object.ReferenceEquals((object)objA, (object)this.blueToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.Blue;
                            else if (object.ReferenceEquals((object)objA, (object)this.cyanToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.Cyan;
                            else if (object.ReferenceEquals((object)objA, (object)this.yellowToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.Yellow;
                            else if (object.ReferenceEquals((object)objA, (object)this.magentaToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.Magenta;
                            else if (object.ReferenceEquals((object)objA, (object)this.brightnessToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.Brightness;
                            else if (object.ReferenceEquals((object)objA, (object)this.greyToolStripMenuItem))
                                this.gradientControl1.Channels = GradientChannels.Grey;
                            objA.Checked = true;
                        }
                    }
                    flag = false;
                }
            }
            catch (ArgumentException)
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "Gradients that use a Transfer Mode 2 table must have at least 2 colour channels.", "GradientTool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (SilentException)
            {
            }
            if (!flag)
                return;
            toolStripMenuItem.Checked = true;
        }

        private void GenerateToolStripButtonClicked(object sender, EventArgs e)
        {
            int lineFromCharIndex = this.richTextBox1.GetLineFromCharIndex(this.richTextBox1.SelectionStart);
            int num = this.richTextBox1.SelectionStart - this.richTextBox1.GetFirstCharIndexOfCurrentLine();
            CodeGen code = new CodeGen();
            this.gradientControl1.GenerateASM(code);
            code.SetTextBoxText(this.richTextBox1);
            this.m_asm = code.GetText();
            this.saveToolStripButton.Enabled = true;
            int start;
            if (lineFromCharIndex >= this.richTextBox1.Lines.Length)
            {
                start = this.richTextBox1.TextLength;
            }
            else
            {
                string line = this.richTextBox1.Lines[lineFromCharIndex];
                if (num > line.Length)
                    num = line.Length;
                start = num + this.richTextBox1.GetFirstCharIndexFromLine(lineFromCharIndex);
            }
            this.richTextBox1.Select(start, 0);
            this.Clean();
        }

        private void SaveToolStripButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.m_asm))
            {
                this.saveToolStripButton.Enabled = false;
                SystemSounds.Beep.Play();
            }
            else
            {
                if (this.m_dirty)
                {
                    switch (MessageBox.Show((IWin32Window)this, "The gradient has been modified since you last generated the code.\r\nDo you want to re-generate the code?", "GradientTool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Cancel:
                            return;
                        case DialogResult.Yes:
                            this.GenerateToolStripButtonClicked((object)null, (EventArgs)null);
                            break;
                    }
                }
                string path = Utils.PromptForFilename((IWin32Window)this, "ASM Files (.asm)|*.asm|All files|*.*", "asm", this.gradientNameToolStripTextBox.Text);
                if (path == null)
                    return;
                File.WriteAllText(path, this.m_asm, Encoding.Default);
            }
        }

        private unsafe void ExportToolStripButtonClicked(object sender, EventArgs e)
        {
            int num = 1;
            string filename;
            do
            {
                string text = this.gradientNameToolStripTextBox.Text;
                string typeId = "ExportGradientAsBitmap";
                filename = Utils.PromptForFilename((IWin32Window)this, (this.gradientControl1.Channels != GradientChannels.Brightness ? "15-bit" : "4-bit") + " Gradient (.png, .bmp, .dib, .jpeg, .gif)|*.png;*.bmp;*.dib;*.jpeg;*.jpg;*.jpe;*.gif|24-bit Gradient (.png, .bmp, .dib, .jpeg, .gif)|*.png;*.bmp;*.dib;*.jpeg;*.jpg;*.jpe;*.gif|All Files|*.*", "png", &num, text, typeId);
            }
            while (filename != null && !this.gradientControl1.SaveGradient(filename, num == 2));
        }

        private void AboutToolStripButtonClicked(object sender, EventArgs e)
        {
            using (AboutBox aboutBox = new AboutBox())
            {
                int num = (int)aboutBox.ShowDialog((IWin32Window)this);
            }
        }

        private void CopyClicked(object sender, EventArgs e)
        {
            if (this.richTextBox1.SelectionLength > 0)
            {
                this.richTextBox1.Copy();
            }
            else
            {
                int selectionStart = this.richTextBox1.SelectionStart;
                int indexOfCurrentLine = this.richTextBox1.GetFirstCharIndexOfCurrentLine();
                this.richTextBox1.Select(indexOfCurrentLine, this.richTextBox1.Lines[this.richTextBox1.GetLineFromCharIndex(indexOfCurrentLine)].Length + 1);
                this.richTextBox1.Copy();
                this.richTextBox1.Select(selectionStart, 0);
            }
        }

        private void SelectAllClicked(object sender, EventArgs e) => this.richTextBox1.SelectAll();

        [STAThread]
        private static int Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Program mainForm;
                try
                {
                    mainForm = new Program();
                }
                catch (OutOfMemoryException)
                {
                    int num = (int)MessageBox.Show("There is not enough memory for the application to start.", "GradientTool", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return 14;
                }
                Application.Run((Form)mainForm);
                return 0;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("An unhandled exception occurred.\r\n\r\n" + ex.ToString(), "GradientTool", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                throw;
            }
        }

        private void channelsToolStripDropDownButton_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                this.gradientControl1.GradientName = this.gradientNameToolStripTextBox.Text.Trim();
            }
            catch (ArgumentException)
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "The specified gradient name contains invalid characters.\r\nNames may contain [a-z], [A-Z], [0-9], and [_].\r\nNot that they cannot start with a numeric character.", "GradientTool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            string s = this.nWritesToolStripTextBox.Text.Trim();
            int result;
            if (!int.TryParse(s, NumberStyles.Number, (IFormatProvider)null, out result))
            {
                int startIndex;
                if (s[0] == '$' && s.Length > (startIndex = 1) || s[0] == '0' && char.ToLowerInvariant(s[1]) == 'x' && s.Length > (startIndex = 2) || s[0] == '&' && char.ToLowerInvariant(s[1]) == 'h' && s.Length > (startIndex = 2))
                {
                    if (int.TryParse(s.Substring(startIndex), NumberStyles.HexNumber, (IFormatProvider)null, out result))
                        goto label_6;
                }
                int num = (int)MessageBox.Show((IWin32Window)this, "Could not parse number.\r\nThe number must be an integer in decimal or hexadecimal format.\r\nNumbers in decimal format are permitted to have thousands separators.", "GradientTool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        label_6:
            try
            {
                try
                {
                    this.gradientControl1.SetSizeOfGradient(result);
                    GC.Collect();
                }
                catch (OutOfMemoryException)
                {
                    int num = (int)MessageBox.Show((IWin32Window)this, "Not enough memory. No change was made.", "GradientTool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    GC.Collect();
                }
                if (this.m_zoom <= 0)
                    return;
                this.gradientControl1.Height = this.gradientControl1.SizeOfGradient * this.m_zoom + 18;
            }
            catch (ArgumentOutOfRangeException)
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "The entered value must be between 4 and 32,767, or 0x7FFF.", "GradientTool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ResetZoom()
        {
            this.panel2.BorderStyle = BorderStyle.None;
            this.panel2.Padding = new Padding(2, 2, 0, 2);
            this.panel2.Width = 83;
            this.gradientControl1.Dock = DockStyle.Fill;
            this.m_zoom = 0;
        }

        private void SetZoom(int n)
        {
            this.m_zoom = n;
            int num = this.gradientControl1.SizeOfGradient * n + 18;
            this.panel2.BorderStyle = BorderStyle.Fixed3D;
            this.panel2.Padding = Padding.Empty;
            this.panel2.Width = 85 + (this.panel2.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0);
            this.gradientControl1.Dock = DockStyle.Top;
            this.gradientControl1.Height = num;
            this.gradientControl1.Width = 81;
            this.gradientControl1.Top = this.gradientControl1.Left = 0;
        }

        private void actualSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (object dropDownItem in (ArrangedElementCollection)this.zoomToolStripDropDownButton.DropDownItems)
            {
                if (dropDownItem is ToolStripMenuItem objA)
                {
                    if (!object.ReferenceEquals((object)objA, sender))
                    {
                        if (!object.ReferenceEquals((object)objA, (object)this.showGridToolStripMenuItem))
                            objA.Checked = false;
                    }
                    else
                    {
                        objA.Checked = true;
                        if (object.ReferenceEquals(sender, (object)this.fitToWindowToolStripMenuItem))
                            this.ResetZoom();
                        else if (object.ReferenceEquals(sender, (object)this.x1ToolStripMenuItem))
                            this.SetZoom(1);
                        else if (object.ReferenceEquals(sender, (object)this.x2ToolStripMenuItem))
                            this.SetZoom(2);
                        else if (object.ReferenceEquals(sender, (object)this.x3ToolStripMenuItem))
                            this.SetZoom(3);
                        else if (object.ReferenceEquals(sender, (object)this.x4ToolStripMenuItem))
                            this.SetZoom(4);
                        else if (object.ReferenceEquals(sender, (object)this.x6ToolStripMenuItem))
                            this.SetZoom(6);
                        else if (object.ReferenceEquals(sender, (object)this.x8ToolStripMenuItem))
                            this.SetZoom(8);
                        else if (object.ReferenceEquals(sender, (object)this.x10ToolStripMenuItem))
                            this.SetZoom(10);
                    }
                }
            }
        }

        private void panel2_Resize(object sender, EventArgs e) => this.panel2.Width = 85 + (this.panel2.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0);

        private void configToolStripSplitButton_Click(object sender, EventArgs e)
        {
            Settings2 settings = this.gradientControl1.Settings;
            int sizeOfGradient = this.gradientControl1.SizeOfGradient;
            if (!Config2.ConfigureSettings((IWin32Window)this, ref settings, ref sizeOfGradient))
                return;
            try
            {
                this.gradientControl1.Settings = settings;
                this.gradientControl1.SetSizeOfGradient(sizeOfGradient);
            }
            catch
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "An error occured and some settings may not have been changed.", "GradientTool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void generateInitializationCodeToolStripMenuItem_CheckedChanged(
          object sender,
          EventArgs e)
        {
            this.gradientControl1.GenerateHDMAInitializationCode = this.generateInitializationCodeToolStripMenuItem.Checked;
        }

        private void channelsToolStripDropDownButton_DropDownOpening(object sender, EventArgs e)
        {
            switch (this.gradientControl1.Settings.Arrangement)
            {
                case 0:
                    IEnumerator enumerator1 = this.channelsToolStripDropDownButton.DropDownItems.GetEnumerator();
                    try
                    {
                        while (enumerator1.MoveNext())
                        {
                            if (enumerator1.Current is ToolStripMenuItem current)
                                current.Enabled = true;
                        }
                        break;
                    }
                    finally
                    {
                        if (enumerator1 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case 1:
                    this.redGreenBlueToolStripMenuItem.Enabled = this.redGreenToolStripMenuItem.Enabled = this.redBlueToolStripMenuItem.Enabled = this.greenBlueToolStripMenuItem.Enabled = this.redCyanToolStripMenuItem.Enabled = this.magentaGreenToolStripMenuItem.Enabled = this.yellowBlueToolStripMenuItem.Enabled = this.brightnessToolStripMenuItem.Enabled = true;
                    this.redToolStripMenuItem.Enabled = this.greenToolStripMenuItem.Enabled = this.blueToolStripMenuItem.Enabled = this.cyanToolStripMenuItem.Enabled = this.magentaToolStripMenuItem.Enabled = this.yellowToolStripMenuItem.Enabled = this.greyToolStripMenuItem.Enabled = false;
                    break;
                case 2:
                case 3:
                    IEnumerator enumerator2 = this.channelsToolStripDropDownButton.DropDownItems.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            if (enumerator2.Current is ToolStripMenuItem current)
                            {
                                bool flag;
                                current.Enabled = (flag = object.ReferenceEquals((object)current, (object)this.redGreenBlueToolStripMenuItem)) || object.ReferenceEquals((object)current, (object)this.brightnessToolStripMenuItem);
                                current.Checked = flag;
                            }
                        }
                        break;
                    }
                    finally
                    {
                        if (enumerator2 is IDisposable disposable)
                            disposable.Dispose();
                    }
            }
        }

        private void configToolStripSplitButton_DropDownOpening(object sender, EventArgs e)
        {
            this.nWritesToolStripTextBox.Text = this.gradientControl1.SizeOfGradient.ToString();
            this.gradientNameToolStripTextBox.Text = this.gradientControl1.GradientName;
            this.generateInitializationCodeToolStripMenuItem.Checked = this.gradientControl1.GenerateHDMAInitializationCode;
        }

        private void gradientTypeToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            bool flag = false;
            this.mode2ToolStripMenuItem.Enabled = Generator2.GetNChannels(this.gradientControl1.Channels) >= 2;
            switch (this.gradientControl1.Settings.Arrangement)
            {
                case 1:
                    this.mode0ToolStripMenuItem.Checked = false;
                    this.writeToPaletteToolStripMenuItem.Checked = false;
                    this.scrollableGradientToolStripMenuItem.Checked = false;
                    this.mode2ToolStripMenuItem.Checked = true;
                    break;
                case 2:
                    this.mode0ToolStripMenuItem.Checked = false;
                    this.mode2ToolStripMenuItem.Checked = false;
                    this.scrollableGradientToolStripMenuItem.Checked = false;
                    this.writeToPaletteToolStripMenuItem.Checked = true;
                    if (this.gradientControl1.Settings.Channel1 is Mode3Channel channel1)
                    {
                        flag = true;
                        this.paletteIndexToolStripTextBox.Text = channel1.PaletteIndex.ToString("X2");
                        break;
                    }
                    break;
                case 3:
                    this.mode0ToolStripMenuItem.Checked = false;
                    this.mode2ToolStripMenuItem.Checked = false;
                    this.writeToPaletteToolStripMenuItem.Checked = false;
                    this.scrollableGradientToolStripMenuItem.Checked = true;
                    break;
                default:
                    this.mode2ToolStripMenuItem.Checked = false;
                    this.writeToPaletteToolStripMenuItem.Checked = false;
                    this.scrollableGradientToolStripMenuItem.Checked = false;
                    this.mode0ToolStripMenuItem.Checked = true;
                    break;
            }
            if (flag)
                return;
            this.paletteIndexToolStripTextBox.Text = "00";
        }

        private void Dirty()
        {
            if (this.m_dirty)
                return;
            this.m_dirty = true;
            this.Text = "GradientTool*";
        }

        private void Clean()
        {
            if (!this.m_dirty)
                return;
            this.m_dirty = false;
            this.Text = "GradientTool";
        }

        private void gradientControl1_GradientChanged(object sender, EventArgs e) => this.Dirty();

        private void DoChange(int mode)
        {
            Settings2 settings = this.gradientControl1.Settings;
            switch (mode)
            {
                case 0:
                    settings.MakeMode0All(settings.Channels);
                    break;
                case 1:
                    settings.MakeMode2Mode0(settings.Channels);
                    break;
                case 2:
                    settings.MakeMode3();
                    break;
                case 3:
                    settings.MakeCombined();
                    break;
            }
            this.gradientControl1.Settings = settings;
        }

        private void GradientModeClicked(object sender, EventArgs e)
        {
            if (object.ReferenceEquals(sender, (object)this.mode0ToolStripMenuItem))
                this.DoChange(0);
            else if (object.ReferenceEquals(sender, (object)this.mode2ToolStripMenuItem))
                this.DoChange(1);
            else if (object.ReferenceEquals(sender, (object)this.writeToPaletteToolStripMenuItem))
                this.DoChange(2);
            else if (object.ReferenceEquals(sender, (object)this.scrollableGradientToolStripMenuItem))
                this.DoChange(3);
            foreach (object dropDownItem in (ArrangedElementCollection)this.gradientTypeToolStripMenuItem.DropDownItems)
            {
                if (dropDownItem is ToolStripMenuItem objA)
                    objA.Checked = object.ReferenceEquals((object)objA, sender);
            }
        }

        private void gradientTypeToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            if (!(this.gradientControl1.Settings.Channel1 is Mode3Channel channel1))
                return;
            int result;
            if (int.TryParse(this.paletteIndexToolStripTextBox.Text, NumberStyles.HexNumber, (IFormatProvider)null, out result) && result >= 0 && result <= (int)byte.MaxValue)
            {
                channel1.PaletteIndex = (byte)result;
                this.Dirty();
            }
            else
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "Palette index must be a hexadecimal number between 0x00 and 0xFF.", "GradientTool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (HermiteConfiguration hermiteConfiguration = new HermiteConfiguration(new Action(this.gradientControl1.UpdateGradient)))
            {
                int num = (int)hermiteConfiguration.ShowDialog((IWin32Window)this);
            }
        }

        private void showGridToolStripMenuItem_CheckedChanged(object sender, EventArgs e) => this.gradientControl1.ShowGrid = this.showGridToolStripMenuItem.Checked;
    }
}
