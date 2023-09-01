// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.Vector
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System;

namespace SFXProductions.GradientTool
{
    internal struct Vector
    {
        public double X;
        public double Y;
        public double Z;

        public static Vector LerpRGB(Vector a, Vector b, double x, GradientColourspace gamma)
        {
            if (x > 1.0)
                x = 1.0;
            else if (x < 0.0)
                x = 0.0;
            double num = 1.0 - x;
            Vector vector;
            vector.X = a.X * num + b.X * x;
            vector.Y = a.Y * num + b.Y * x;
            vector.Z = a.Z * num + b.Z * x;
            switch (gamma)
            {
                case GradientColourspace.RGBV:
                    vector = vector.Adjust(vector.GetRGBValue(), a.GetRGBValue() * num + b.GetRGBValue() * x);
                    break;
                case GradientColourspace.RGBB:
                    vector = vector.Adjust(vector.GetRGBBrightness(), a.GetRGBBrightness() * num + b.GetRGBBrightness() * x);
                    break;
                case GradientColourspace.RGBL:
                    vector = vector.Adjust(vector.GetRGBLightness(), a.GetRGBLightness() * num + b.GetRGBLightness() * x);
                    break;
            }
            return vector;
        }

        public static Vector LerpH(Vector a, Vector b, double x)
        {
            if (x > 1.0)
                x = 1.0;
            else if (x < 0.0)
                x = 0.0;
            double num1 = 1.0 - x;
            if (double.IsNaN(a.X))
                a.X = b.X;
            else if (!double.IsNaN(b.X))
            {
                double num2 = a.X >= b.X ? a.X - b.X : 1.0 + a.X - b.X;
                double num3 = a.X >= b.X ? 1.0 + b.X - a.X : b.X - a.X;
                a.X = num3 <= num2 ? a.X + num3 * x : a.X - num2 * x;
                if (a.X < 0.0)
                    ++a.X;
                else if (a.X > 1.0)
                    --a.X;
            }
            if (double.IsNaN(a.Y))
                a.Y = b.Y;
            else if (!double.IsNaN(b.Y))
                a.Y = a.Y * num1 + b.Y * x;
            a.Z = a.Z * num1 + b.Z * x;
            return a;
        }

        public static Vector CerpRGB(Vector a, Vector b, double x, GradientColourspace gamma) => Vector.LerpRGB(a, b, (1.0 - Math.Cos(x * Math.PI)) / 2.0, gamma);

        public static Vector CerpH(Vector a, Vector b, double x) => Vector.LerpH(a, b, (1.0 - Math.Cos(x * Math.PI)) / 2.0);

        private static double cubic(
          double v0,
          double v1,
          double v2,
          double v3,
          double x,
          bool catmullRom)
        {
            double num1 = x * x;
            double num2;
            double num3;
            double num4;
            double num5;
            if (catmullRom)
            {
                num2 = -0.5 * v0 + 1.5 * v1 - 1.5 * v2 + 0.5 * v3;
                num3 = v0 - 2.5 * v1 + 2.0 * v2 - 0.5 * v3;
                num4 = -0.5 * v0 + 0.5 * v2;
                num5 = v1;
            }
            else
            {
                num2 = v3 - v2 - v0 + v1;
                num3 = v0 - v1 - num2;
                num4 = v2 - v0;
                num5 = v1;
            }
            return num2 * x * num1 + num3 * num1 + num4 * x + num5;
        }

        public static Vector CubicRGB(
          Vector pre,
          Vector a,
          Vector b,
          Vector post,
          double x,
          bool catmullRom,
          GradientColourspace gamma)
        {
            if (x > 1.0)
                x = 1.0;
            else if (x < 0.0)
                x = 0.0;
            Vector vector = new Vector()
            {
                X = Vector.cubic(pre.X, a.X, b.X, post.X, x, catmullRom),
                Y = Vector.cubic(pre.Y, a.Y, b.Y, post.Y, x, catmullRom),
                Z = Vector.cubic(pre.Z, a.Z, b.Z, post.Z, x, catmullRom)
            };
            switch (gamma)
            {
                case GradientColourspace.RGBV:
                    vector = vector.Adjust(vector.GetRGBValue(), Vector.cubic(pre.GetRGBValue(), a.GetRGBValue(), b.GetRGBValue(), post.GetRGBValue(), x, catmullRom));
                    break;
                case GradientColourspace.RGBL:
                    vector = vector.Adjust(vector.GetRGBLightness(), Vector.cubic(pre.GetRGBLightness(), a.GetRGBLightness(), b.GetRGBLightness(), post.GetRGBLightness(), x, catmullRom));
                    break;
            }
            return vector;
        }

        public static Vector CubicH(
          Vector pre,
          Vector a,
          Vector b,
          Vector post,
          double x,
          bool catmullRom)
        {
            if (x > 1.0)
                x = 1.0;
            else if (x < 0.0)
                x = 0.0;
            Vector vector = new Vector();
            vector.X = vector.Y = double.NaN;
            if (double.IsNaN(a.X) && !double.IsNaN(b.X))
                a.X = b.X;
            else if (double.IsNaN(b.X) && !double.IsNaN(a.X))
                b.X = a.X;
            if (double.IsNaN(pre.X) && !double.IsNaN(a.X))
                pre.X = a.X;
            if (double.IsNaN(post.X) && !double.IsNaN(b.X))
                post.X = b.X;
            if (!double.IsNaN(a.X) && !double.IsNaN(b.X))
            {
                Vector.HueSort(ref pre.X, ref a.X, ref b.X, ref post.X);
                a.X = Vector.cubic(pre.X, a.X, b.X, post.X, x, catmullRom);
                a.X -= Math.Floor(a.X);
            }
            if (double.IsNaN(a.Y) && !double.IsNaN(b.Y))
                a.Y = b.Y;
            else if (double.IsNaN(b.Y) && !double.IsNaN(a.Y))
                b.Y = a.Y;
            if (double.IsNaN(pre.Y) && !double.IsNaN(a.Y))
                pre.Y = a.Y;
            if (double.IsNaN(post.Y) && !double.IsNaN(b.Y))
                post.Y = b.Y;
            if (!double.IsNaN(a.Y) && !double.IsNaN(b.Y))
                vector.Y = Vector.cubic(pre.Y, a.Y, b.Y, post.Y, x, catmullRom);
            vector.X = a.X;
            vector.Z = Vector.cubic(pre.Z, a.Z, b.Z, post.Z, x, catmullRom);
            return vector;
        }

        private static double hermite(double y0, double y1, double y2, double y3, double x)
        {
            double num1 = x * x;
            double num2 = num1 * x;
            double num3 = (y1 - y0) * (1.0 + HermiteSettings.Bias) * (1.0 - HermiteSettings.Tension) / 2.0 + (y2 - y1) * (1.0 - HermiteSettings.Bias) * (1.0 - HermiteSettings.Tension) / 2.0;
            double num4 = (y2 - y1) * (1.0 + HermiteSettings.Bias) * (1.0 - HermiteSettings.Tension) / 2.0 + (y3 - y2) * (1.0 - HermiteSettings.Bias) * (1.0 - HermiteSettings.Tension) / 2.0;
            double num5 = 2.0 * num2 - 3.0 * num1 + 1.0;
            double num6 = num2 - 2.0 * num1 + x;
            double num7 = num2 - num1;
            double num8 = -2.0 * num2 + 3.0 * num1;
            return num5 * y1 + num6 * num3 + num7 * num4 + num8 * y2;
        }

        public static Vector HermiteRGB(
          Vector pre,
          Vector a,
          Vector b,
          Vector post,
          double x,
          GradientColourspace gamma)
        {
            if (x < 0.0)
                x = 0.0;
            else if (x > 1.0)
                x = 1.0;
            Vector vector = new Vector()
            {
                X = Vector.hermite(pre.X, a.X, b.X, post.X, x),
                Y = Vector.hermite(pre.Y, a.Y, b.Y, post.Y, x),
                Z = Vector.hermite(pre.Z, a.Z, b.Z, post.Z, x)
            };
            switch (gamma)
            {
                case GradientColourspace.RGBV:
                    vector = vector.Adjust(vector.GetRGBValue(), Vector.hermite(pre.GetRGBValue(), a.GetRGBValue(), b.GetRGBValue(), post.GetRGBValue(), x));
                    break;
                case GradientColourspace.RGBL:
                    vector = vector.Adjust(vector.GetRGBLightness(), Vector.hermite(pre.GetRGBLightness(), a.GetRGBLightness(), b.GetRGBLightness(), post.GetRGBLightness(), x));
                    break;
            }
            return vector;
        }

        public static Vector HermiteH(Vector pre, Vector a, Vector b, Vector post, double x)
        {
            if (x < 0.0)
                x = 0.0;
            else if (x > 1.0)
                x = 1.0;
            Vector vector = new Vector();
            vector.X = vector.Y = double.NaN;
            if (double.IsNaN(a.X) && !double.IsNaN(b.X))
                a.X = b.X;
            else if (double.IsNaN(b.X) && !double.IsNaN(a.X))
                b.X = a.X;
            if (double.IsNaN(pre.X) && !double.IsNaN(a.X))
                pre.X = a.X;
            if (double.IsNaN(post.X) && !double.IsNaN(b.X))
                post.X = b.X;
            if (!double.IsNaN(a.X) && !double.IsNaN(b.X))
            {
                Vector.HueSort(ref pre.X, ref a.X, ref b.X, ref post.X);
                a.X = Vector.hermite(pre.X, a.X, b.X, post.X, x);
                a.X -= Math.Floor(a.X);
            }
            if (double.IsNaN(a.Y) && !double.IsNaN(b.Y))
                a.Y = b.Y;
            else if (double.IsNaN(b.Y) && !double.IsNaN(a.Y))
                b.Y = a.Y;
            if (double.IsNaN(pre.Y) && !double.IsNaN(a.Y))
                pre.Y = a.Y;
            if (double.IsNaN(post.Y) && !double.IsNaN(b.Y))
                post.Y = b.Y;
            if (!double.IsNaN(a.Y) && !double.IsNaN(b.Y))
                vector.Y = Vector.hermite(pre.Y, a.Y, b.Y, post.Y, x);
            vector.X = a.X;
            vector.Z = Vector.hermite(pre.Z, a.Z, b.Z, post.Z, x);
            return vector;
        }

        public bool IsValid() => !double.IsNaN(this.X) && !double.IsNaN(this.Y) && !double.IsNaN(this.Z);

        private static void HueSort(ref double v0, ref double v1, ref double v2, ref double v3)
        {
            v0 -= Math.Floor(v0);
            v1 -= Math.Floor(v1);
            v2 -= Math.Floor(v2);
            v3 -= Math.Floor(v3);
            if (v0 - v1 > 0.5)
            {
                ++v1;
                ++v2;
                ++v3;
            }
            else if (v1 - v0 > 0.5)
            {
                --v1;
                --v2;
                --v3;
            }
            if (v1 - v2 > 0.5)
            {
                ++v2;
                ++v3;
            }
            else if (v2 - v1 > 0.5)
            {
                --v2;
                --v3;
            }
            if (v2 - v3 > 0.5)
            {
                ++v3;
            }
            else
            {
                if (v3 - v2 <= 0.5)
                    return;
                --v3;
            }
        }
    }
}
