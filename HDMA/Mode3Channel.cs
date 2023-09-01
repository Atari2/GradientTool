// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HDMA.Mode3Channel
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using SFXProductions.GradientTool.HDMA.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SFXProductions.GradientTool.HDMA
{
    internal sealed class Mode3Channel : Channel
    {
        public byte PaletteIndex { get; set; }

        public override bool HasSecondWrite => false;

        public override bool IsBackgroundOrBrightnessHDMA => false;

        public override string ChannelSuffix => "Table";

        public override uint CalculateTableSize(IList<CompressedDataPoint> data)
        {
            uint count = (uint)data.Count;
            uint num = 0;
            for (int index = 0; (long)index < (long)count; ++index)
                num += (uint)(data[index].Data.Count * 4);
            return count + num;
        }

        public override TabPage CreatePropertiesPage(
          Mode0Channel sib,
          ref ColourChannelsRef channelsReference)
        {
            Mode3ChannelPropertyTab propertiesPage = new Mode3ChannelPropertyTab(this);
            propertiesPage.Text = "Channel";
            return (TabPage)propertiesPage;
        }

        public override void ApplySettings(TabPage propertiesPage) => ((Mode3ChannelPropertyTab)propertiesPage).ApplyChanges(this);

        public override void GetRawData(
          double[] rBuffer,
          double[] gBuffer,
          double[] bBuffer,
          DataPoint[] dataBuffer)
        {
            Generator2.CreateMode1Table(rBuffer, gBuffer, bBuffer, (ushort)((uint)this.PaletteIndex << 8), dataBuffer);
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
                        code.AppendSpace();
                        code.AppendPlainText(':');
                        code.AppendSpace();
                        code.AppendKeyword("dw");
                        code.AppendSpace();
                        code.WriteHexAddress(compressedDataPoint.Data[0].Data1);
                        code.AppendPlainText(',');
                        code.WriteHexAddress(compressedDataPoint.Data[0].Data2);
                        for (int index2 = 1; index2 < compressedDataPoint.Data.Count; ++index2)
                        {
                            code.AppendPlainText(',');
                            code.WriteHexAddress(compressedDataPoint.Data[index2].Data1);
                            code.AppendPlainText(',');
                            code.WriteHexAddress(compressedDataPoint.Data[index2].Data2);
                        }
                    }
                    else
                    {
                        code.WriteHexAddress((byte)compressedDataPoint.Count);
                        code.AppendSpace();
                        code.AppendPlainText(':');
                        code.AppendSpace();
                        code.AppendKeyword("dw");
                        code.AppendSpace();
                        code.WriteHexAddress(compressedDataPoint.Data[0].Data1);
                        code.AppendPlainText(',');
                        code.WriteHexAddress(compressedDataPoint.Data[0].Data2);
                    }
                    code.AppendLine();
                }
            }
        }
    }
}
