// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HDMA.Generator2
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System;
using System.Collections.Generic;

namespace SFXProductions.GradientTool.HDMA
{
    internal static class Generator2
    {
        private const int c_col2 = 5;
        private const int REG_43x0 = 17152;
        private const int REG_43x2 = 17154;
        private const int REG_43x4 = 17156;
        private const string c_defaultName = "Gradient";

        private static ushort ApplyChannelFlag(int n, ChannelType flag) => (ushort)((ChannelType)n | flag);

        private static ushort GetNormalModeDataValue(
          double r,
          double g,
          double b,
          ChannelType channels)
        {
            int num1 = 0;
            double num2 = 0.0;
            bool flag;
            if ((flag = channels == ChannelType.Brightness) || channels == ChannelType.Grey)
            {
                num2 = r + g + b;
                num1 = 3;
            }
            else
            {
                if ((channels & ChannelType.Red) == ChannelType.Red)
                {
                    num2 += r;
                    ++num1;
                }
                if ((channels & ChannelType.Green) == ChannelType.Green)
                {
                    num2 += g;
                    ++num1;
                }
                if ((channels & ChannelType.Blue) == ChannelType.Blue)
                {
                    num2 += b;
                    ++num1;
                }
            }
            return Generator2.ApplyChannelFlag(Generator2.GetV5(num2 / (double)num1, flag ? 15 : 31), channels);
        }

        private static int GetV5(double v, int range = 31) => (int)(v.Clamp() * (double)range + 0.5);

        private static ushort GetRGBChannelValue(double r, double g, double b) => (ushort)(Generator2.GetV5(r) | Generator2.GetV5(g) << 5 | Generator2.GetV5(b) << 10);

        internal static void CreateMode0Table(
          double[] chR,
          double[] chG,
          double[] chB,
          ChannelType channels,
          DataPoint[] result)
        {
            for (int index = 0; index < result.Length; ++index)
                result[index] = new DataPoint()
                {
                    Data1 = Generator2.GetNormalModeDataValue(chR[index], chG[index], chB[index], channels)
                };
        }

        internal static void CreateMode2Table(
          double[] chR,
          double[] chG,
          double[] chB,
          ChannelType ch1,
          ChannelType ch2,
          DataPoint[] result)
        {
            for (int index = 0; index < result.Length; ++index)
            {
                double r = chR[index];
                double g = chG[index];
                double b = chB[index];
                result[index] = new DataPoint()
                {
                    Data1 = Generator2.GetNormalModeDataValue(r, g, b, ch1),
                    Data2 = Generator2.GetNormalModeDataValue(r, g, b, ch2)
                };
            }
        }

        internal static void CreateScrollingTable(
          double[] chR,
          double[] chG,
          double[] chB,
          DataPoint[] result)
        {
            for (int index = 0; index < result.Length; ++index)
            {
                double v1 = chR[index];
                double v2 = chG[index];
                double v3 = chB[index];
                result[index] = new DataPoint()
                {
                    Data1 = Generator2.ApplyChannelFlag(Generator2.GetV5(v1), ChannelType.Red),
                    Data2 = Generator2.ApplyChannelFlag(Generator2.GetV5(v2), ChannelType.Green),
                    Data3 = Generator2.ApplyChannelFlag(Generator2.GetV5(v3), ChannelType.Blue)
                };
            }
        }

        internal static void CreateMode1Table(
          double[] chR,
          double[] chG,
          double[] chB,
          ushort paletteIndex,
          DataPoint[] result)
        {
            for (int index = 0; index < result.Length; ++index)
            {
                double r = chR[index];
                double g = chG[index];
                double b = chB[index];
                result[index] = new DataPoint()
                {
                    Data1 = paletteIndex,
                    Data2 = Generator2.GetRGBChannelValue(r, g, b)
                };
            }
        }

        private static void DoNormalMode(
          ref int srcI,
          DataPoint[] src,
          List<CompressedDataPoint> dst,
          bool allowCountAbove128)
        {
            DataPoint dataPoint = src[srcI];
            CompressedDataPoint compressedDataPoint = new CompressedDataPoint(dataPoint);
            for (int index = srcI + 1; index < src.Length && src[index] == dataPoint && (allowCountAbove128 && compressedDataPoint.Count < (int)byte.MaxValue || compressedDataPoint.Count < 128); ++index)
                ++compressedDataPoint.Count;
            dst.Add(compressedDataPoint);
            srcI += compressedDataPoint.Count;
        }

        private static bool CheckForContinuousMode(
          ref int srcI,
          DataPoint[] src,
          List<CompressedDataPoint> dst)
        {
            if (srcI + 2 >= src.Length || !(src[srcI] != src[srcI + 1]) || srcI + 3 >= src.Length || !(src[srcI + 1] != src[srcI + 2]))
                return false;
            CompressedDataPoint compressedDataPoint = new CompressedDataPoint(src[srcI]);
            for (int index = srcI + 1; compressedDataPoint.Data.Count < (int)sbyte.MaxValue && index < src.Length; ++index)
            {
                DataPoint dataPoint = src[index];
                if (index + 2 >= src.Length || dataPoint != src[index + 1])
                    compressedDataPoint.Data.Add(dataPoint);
                else
                    break;
            }
            dst.Add(compressedDataPoint);
            srcI += compressedDataPoint.Data.Count;
            return true;
        }

        private static List<CompressedDataPoint> CompressTable(
          DataPoint[] dataPoints,
          bool canUseContinuousMode)
        {
            List<CompressedDataPoint> dst = new List<CompressedDataPoint>();
            int srcI = 0;
            while (srcI < dataPoints.Length)
            {
                if (!canUseContinuousMode || !Generator2.CheckForContinuousMode(ref srcI, dataPoints, dst))
                    Generator2.DoNormalMode(ref srcI, dataPoints, dst, false);
            }
            return dst;
        }

        internal static int GetNChannels(GradientChannels channels)
        {
            switch (channels)
            {
                case GradientChannels.RedGreenBlue:
                    return 3;
                case GradientChannels.RedGreen:
                case GradientChannels.GreenBlue:
                case GradientChannels.RedBlue:
                case GradientChannels.CyanRed:
                case GradientChannels.YellowBlue:
                case GradientChannels.MagentaGreen:
                    return 2;
                case GradientChannels.Red:
                case GradientChannels.Green:
                case GradientChannels.Blue:
                case GradientChannels.Cyan:
                case GradientChannels.Yellow:
                case GradientChannels.Magenta:
                case GradientChannels.Grey:
                case GradientChannels.Brightness:
                    return 1;
                default:
                    throw new ArgumentException("Invalid channels.");
            }
        }

        internal static ChannelType GetChannel(GradientChannels channels, int index)
        {
            switch (channels)
            {
                case GradientChannels.RedGreenBlue:
                    if (index == 0)
                        return ChannelType.Red;
                    return index != 1 ? ChannelType.Blue : ChannelType.Green;
                case GradientChannels.RedGreen:
                    return index != 0 ? ChannelType.Green : ChannelType.Red;
                case GradientChannels.GreenBlue:
                    return index != 0 ? ChannelType.Blue : ChannelType.Green;
                case GradientChannels.RedBlue:
                    return index != 0 ? ChannelType.Blue : ChannelType.Red;
                case GradientChannels.CyanRed:
                    return index != 0 ? ChannelType.Red : ChannelType.Cyan;
                case GradientChannels.YellowBlue:
                    return index != 0 ? ChannelType.Blue : ChannelType.Yellow;
                case GradientChannels.MagentaGreen:
                    return index != 0 ? ChannelType.Green : ChannelType.Magenta;
                case GradientChannels.Red:
                    return ChannelType.Red;
                case GradientChannels.Green:
                    return ChannelType.Green;
                case GradientChannels.Blue:
                    return ChannelType.Blue;
                case GradientChannels.Cyan:
                    return ChannelType.Cyan;
                case GradientChannels.Yellow:
                    return ChannelType.Yellow;
                case GradientChannels.Magenta:
                    return ChannelType.Magenta;
                case GradientChannels.Grey:
                    return ChannelType.Grey;
                case GradientChannels.Brightness:
                    return ChannelType.Brightness;
                default:
                    throw new ArgumentException("Invalid channels.");
            }
        }

        public static void GenerateCode(
          double[] rBuffer,
          double[] gBuffer,
          double[] bBuffer,
          Settings2 settings,
          CodeGen code)
        {
            uint size = 0;
            List<CompressedDataPoint> outTable1 = (List<CompressedDataPoint>)null;
            List<CompressedDataPoint> outTable2 = (List<CompressedDataPoint>)null;
            List<CompressedDataPoint> outTable3 = (List<CompressedDataPoint>)null;
            DataPoint[] tmpBuffer = new DataPoint[rBuffer.Length];
            Generator2.DoChan(settings.Channel1, rBuffer, gBuffer, bBuffer, tmpBuffer, ref size, ref outTable1);
            Generator2.DoChan(settings.Channel2, rBuffer, gBuffer, bBuffer, tmpBuffer, ref size, ref outTable2);
            Generator2.DoChan(settings.Channel3, rBuffer, gBuffer, bBuffer, tmpBuffer, ref size, ref outTable3);
            code.WriteBanner();
            code.WriteComment(settings.GetGradientTypeBanner());
            code.WriteComment("Channels: " + GradientChannelsHelper.GetChannelString(settings.Channels));
            code.WriteComment("Table Size: " + size.ToString("N0"));
            code.WriteComment("No. of Writes: " + rBuffer.Length.ToString("N0"));
            code.WriteComment();
            code.WriteComment("Generated by GradientTool");
            code.WriteBanner();
            Generator2.WriteActivator(settings, code);
            string gradientName = settings.Name ?? "Gradient";
            Generator2.WriteChan(settings.Channel1, outTable1, code, gradientName);
            Generator2.WriteChan(settings.Channel2, outTable2, code, gradientName);
            Generator2.WriteChan(settings.Channel3, outTable3, code, gradientName);
        }

        private static void DoChan(
          Channel chan,
          double[] rBuffer,
          double[] gBuffer,
          double[] bBuffer,
          DataPoint[] tmpBuffer,
          ref uint size,
          ref List<CompressedDataPoint> outTable)
        {
            if (chan == null)
                return;
            chan.GetRawData(rBuffer, gBuffer, bBuffer, tmpBuffer);
            outTable = Generator2.CompressTable(tmpBuffer, chan.CanUseContinuousMode);
            size += chan.CalculateTableSize((IList<CompressedDataPoint>)outTable) + 1U;
        }

        private static void WriteChan(
          Channel chan,
          List<CompressedDataPoint> table,
          CodeGen code,
          string gradientName)
        {
            if (chan == null)
                return;
            code.AppendLine();
            chan.WriteData((IList<CompressedDataPoint>)table, code, gradientName);
        }

        private static void WriteActivator(Settings2 settings, CodeGen code)
        {
            if (!settings.GenerateInitializationCode)
                return;
            code.AppendLine();
            if (settings.Channel1 is CombinedChannel)
            {
                code.WriteComment("GradientTool doesn’t generate the code");
                code.WriteComment("to initialize scrolling gradients.");
                code.WriteComment();
                code.WriteComment("See the ASM files in the folder titled");
                code.WriteComment("Example, located in the same folder as");
                code.WriteComment("GradientTool.");
            }
            else if (settings.Channel1 is Mode3Channel)
                Generator2.WriteActivatorInternal(settings, (ushort)8451, (ushort)8451, (ushort)8451, code);
            else if (settings.Channel1 is Mode0Channel)
            {
                ushort num = settings.Channels != GradientChannels.Brightness ? (ushort)12800 : (ushort)0;
                Generator2.WriteActivatorInternal(settings, num, num, num, code);
            }
            else if (settings.Channel1 is Mode2Channel)
            {
                Generator2.WriteActivatorInternal(settings, (ushort)12802, (ushort)12800, (ushort)12800, code);
            }
            else
            {
                code.WriteComment("Something went wrong and the type of");
                code.WriteComment("HDMA gradient being generated couldn’t");
                code.WriteComment("be determined.");
            }
        }

        private static void WriteActivatorInternal(
          Settings2 settings,
          ushort transferMode0,
          ushort transferMode1,
          ushort transferMode2,
          CodeGen code)
        {
            string chans = Generator2.GetChans(settings);
            code.WriteComment("Set up the HDMA gradient.");
            code.WriteComment("Uses HDMA " + chans + (object)'.');
            code.AppendLabel("Init" + (settings.Name ?? "Gradient"));
            code.AppendPlainText(':');
            code.AppendLine();
            code.Write16BitMode(5);
            code.AppendLine();
            code.WriteComment("Set transfer modes.", (true ? 1 : 0) != 0);
            code.WriteLDAIfNonzero(transferMode0, 5);
            CodeGen codeGen1 = code;
            int num1 = 5;
            string chanStr1 = Generator2.GetChanStr(settings.Channel1);
            int register1 = (int)Generator2.GetRegister(17152, settings.Channel1);
            int num2 = (int)transferMode0;
            int w1 = num1;
            string comment1 = chanStr1;
            codeGen1.WriteSTAIfNonzero((ushort)register1, (ushort)num2, w1, comment1);
            if (settings.Channel2 != null)
            {
                if ((int)transferMode1 != (int)transferMode0)
                {
                    CodeGen codeGen2 = code;
                    int num3 = 5;
                    int num4 = (int)transferMode1;
                    int w2 = num3;
                    codeGen2.WriteLDAIfNonzero((ushort)num4, w2);
                }
                CodeGen codeGen3 = code;
                int num5 = 5;
                string chanStr2 = Generator2.GetChanStr(settings.Channel2);
                int register2 = (int)Generator2.GetRegister(17152, settings.Channel2);
                int num6 = (int)transferMode1;
                int w3 = num5;
                string comment2 = chanStr2;
                codeGen3.WriteSTAIfNonzero((ushort)register2, (ushort)num6, w3, comment2);
                if (settings.Channel3 != null)
                {
                    if ((int)transferMode2 != (int)transferMode1)
                    {
                        CodeGen codeGen4 = code;
                        int num7 = 5;
                        int num8 = (int)transferMode2;
                        int w4 = num7;
                        codeGen4.WriteLDAIfNonzero((ushort)num8, w4);
                    }
                    CodeGen codeGen5 = code;
                    int num9 = 5;
                    string chanStr3 = Generator2.GetChanStr(settings.Channel3);
                    int register3 = (int)Generator2.GetRegister(17152, settings.Channel3);
                    int num10 = (int)transferMode2;
                    int w5 = num9;
                    string comment3 = chanStr3;
                    codeGen5.WriteSTAIfNonzero((ushort)register3, (ushort)num10, w5, comment3);
                }
            }
            code.AppendLine();
            code.WriteComment("Point to HDMA tables.", (true ? 1 : 0) != 0);
            Generator2.WriteChanSourceLoader(settings.Channel1, settings.Name, code);
            Generator2.WriteChanSourceLoader(settings.Channel2, settings.Name, code);
            Generator2.WriteChanSourceLoader(settings.Channel3, settings.Name, code);
            code.AppendLine();
            code.Write8BitMode(5);
            code.AppendLine();
            code.WriteComment("Store program bank to $43x4.", (true ? 1 : 0) != 0);
            code.WriteKeywordLine("PHK");
            code.WriteKeywordLine("PLA");
            Generator2.WriteChanBankLoader(settings.Channel1, code);
            Generator2.WriteChanBankLoader(settings.Channel2, code);
            Generator2.WriteChanBankLoader(settings.Channel3, code);
            code.AppendLine();
            CodeGen codeGen6 = code;
            bool flag = true;
            string comment4 = "Enable " + chans + (object)'.';
            int num11 = flag ? 1 : 0;
            codeGen6.WriteComment(comment4, num11 != 0);
            code.WriteLDA_b_c_bin(Generator2.GetHDMAFlags(settings), 5);
            code.WriteTSB((ushort)3487, 5);
            code.AppendLine();
            code.AppendHardTab();
            code.AppendKeyword("RTS");
            code.WriteComment("<-- Can also be RTL.", space: (true ? 1 : 0) != 0);
            code.AppendLine();
            code.AppendComment("; --- HDMA Tables below this line ---");
        }

        private static string GetChans(Settings2 settings)
        {
            if (settings.Channel2 == null)
                return "channel " + settings.Channel1.HDMAChannel.ToString();
            return settings.Channel3 != null ? string.Format("channels {0}, {1}, and {2}", (object)settings.Channel1.HDMAChannel, (object)settings.Channel2.HDMAChannel, (object)settings.Channel3.HDMAChannel) : string.Format("channels {0} and {1}", (object)settings.Channel1.HDMAChannel, (object)settings.Channel2.HDMAChannel);
        }

        private static string GetChanStr(Channel channel) => "Channel " + channel.HDMAChannel.ToString();

        private static ushort GetRegister(int reg, int channel) => (ushort)(reg | (channel & 7) << 4);

        private static ushort GetRegister(int reg, Channel channel) => (ushort)(reg | (channel.HDMAChannel & 7) << 4);

        private static byte GetHDMAFlags(Settings2 settings)
        {
            int hdmaFlags = 1 << (settings.Channel1.HDMAChannel & 7);
            if (settings.Channel2 != null)
            {
                hdmaFlags |= 1 << (settings.Channel2.HDMAChannel & 7);
                if (settings.Channel3 != null)
                    hdmaFlags |= 1 << (settings.Channel3.HDMAChannel & 7);
            }
            return (byte)hdmaFlags;
        }

        private static void WriteChanSourceLoader(Channel channel, string gradientName, CodeGen code)
        {
            if (channel == null)
                return;
            string channelLabel = channel.GetChannelLabel(gradientName ?? "Gradient");
            CodeGen codeGen1 = code;
            int num1 = 5;
            string label = channelLabel;
            int w1 = num1;
            codeGen1.WriteLDA_Label(label, w1);
            CodeGen codeGen2 = code;
            int num2 = 5;
            int register = (int)Generator2.GetRegister(17154, channel);
            int w2 = num2;
            codeGen2.WriteSTA((ushort)register, w2, (string)null, true);
        }

        private static void WriteChanBankLoader(Channel channel, CodeGen code)
        {
            if (channel == null)
                return;
            CodeGen codeGen = code;
            int num = 5;
            string chanStr = Generator2.GetChanStr(channel);
            int register = (int)Generator2.GetRegister(17156, channel);
            int w = num;
            string comment = chanStr;
            codeGen.WriteSTA((ushort)register, w, comment, true);
        }
    }
}
