// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HDMA.Settings2
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System;
using System.Windows.Forms;

namespace SFXProductions.GradientTool.HDMA
{
    internal struct Settings2
    {
        public const int Mode0AllArrangement = 0;
        public const int Mode2Mode0Arrangement = 1;
        public const int Mode3Arrangement = 2;
        public const int CombinedArrangement = 3;
        private int m_arrangement;
        private GradientChannels m_channels;
        private string m_name;
        private Channel m_ch1;
        private Channel m_ch2;
        private Channel m_ch3;

        public int Arrangement => this.m_arrangement;

        public string GetGradientTypeBanner()
        {
            switch (this.m_arrangement)
            {
                case 1:
                    return this.m_channels != GradientChannels.RedGreenBlue ? "Mode 2 COLDATA Gradient" : "Mode 2 + Mode 0 COLDATA Gradient";
                case 2:
                    return "Mode 3 CGADD + CGDATA Gradient";
                case 3:
                    return "Scrolling Gradient";
                default:
                    return this.m_channels == GradientChannels.Brightness ? "Mode 0 INIDISP Gradient" : "Mode 0 COLDATA Gradient";
            }
        }

        public GradientChannels Channels
        {
            get => this.m_channels;
            set
            {
                if (this.m_channels == value)
                    return;
                if (value == GradientChannels.Brightness)
                {
                    if (this.m_arrangement != 0 && MessageBox.Show("Brightness gradients work with Transfer Mode 0 HDMA channels.\r\nDo you want to change the gradient to use only Transfer Mode 0 channels?", "GradientTool", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        throw new SilentException();
                    this.MakeMode0All(value);
                }
                else
                {
                    switch (this.m_arrangement)
                    {
                        case 0:
                            this.MakeMode0All(value);
                            break;
                        case 1:
                            this.MakeMode2Mode0(value);
                            break;
                    }
                }
            }
        }

        public string Name
        {
            get => this.m_name;
            set
            {
                value = value.Trim();
                if (value.Length == 0)
                    value = (string)null;
                if (!(this.m_name != value))
                    return;
                this.m_name = Settings2.ValidateName(value) ? value : throw new ArgumentException("The specified name contains invalid characters.", nameof(value));
            }
        }

        public static bool ValidateName(string name)
        {
            if (name == null)
                return true;
            bool flag = true;
            for (int index = 0; index < name.Length; ++index)
            {
                char ch = name[index];
                if (ch != '_' && (ch < 'a' || ch > 'z') && (ch < 'A' || ch > 'Z') && (index <= 0 || ch < '0' || ch > '9'))
                    flag = false;
            }
            return flag;
        }

        public bool GenerateInitializationCode { get; set; }

        public Channel Channel1 => this.m_ch1;

        public Channel Channel2 => this.m_ch2;

        public Channel Channel3 => this.m_ch3;

        public static Settings2 CreateMode0All(GradientChannels channels, string name = null)
        {
            Settings2 mode0All = new Settings2();
            mode0All.m_arrangement = 0;
            mode0All.m_channels = channels;
            mode0All.Name = name;
            ref Settings2 local1 = ref mode0All;
            Mode0Channel mode0Channel1 = new Mode0Channel();
            mode0Channel1.HDMAChannel = 3;
            mode0Channel1.FirstWriteType = Generator2.GetChannel(channels, 0);
            Mode0Channel mode0Channel2 = mode0Channel1;
            local1.m_ch1 = (Channel)mode0Channel2;
            ref Settings2 local2 = ref mode0All;
            Mode0Channel mode0Channel3;
            if (Generator2.GetNChannels(channels) <= 1)
            {
                mode0Channel3 = (Mode0Channel)null;
            }
            else
            {
                Mode0Channel mode0Channel4 = new Mode0Channel();
                mode0Channel4.HDMAChannel = 4;
                mode0Channel4.FirstWriteType = Generator2.GetChannel(channels, 1);
                mode0Channel3 = mode0Channel4;
            }
            local2.m_ch2 = (Channel)mode0Channel3;
            ref Settings2 local3 = ref mode0All;
            Mode0Channel mode0Channel5;
            if (channels != GradientChannels.RedGreenBlue)
            {
                mode0Channel5 = (Mode0Channel)null;
            }
            else
            {
                Mode0Channel mode0Channel6 = new Mode0Channel();
                mode0Channel6.HDMAChannel = 5;
                mode0Channel6.FirstWriteType = ChannelType.Blue;
                mode0Channel5 = mode0Channel6;
            }
            local3.m_ch3 = (Channel)mode0Channel5;
            return mode0All;
        }

        public static Settings2 CreateMode2Mode0(GradientChannels channels, string name = null)
        {
            if (Generator2.GetNChannels(channels) < 2)
                throw new ArgumentException("To generate a Transfer Mode 2 HDMA table, there must be at least two colour channels.", nameof(channels));
            Settings2 mode2Mode0 = new Settings2();
            mode2Mode0.m_arrangement = 1;
            mode2Mode0.m_channels = channels;
            mode2Mode0.Name = name;
            ref Settings2 local1 = ref mode2Mode0;
            Mode2Channel mode2Channel1 = new Mode2Channel();
            mode2Channel1.HDMAChannel = 3;
            mode2Channel1.FirstWriteType = Generator2.GetChannel(channels, 0);
            mode2Channel1.SecondWriteType = Generator2.GetChannel(channels, 1);
            Mode2Channel mode2Channel2 = mode2Channel1;
            local1.m_ch1 = (Channel)mode2Channel2;
            ref Settings2 local2 = ref mode2Mode0;
            Mode0Channel mode0Channel1;
            if (channels != GradientChannels.RedGreenBlue)
            {
                mode0Channel1 = (Mode0Channel)null;
            }
            else
            {
                Mode0Channel mode0Channel2 = new Mode0Channel();
                mode0Channel2.HDMAChannel = 4;
                mode0Channel2.FirstWriteType = ChannelType.Blue;
                mode0Channel1 = mode0Channel2;
            }
            local2.m_ch2 = (Channel)mode0Channel1;
            return mode2Mode0;
        }

        public static Settings2 CreateMode3(string name = null)
        {
            Settings2 mode3 = new Settings2();
            mode3.m_arrangement = 2;
            mode3.Name = name;
            mode3.m_channels = GradientChannels.RedGreenBlue;
            ref Settings2 local = ref mode3;
            Mode3Channel mode3Channel1 = new Mode3Channel();
            mode3Channel1.HDMAChannel = 3;
            Mode3Channel mode3Channel2 = mode3Channel1;
            local.m_ch1 = (Channel)mode3Channel2;
            return mode3;
        }

        public static Settings2 CreateCombined(string name = null) => new Settings2()
        {
            m_arrangement = 3,
            Name = name,
            m_channels = GradientChannels.RedGreenBlue,
            m_ch1 = (Channel)new CombinedChannel()
        };

        public void MakeMode0All(GradientChannels channels)
        {
            bool initializationCode = this.GenerateInitializationCode;
            int hdmaChannel = this.m_ch1.HDMAChannel;
            int num1 = this.m_ch2 != null ? this.m_ch2.HDMAChannel : 4;
            int num2 = this.m_ch3 != null ? this.m_ch3.HDMAChannel : 5;
            this = Settings2.CreateMode0All(channels, this.Name);
            this.GenerateInitializationCode = initializationCode;
            this.m_ch1.HDMAChannel = hdmaChannel;
            if (this.m_ch2 != null)
                this.m_ch2.HDMAChannel = num1;
            if (this.m_ch3 == null)
                return;
            this.m_ch3.HDMAChannel = num2;
        }

        public void MakeMode2Mode0(GradientChannels channels)
        {
            bool initializationCode = this.GenerateInitializationCode;
            int hdmaChannel = this.m_ch1.HDMAChannel;
            int num = this.m_ch2 != null ? this.m_ch2.HDMAChannel : 4;
            this = Settings2.CreateMode2Mode0(channels, this.Name);
            this.GenerateInitializationCode = initializationCode;
            this.m_ch1.HDMAChannel = hdmaChannel;
            if (this.m_ch2 == null)
                return;
            this.m_ch2.HDMAChannel = num;
        }

        public void MakeMode3()
        {
            bool initializationCode = this.GenerateInitializationCode;
            int hdmaChannel = this.m_ch1.HDMAChannel;
            this = Settings2.CreateMode3(this.Name);
            this.GenerateInitializationCode = initializationCode;
            this.m_ch1.HDMAChannel = hdmaChannel;
        }

        public void MakeCombined()
        {
            bool initializationCode = this.GenerateInitializationCode;
            int hdmaChannel = this.m_ch1.HDMAChannel;
            this = Settings2.CreateCombined(this.Name);
            this.GenerateInitializationCode = initializationCode;
            this.m_ch1.HDMAChannel = hdmaChannel;
        }
    }
}
