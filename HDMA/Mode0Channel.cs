// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HDMA.Mode0Channel
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using SFXProductions.GradientTool.HDMA.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SFXProductions.GradientTool.HDMA
{
    internal sealed class Mode0Channel : Channel
    {
        public override bool HasSecondWrite => false;

        public override bool IsBackgroundOrBrightnessHDMA => true;

        public override string ChannelSuffix => this.FirstWriteType.ToString() + "Table";

        public override uint CalculateTableSize(IList<CompressedDataPoint> data)
        {
            uint count = (uint)data.Count;
            uint num = 0;
            for (int index = 0; (long)index < (long)count; ++index)
                num += (uint)data[index].Data.Count;
            return count + num;
        }

        public override TabPage CreatePropertiesPage(
          Mode0Channel sib,
          ref ColourChannelsRef channelsReference)
        {
            if (channelsReference == null)
                channelsReference = new ColourChannelsRef();
            Mode0ChannelPropertyTab propertiesPage = new Mode0ChannelPropertyTab(this, channelsReference);
            propertiesPage.Text = this.FirstWriteType.ToString();
            return (TabPage)propertiesPage;
        }

        public override void ApplySettings(TabPage propertiesPage) => ((Mode0ChannelPropertyTab)propertiesPage).ApplyChanges(this);

        public override void GetRawData(
          double[] rBuffer,
          double[] gBuffer,
          double[] bBuffer,
          DataPoint[] dataBuffer)
        {
            Generator2.CreateMode0Table(rBuffer, gBuffer, bBuffer, this.FirstWriteType, dataBuffer);
        }

        protected override void DoWriteData(IList<CompressedDataPoint> hdmaTable, CodeGen code)
        {
            for (int index1 = 0; index1 < hdmaTable.Count; ++index1)
            {
                CompressedDataPoint compressedDataPoint = hdmaTable[index1];
                if (compressedDataPoint.Data.Count > 0)
                {
                    code.AppendKeyword("db");
                    code.AppendSpace();
                    if (compressedDataPoint.Data.Count > 1)
                    {
                        code.WriteHexAddress((byte)(compressedDataPoint.Data.Count | 128));
                        for (int index2 = 0; index2 < compressedDataPoint.Data.Count; ++index2)
                        {
                            code.AppendPlainText(',');
                            code.WriteHexAddress((byte)compressedDataPoint.Data[index2].Data1);
                        }
                    }
                    else
                    {
                        code.WriteHexAddress((byte)compressedDataPoint.Count);
                        code.AppendPlainText(',');
                        code.WriteHexAddress((byte)compressedDataPoint.Data[0].Data1);
                    }
                    code.AppendLine();
                }
            }
        }
    }
}
