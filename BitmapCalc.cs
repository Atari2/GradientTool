// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.BitmapCalc
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using SFXProductions.GradientTool.HDMA;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace SFXProductions.GradientTool
{
    internal static class BitmapCalc
    {
        public static unsafe void Fill48BppBitmap(
          this Bitmap bmp,
          double[] r,
          double[] g,
          double[] b,
          bool addPadding = true)
        {
            BitmapData bitmapdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format48bppRgb);
            try
            {
                ushort* scan0 = (ushort*)(void*)bitmapdata.Scan0;
                ushort* numPtr1 = scan0 + (addPadding ? (IntPtr)bitmapdata.Stride : IntPtr.Zero).ToInt64();
                ushort num1 = 0;
                ushort num2 = 0;
                ushort num3 = 0;
                for (int index1 = 0; index1 < r.Length; ++index1)
                {
                    ushort* numPtr2 = numPtr1;
                    for (int index2 = 0; index2 < bitmapdata.Width; ++index2)
                    {
                        ushort* numPtr3 = numPtr2;
                        ushort* numPtr4 = (ushort*)((IntPtr)numPtr3 + new IntPtr(2));
                        int word1;
                        ushort num4 = (ushort)(word1 = (int)Utils.RoundToWord(b[index1].Clamp() * (double)ushort.MaxValue));
                        *numPtr3 = (ushort)word1;
                        num3 = num4;
                        ushort* numPtr5 = numPtr4;
                        ushort* numPtr6 = (ushort*)((IntPtr)numPtr5 + new IntPtr(2));
                        int word2;
                        ushort num5 = (ushort)(word2 = (int)Utils.RoundToWord(g[index1].Clamp() * (double)ushort.MaxValue));
                        *numPtr5 = (ushort)word2;
                        num2 = num5;
                        ushort* numPtr7 = numPtr6;
                        numPtr2 = (ushort*)((IntPtr)numPtr7 + new IntPtr(2));
                        int word3;
                        ushort num6 = (ushort)(word3 = (int)Utils.RoundToWord(r[index1].Clamp() * (double)ushort.MaxValue));
                        *numPtr7 = (ushort)word3;
                        num1 = num6;
                    }
                    numPtr1 += bitmapdata.Stride;
                }
                if (!addPadding)
                    return;
                *numPtr1 = (ushort)(*(short*)(numPtr1 + 3) = (short)num3);
                numPtr1[1] = (ushort)(*(short*)(numPtr1 + 4) = (short)num2);
                numPtr1[2] = (ushort)(*(short*)(numPtr1 + 5) = (short)num1);
                ushort* numPtr8 = scan0 + bitmapdata.Stride;
                *scan0 = (ushort)(*(short*)(scan0 + 3) = (short)*numPtr8);
                scan0[1] = (ushort)(*(short*)(scan0 + 4) = (short)numPtr8[1]);
                scan0[2] = (ushort)(*(short*)(scan0 + 5) = (short)numPtr8[2]);
            }
            finally
            {
                bmp.UnlockBits(bitmapdata);
            }
        }

        public static unsafe void Fill24BppBitmap(
          this Bitmap bmp,
          double[] r,
          double[] g,
          double[] b,
          bool addPadding = true)
        {
            BitmapData bitmapdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            try
            {
                byte* scan0 = (byte*)(void*)bitmapdata.Scan0;
                byte* numPtr1 = scan0 + (addPadding ? bitmapdata.Stride : 0);
                byte num1 = 0;
                byte num2 = 0;
                byte num3 = 0;
                for (int index1 = 0; index1 < r.Length; ++index1)
                {
                    byte* numPtr2 = numPtr1;
                    for (int index2 = 0; index2 < bitmapdata.Width; ++index2)
                    {
                        byte* numPtr3 = numPtr2;
                        byte* numPtr4 = numPtr3 + 1;
                        int num4;
                        byte num5 = (byte)(num4 = (int)Utils.RoundToByte(b[index1].Clamp() * (double)byte.MaxValue));
                        *numPtr3 = (byte)num4;
                        num3 = num5;
                        byte* numPtr5 = numPtr4;
                        byte* numPtr6 = numPtr5 + 1;
                        int num6;
                        byte num7 = (byte)(num6 = (int)Utils.RoundToByte(g[index1].Clamp() * (double)byte.MaxValue));
                        *numPtr5 = (byte)num6;
                        num2 = num7;
                        byte* numPtr7 = numPtr6;
                        numPtr2 = numPtr7 + 1;
                        int num8;
                        byte num9 = (byte)(num8 = (int)Utils.RoundToByte(r[index1].Clamp() * (double)byte.MaxValue));
                        *numPtr7 = (byte)num8;
                        num1 = num9;
                    }
                    numPtr1 += bitmapdata.Stride;
                }
                if (!addPadding)
                    return;
                *numPtr1 = (byte)(*(sbyte*)(numPtr1 + 3) = (sbyte)num3);
                numPtr1[1] = (byte)(*(sbyte*)(numPtr1 + 4) = (sbyte)num2);
                numPtr1[2] = (byte)(*(sbyte*)(numPtr1 + 5) = (sbyte)num1);
                byte* numPtr8 = scan0 + bitmapdata.Stride;
                *scan0 = (byte)(*(sbyte*)(scan0 + 3) = (sbyte)*numPtr8);
                scan0[1] = (byte)(*(sbyte*)(scan0 + 4) = (sbyte)numPtr8[1]);
                scan0[2] = (byte)(*(sbyte*)(scan0 + 5) = (sbyte)numPtr8[2]);
            }
            finally
            {
                bmp.UnlockBits(bitmapdata);
            }
        }

        private static double Combine(double v, double x, double y, Combiner combiner)
        {
            switch (combiner)
            {
                case Combiner.Normal:
                    return v;
                case Combiner.AverageWithX:
                    return (v + x) / 2.0;
                case Combiner.AverageWithY:
                    return (v + y) / 2.0;
                default:
                    return 0.0;
            }
        }

        public static void Fill15BppBitmap(
          this Bitmap bmp,
          double[] r,
          double[] g,
          double[] b,
          GradientChannels channels)
        {
            switch (channels)
            {
                case GradientChannels.RedGreenBlue:
                    bmp.Fill15BppBitmap(r, g, b, Combiner.Normal, Combiner.Normal, Combiner.Normal);
                    break;
                case GradientChannels.RedGreen:
                    bmp.Fill15BppBitmap(r, g, b, Combiner.Normal, Combiner.Normal, Combiner.Drop);
                    break;
                case GradientChannels.GreenBlue:
                    bmp.Fill15BppBitmap(r, g, b, Combiner.Drop, Combiner.Normal, Combiner.Normal);
                    break;
                case GradientChannels.RedBlue:
                    bmp.Fill15BppBitmap(r, g, b, Combiner.Normal, Combiner.Drop, Combiner.Normal);
                    break;
                case GradientChannels.CyanRed:
                    bmp.Fill15BppBitmap(r, g, b, Combiner.Normal, Combiner.AverageWithY, Combiner.AverageWithY);
                    break;
                case GradientChannels.YellowBlue:
                    bmp.Fill15BppBitmap(r, g, b, Combiner.AverageWithX, Combiner.AverageWithX, Combiner.Normal);
                    break;
                case GradientChannels.MagentaGreen:
                    bmp.Fill15BppBitmap(r, g, b, Combiner.AverageWithY, Combiner.Normal, Combiner.AverageWithX);
                    break;
                case GradientChannels.Red:
                    bmp.Fill15BppBitmap(r, g, b, Combiner.Normal, Combiner.Drop, Combiner.Drop);
                    break;
                case GradientChannels.Green:
                    bmp.Fill15BppBitmap(r, g, b, Combiner.Drop, Combiner.Normal, Combiner.Drop);
                    break;
                case GradientChannels.Blue:
                    bmp.Fill15BppBitmap(r, g, b, Combiner.Drop, Combiner.Drop, Combiner.Normal);
                    break;
                case GradientChannels.Cyan:
                    bmp.Fill15BppBitmap(r, g, b, Combiner.Drop, Combiner.AverageWithY, Combiner.AverageWithY);
                    break;
                case GradientChannels.Yellow:
                    bmp.Fill15BppBitmap(r, g, b, Combiner.AverageWithX, Combiner.AverageWithX, Combiner.Drop);
                    break;
                case GradientChannels.Magenta:
                    bmp.Fill15BppBitmap(r, g, b, Combiner.AverageWithY, Combiner.Drop, Combiner.AverageWithX);
                    break;
                case GradientChannels.Grey:
                    bmp.Fill15BppBitmapGreyscale(r, g, b);
                    break;
                case GradientChannels.Brightness:
                    break;
                default:
                    throw new ArgumentException("Invalid gradient channels.");
            }
        }

        public static unsafe void Fill15BppBitmap(
          this Bitmap bmp,
          double[] r,
          double[] g,
          double[] b,
          Combiner redCombiner,
          Combiner greenCombiner,
          Combiner blueCombiner)
        {
            BitmapData bitmapdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format16bppRgb555);
            try
            {
                byte* scan0 = (byte*)(void*)bitmapdata.Scan0;
                for (int index1 = 0; index1 < r.Length; ++index1)
                {
                    double num1 = BitmapCalc.Combine(r[index1], g[index1], b[index1], redCombiner).Clamp();
                    double num2 = BitmapCalc.Combine(g[index1], r[index1], b[index1], greenCombiner).Clamp();
                    double num3 = BitmapCalc.Combine(b[index1], r[index1], g[index1], blueCombiner).Clamp();
                    ushort* numPtr = (ushort*)scan0;
                    for (int index2 = 0; index2 < bitmapdata.Width; ++index2)
                        *numPtr++ = (ushort)((int)Utils.RoundToByte(num3 * 31.0) | (int)Utils.RoundToByte(num2 * 31.0) << 5 | (int)Utils.RoundToByte(num1 * 31.0) << 10);
                    scan0 += bitmapdata.Stride;
                }
            }
            finally
            {
                bmp.UnlockBits(bitmapdata);
            }
        }

        public static unsafe void Fill15BppBitmapGreyscale(
          this Bitmap bmp,
          double[] r,
          double[] g,
          double[] b)
        {
            BitmapData bitmapdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format16bppRgb555);
            try
            {
                byte* scan0 = (byte*)(void*)bitmapdata.Scan0;
                for (int index1 = 0; index1 < r.Length; ++index1)
                {
                    double max = 3.0;
                    byte num = Utils.RoundToByte((r[index1] + g[index1] + b[index1]).Clamp(max) * (31.0 / 3.0));
                    ushort* numPtr = (ushort*)scan0;
                    for (int index2 = 0; index2 < bitmapdata.Width; ++index2)
                        *numPtr++ = (ushort)((int)num | (int)num << 5 | (int)num << 10);
                    scan0 += bitmapdata.Stride;
                }
            }
            finally
            {
                bmp.UnlockBits(bitmapdata);
            }
        }

        public static unsafe void Fill4BppBitmap(this Bitmap bmp, double[] r, double[] g, double[] b)
        {
            BitmapData bitmapdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format4bppIndexed);
            try
            {
                byte* scan0 = (byte*)(void*)bitmapdata.Scan0;
                for (int index1 = 0; index1 < r.Length; ++index1)
                {
                    double max = 3.0;
                    byte num = Utils.RoundToByte((r[index1] + g[index1] + b[index1]).Clamp(max) * 5.0);
                    byte* numPtr = scan0;
                    for (int index2 = 0; index2 < bitmapdata.Stride; ++index2)
                        *numPtr++ = (byte)((uint)num | (uint)num << 4);
                    scan0 += bitmapdata.Stride;
                }
            }
            finally
            {
                bmp.UnlockBits(bitmapdata);
            }
        }
    }
}
