// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HDMA.CombinedChannel
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using SFXProductions.GradientTool.HDMA.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SFXProductions.GradientTool.HDMA
{
    internal sealed class CombinedChannel : Channel
    {
        public override bool CanUseContinuousMode => false;

        public override bool HasSecondWrite => false;

        public override bool IsBackgroundOrBrightnessHDMA => false;

        public override string ChannelSuffix => "Table";

        public override uint CalculateTableSize(IList<CompressedDataPoint> data)
        {
            uint count = (uint)data.Count;
            return count + count * 3U;
        }

        public override TabPage CreatePropertiesPage(
          Mode0Channel sib,
          ref ColourChannelsRef channelsReference)
        {
            UnconfigurablePropertyTab propertiesPage = new UnconfigurablePropertyTab();
            propertiesPage.Message = "GradientTool doesn’t generate initialization code for scrolling gradients.";
            propertiesPage.Text = "Channel";
            return (TabPage)propertiesPage;
        }

        public override void ApplySettings(TabPage propertiesPage)
        {
        }

        public override void GetRawData(
          double[] rBuffer,
          double[] gBuffer,
          double[] bBuffer,
          DataPoint[] dataBuffer)
        {
            Generator2.CreateScrollingTable(rBuffer, gBuffer, bBuffer, dataBuffer);
        }

        protected override void DoWriteData(IList<CompressedDataPoint> hdmaTable, CodeGen code)
        {
            for (int index = 0; index < hdmaTable.Count; ++index)
            {
                CompressedDataPoint compressedDataPoint = hdmaTable[index];
                if (compressedDataPoint.Data.Count > 0)
                {
                    code.AppendKeyword("db");
                    code.AppendSpace();
                    code.WriteHexAddress((byte)compressedDataPoint.Count);
                    code.AppendPlainText(',');
                    code.WriteHexAddress((byte)compressedDataPoint.Data[0].Data1);
                    code.AppendPlainText(',');
                    code.WriteHexAddress((byte)compressedDataPoint.Data[0].Data2);
                    code.AppendPlainText(',');
                    code.WriteHexAddress((byte)compressedDataPoint.Data[0].Data3);
                    code.AppendLine();
                }
            }
        }
    }
}
