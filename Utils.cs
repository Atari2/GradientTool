// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.Utils
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using SFXProductions.GradientTool.HDMA;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SFXProductions.GradientTool
{
    internal static class Utils
    {
        private static Dictionary<string, string> s_records = new Dictionary<string, string>();
        private static SaveFileDialog s_saveDialog = new SaveFileDialog();

        internal static int IndexOfGradientStop(this IList<GradientStop> gradientStopList, ulong id)
        {
            for (int index = 0; index < gradientStopList.Count; ++index)
            {
                if ((long)gradientStopList[index].Id == (long)id)
                    return index;
            }
            return -1;
        }

        internal static Decimal Clamp(this Decimal value, Decimal max = 100M, Decimal min = 0M)
        {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }

        internal static double Clamp(this double value, double max = 1.0, double min = 0.0)
        {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }

        internal static int Clamp(this int value, int max, int min = 0)
        {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }

        internal static bool HasFlag(this ChannelType chType, ChannelType flag) => (chType & flag) == flag;

        internal static bool EditGradientStop(
          IWin32Window owner,
          ref GradientStop gradientStop,
          string title = null)
        {
            using (ColourSelector colourSelector = new ColourSelector())
            {
                colourSelector.SetColour(gradientStop.Colour);
                colourSelector.SetOffset(gradientStop.Position);
                if (title != null)
                    colourSelector.Text = title;
                if (colourSelector.ShowDialog(owner) == DialogResult.OK)
                {
                    gradientStop.Colour = colourSelector.GetColour();
                    gradientStop.Position = colourSelector.GetOffset();
                    return true;
                }
            }
            return false;
        }

        internal static unsafe string PromptForFilename(
          IWin32Window owner,
          string filter,
          string defaultExt,
          string defaultName = null,
          string typeId = null)
        {
            string defaultName1 = defaultName;
            string typeId1 = typeId;
            return Utils.PromptForFilename(owner, filter, defaultExt, (int*)null, defaultName1, typeId1);
        }

        internal static unsafe string PromptForFilename(
          IWin32Window owner,
          string filter,
          string defaultExt,
          int* pFilterIndex,
          string defaultName = null,
          string typeId = null)
        {
            string str = string.Empty;
            string key = typeId ?? filter;
            if (!Utils.s_records.ContainsKey(key))
                Utils.s_records.Add(key, str);
            else
                str = Utils.s_records[key];
            Utils.s_saveDialog.InitialDirectory = str;
            Utils.s_saveDialog.FileName = defaultName ?? string.Empty;
            Utils.s_saveDialog.DefaultExt = defaultExt;
            Utils.s_saveDialog.Filter = filter;
            if ((IntPtr)pFilterIndex != IntPtr.Zero && *pFilterIndex > 0)
                Utils.s_saveDialog.FilterIndex = *pFilterIndex;
            if (Utils.s_saveDialog.ShowDialog(owner) != DialogResult.OK)
                return (string)null;
            if ((IntPtr)pFilterIndex != IntPtr.Zero)
                *pFilterIndex = Utils.s_saveDialog.FilterIndex;
            Utils.s_records[filter] = Path.GetDirectoryName(Utils.s_saveDialog.FileName);
            return Utils.s_saveDialog.FileName;
        }

        internal static ushort RoundToWord(double v) => (ushort)Math.Min(v + 0.5, (double)ushort.MaxValue);

        internal static byte RoundToByte(double v) => (byte)Math.Min(v + 0.5, (double)byte.MaxValue);

        internal static void Get5BitChannels(
          this Color colour,
          out byte red,
          out byte green,
          out byte blue)
        {
            red = Utils.RoundToByte((double)colour.R * ((double)byte.MaxValue / 31.0));
            green = Utils.RoundToByte((double)colour.G * ((double)byte.MaxValue / 31.0));
            blue = Utils.RoundToByte((double)colour.B * ((double)byte.MaxValue / 31.0));
        }

        internal static Vector ToColourspace(this Color colour, GradientColourspace colourspace)
        {
            switch (colourspace)
            {
                case GradientColourspace.RGB:
                    return new Vector()
                    {
                        X = (double)colour.R / (double)byte.MaxValue,
                        Y = (double)colour.G / (double)byte.MaxValue,
                        Z = (double)colour.B / (double)byte.MaxValue
                    };
                case GradientColourspace.HSV:
                case GradientColourspace.HSL:
                case GradientColourspace.HSY:
                    return new Vector()
                    {
                        X = ((double)colour.R / (double)byte.MaxValue),
                        Y = ((double)colour.G / (double)byte.MaxValue),
                        Z = ((double)colour.B / (double)byte.MaxValue)
                    }.HDRToColourspace(colourspace);
                default:
                    throw new ArgumentException("Invalid colourspace.");
            }
        }

        internal static Vector HDRToColourspace(this Vector vector, GradientColourspace toColourspace)
        {
            switch (toColourspace)
            {
                case GradientColourspace.RGB:
                case GradientColourspace.RGBV:
                case GradientColourspace.RGBB:
                case GradientColourspace.RGBL:
                    return vector;
                case GradientColourspace.HSV:
                case GradientColourspace.HSL:
                case GradientColourspace.HSY:
                    double num1 = Math.Max(vector.X, Math.Max(vector.Y, vector.Z));
                    double num2 = Math.Min(vector.X, Math.Min(vector.Y, vector.Z));
                    if (num1 <= 0.0)
                        return new Vector()
                        {
                            X = double.NaN,
                            Y = double.NaN,
                            Z = 0.0
                        };
                    double num3 = num1 - num2;
                    double num4 = double.NaN;
                    if (num3 > 0.0)
                    {
                        if (num1 == vector.X)
                            num4 = (vector.Y - vector.Z) / num3 % 6.0;
                        else if (num1 == vector.Y)
                            num4 = (vector.Z - vector.X) / num3 + 2.0;
                        else if (num1 == vector.Z)
                            num4 = (vector.X - vector.Y) / num3 + 4.0;
                    }
                    double d = num4 / 6.0;
                    double num5 = d - Math.Floor(d);
                    switch (toColourspace)
                    {
                        case GradientColourspace.HSV:
                            return new Vector()
                            {
                                X = num5,
                                Y = num3 / num1,
                                Z = num1
                            };
                        case GradientColourspace.HSL:
                            double num6 = (num1 + num2) / 2.0;
                            return new Vector()
                            {
                                X = num5,
                                Y = num3 / (num6 <= 0.5 ? 2.0 * num6 : 2.0 - 2.0 * num6),
                                Z = num6
                            };
                        default:
                            double num7 = (vector.X + vector.Y + vector.Z) / 3.0;
                            return new Vector()
                            {
                                X = num5,
                                Y = 1.0 - 3.0 / (vector.X + vector.Y + vector.Z) * num2,
                                Z = num7
                            };
                    }
                default:
                    throw new ArgumentException("Invalid colourspace.");
            }
        }

        internal static double GetRGBValue(this Vector vector) => Math.Max(vector.X, Math.Max(vector.Y, vector.Z));

        internal static double GetRGBBrightness(this Vector vector) => (vector.X + vector.Y + vector.Z) / 3.0;

        internal static double GetRGBLightness(this Vector vector) => (Math.Max(vector.X, Math.Max(vector.Y, vector.Z)) + Math.Min(vector.X, Math.Min(vector.Y, vector.Z))) / 2.0;

        internal static Vector Adjust(this Vector vector, double orig, double @new)
        {
            if (orig == 0.0)
                return new Vector();
            double num = @new / orig;
            vector.X *= num;
            vector.Y *= num;
            vector.Z *= num;
            return vector;
        }

        private static void GetR1G1B1(
          double hue,
          double chroma,
          out double r1,
          out double g1,
          out double b1)
        {
            hue = (hue - Math.Floor(hue)) * 6.0;
            if (double.IsNaN(hue))
                hue = 0.0;
            double num = chroma * (1.0 - Math.Abs(hue % 2.0 - 1.0));
            if (double.IsNaN(hue) || double.IsNaN(chroma) || chroma <= 0.0)
                r1 = g1 = b1 = 0.0;
            else if (hue < 1.0)
            {
                r1 = chroma;
                g1 = num;
                b1 = 0.0;
            }
            else if (hue < 2.0)
            {
                r1 = num;
                g1 = chroma;
                b1 = 0.0;
            }
            else if (hue < 3.0)
            {
                r1 = 0.0;
                g1 = chroma;
                b1 = num;
            }
            else if (hue < 4.0)
            {
                r1 = 0.0;
                g1 = num;
                b1 = chroma;
            }
            else if (hue < 5.0)
            {
                r1 = num;
                g1 = 0.0;
                b1 = chroma;
            }
            else
            {
                r1 = chroma;
                g1 = 0.0;
                b1 = num;
            }
        }

        internal static Vector ToHDR(this Vector vector, GradientColourspace fromColourspace)
        {
            switch (fromColourspace)
            {
                case GradientColourspace.RGB:
                case GradientColourspace.RGBV:
                case GradientColourspace.RGBB:
                case GradientColourspace.RGBL:
                    return vector;
                case GradientColourspace.HSV:
                    double chroma = vector.Y * vector.Z;
                    double r1_1;
                    double g1_1;
                    double b1_1;
                    Utils.GetR1G1B1(vector.X, chroma, out r1_1, out g1_1, out b1_1);
                    double num1 = vector.Z - chroma;
                    r1_1 += num1;
                    double num2 = g1_1 + num1;
                    double num3 = b1_1 + num1;
                    return new Vector()
                    {
                        X = r1_1,
                        Y = num2,
                        Z = num3
                    };
                case GradientColourspace.HSL:
                    double num4 = (1.0 - Math.Abs(2.0 * vector.Z - 1.0)) * vector.Y;
                    if (double.IsNaN(num4))
                        num4 = 0.0;
                    double r1_2;
                    double g1_2;
                    double b1_2;
                    Utils.GetR1G1B1(vector.X, num4, out r1_2, out g1_2, out b1_2);
                    double num5 = vector.Z - num4 * 0.5;
                    r1_2 += num5;
                    g1_2 += num5;
                    double num6 = b1_2 + num5;
                    return new Vector()
                    {
                        X = r1_2,
                        Y = g1_2,
                        Z = num6
                    };
                case GradientColourspace.HSY:
                    return Utils.HSYToRGB(vector);
                default:
                    throw new ArgumentException("Invalid colourspace.");
            }
        }

        private static Vector HSYToRGB(Vector v)
        {
            v.X -= Math.Floor(v.X);
            v.X *= 360.0;
            Vector rgb = new Vector();
            if (0.0 < v.X && v.X <= 120.0)
            {
                rgb.Z = 1.0 / 3.0 * (1.0 - v.Y);
                rgb.X = 1.0 / 3.0 * (1.0 + v.Y * Math.Cos(v.X) / Math.Cos(60.0 - v.X));
                rgb.Y = 1.0 - (rgb.X + rgb.Z);
            }
            else if (120.0 < v.X && v.X <= 240.0)
            {
                v.X -= 120.0;
                rgb.X = 1.0 / 3.0 * (1.0 - v.Y);
                rgb.Y = 1.0 / 3.0 * (1.0 + v.Y * Math.Cos(v.X) / Math.Cos(60.0 - v.X));
                rgb.Z = 1.0 - (rgb.X + rgb.Y);
            }
            else
            {
                v.X -= 240.0;
                rgb.Y = 1.0 / 3.0 * (1.0 - v.Y);
                rgb.Z = 1.0 / 3.0 * (1.0 + v.Y * Math.Cos(v.X) / Math.Cos(60.0 - v.X));
                rgb.X = 1.0 - (rgb.Y + rgb.Z);
            }
            return rgb;
        }

        internal static Color ToRGB(this Vector vector, GradientColourspace fromColourspace)
        {
            switch (fromColourspace)
            {
                case GradientColourspace.RGB:
                    return Color.FromArgb((int)Utils.RoundToByte(vector.X * (double)byte.MaxValue), (int)Utils.RoundToByte(vector.Y * (double)byte.MaxValue), (int)Utils.RoundToByte(vector.Z * (double)byte.MaxValue));
                case GradientColourspace.HSV:
                case GradientColourspace.HSL:
                case GradientColourspace.HSY:
                    vector = vector.ToHDR(fromColourspace);
                    return Color.FromArgb((int)Utils.RoundToByte(vector.X * (double)byte.MaxValue), (int)Utils.RoundToByte(vector.Y * (double)byte.MaxValue), (int)Utils.RoundToByte(vector.Z * (double)byte.MaxValue));
                default:
                    throw new ArgumentException("Invalid colourspace.");
            }
        }
    }
}
