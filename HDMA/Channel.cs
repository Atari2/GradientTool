// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HDMA.Channel
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using SFXProductions.GradientTool.HDMA.Configuration;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SFXProductions.GradientTool.HDMA
{
    internal abstract class Channel
    {
        private int m_channel;

        internal Channel()
        {
        }

        internal Channel(int channelNum) => this.m_channel = channelNum;

        public string GetChannelLabel(string gradientName) => gradientName + (object)'_' + this.ChannelSuffix;

        public int HDMAChannel
        {
            get => this.m_channel;
            set
            {
                if (this.m_channel == value)
                    return;
                this.m_channel = value >= 0 && value <= 7 ? value : throw new ArgumentOutOfRangeException(nameof(value), "HDMA Channel number must be between 0 and 7.");
            }
        }

        public ChannelType FirstWriteType { get; set; }

        public ChannelType SecondWriteType { get; set; }

        public virtual bool CanUseContinuousMode => true;

        public abstract bool IsBackgroundOrBrightnessHDMA { get; }

        public abstract bool HasSecondWrite { get; }

        public abstract string ChannelSuffix { get; }

        public abstract uint CalculateTableSize(IList<CompressedDataPoint> data);

        public abstract TabPage CreatePropertiesPage(
          Mode0Channel sib,
          ref ColourChannelsRef channelsReference);

        public abstract void ApplySettings(TabPage propertiesPage);

        public abstract void GetRawData(
          double[] rBuffer,
          double[] gBuffer,
          double[] bBuffer,
          DataPoint[] dataBuffer);

        protected abstract void DoWriteData(IList<CompressedDataPoint> hdmaTable, CodeGen cGen);

        public void WriteData(IList<CompressedDataPoint> hdmaTable, CodeGen cGen, string gradientName)
        {
            cGen.AppendLabel(this.GetChannelLabel(gradientName));
            cGen.AppendPlainText(':');
            cGen.AppendLine();
            this.DoWriteData(hdmaTable, cGen);
            cGen.AppendKeyword("db");
            cGen.AppendSpace();
            cGen.AppendNumeric("$00");
            cGen.AppendLine();
        }
    }
}
