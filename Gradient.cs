// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.Gradient
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System;
using System.Collections.Generic;

namespace SFXProductions.GradientTool
{
    internal sealed class Gradient
    {
        private List<GradientStop> m_stops;

        public Gradient()
        {
            this.m_stops = new List<GradientStop>(2);
            this.m_stops.Add(new GradientStop(0.0, new Vector()
            {
                X = 1.0
            }));
            this.m_stops.Add(new GradientStop(1.0, new Vector()
            {
                Y = 1.0,
                Z = 1.0
            }));
        }

        public GradientColourspace Colourspace { get; set; }

        public GradientType Type { get; set; }

        public List<GradientStop> Stops => this.m_stops;

        private void FillBuffers(
          int count,
          double[] rBuffer,
          double[] gBuffer,
          double[] bBuffer,
          double rValue,
          double gValue,
          double bValue)
        {
            for (int index = 0; index < count; ++index)
            {
                rBuffer[index] = rValue;
                gBuffer[index] = gValue;
                bBuffer[index] = bValue;
            }
        }

        private void FillBuffers(
          int start,
          int end,
          double[] rBuffer,
          double[] gBuffer,
          double[] bBuffer,
          double rValue,
          double gValue,
          double bValue)
        {
            for (int index = start; index < end; ++index)
            {
                rBuffer[index] = rValue;
                gBuffer[index] = gValue;
                bBuffer[index] = bValue;
            }
        }

        public void Calculate(int count, double[] r, double[] g, double[] b)
        {
            if (count <= 0 || count > r.Length || count > g.Length || count > b.Length)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than zero but less than the length of r, g, and b.");
            if (r == null)
                throw new ArgumentNullException(nameof(r));
            if (g == null)
                throw new ArgumentNullException(nameof(g));
            if (b == null)
                throw new ArgumentNullException(nameof(b));
            if (this.m_stops.Count == 0)
                this.FillBuffers(count, r, g, b, 0.0, 0.0, 0.0);
            else if (this.m_stops.Count == 1)
            {
                Vector colour = this.m_stops[0].Colour;
                this.FillBuffers(count, r, g, b, colour.X, colour.Y, colour.Z);
            }
            else
            {
                this.m_stops.Sort();
                this.m_stops.Sort();
                GradientStop gradientStop = new GradientStop();
                Vector a = new Vector();
                Vector pre = a;
                for (int index1 = 0; index1 < this.m_stops.Count; ++index1)
                {
                    GradientStop stop = this.m_stops[index1];
                    Vector colourspace1 = stop.Colour.HDRToColourspace(this.Colourspace);
                    if (index1 == 0)
                    {
                        if (stop.Position > 0.0)
                        {
                            int count1 = (int)(stop.Position * (double)(count - 1) + 0.5);
                            Vector colour = stop.Colour;
                            this.FillBuffers(count1, r, g, b, colour.X, colour.Y, colour.Z);
                        }
                        gradientStop = stop;
                        a = pre = colourspace1;
                    }
                    else
                    {
                        Vector colourspace2 = (index1 + 1 < this.m_stops.Count ? this.m_stops[index1 + 1] : stop).Colour.HDRToColourspace(this.Colourspace);
                        int num1 = (int)(gradientStop.Position * (double)(count - 1) + 0.5);
                        int num2 = (int)(stop.Position * (double)(count - 1) + 0.5);
                        double num3 = (double)(num2 - num1);
                        for (int index2 = num1; index2 <= num2; ++index2)
                        {
                            Vector hdr = this.Interpolate(pre, a, colourspace1, colourspace2, (double)(index2 - num1) / num3).ToHDR(this.Colourspace);
                            r[index2] = hdr.X;
                            g[index2] = hdr.Y;
                            b[index2] = hdr.Z;
                        }
                        pre = a;
                        gradientStop = stop;
                        a = colourspace1;
                    }
                }
                if (gradientStop.Position < 1.0)
                {
                    int start = (int)(gradientStop.Position * (double)(count - 1) + 0.5);
                    Vector colour = gradientStop.Colour;
                    this.FillBuffers(start, count, r, g, b, colour.X, colour.Y, colour.Z);
                }
                else
                {
                    if (gradientStop.Position != 1.0 || !gradientStop.Colour.IsValid() || !double.IsNaN(r[count - 1]) || !double.IsNaN(g[count - 1]) || !double.IsNaN(b[count - 1]))
                        return;
                    r[count - 1] = gradientStop.Colour.X;
                    g[count - 1] = gradientStop.Colour.Y;
                    b[count - 1] = gradientStop.Colour.Z;
                }
            }
        }

        private Vector Interpolate(Vector pre, Vector a, Vector b, Vector post, double x)
        {
            bool flag = this.Colourspace >= GradientColourspace.RGB && this.Colourspace <= GradientColourspace.RGBL;
            switch (this.Type)
            {
                case GradientType.Linear:
                    return !flag ? Vector.LerpH(a, b, x) : Vector.LerpRGB(a, b, x, this.Colourspace);
                case GradientType.Circular:
                    return !flag ? Vector.CerpH(a, b, x) : Vector.CerpRGB(a, b, x, this.Colourspace);
                case GradientType.Cubic:
                case GradientType.CatmullRom:
                    bool catmullRom = this.Type == GradientType.CatmullRom;
                    return !flag ? Vector.CubicH(pre, a, b, post, x, catmullRom) : Vector.CubicRGB(pre, a, b, post, x, catmullRom, this.Colourspace);
                case GradientType.Hermite:
                    return !flag ? Vector.HermiteH(pre, a, b, post, x) : Vector.HermiteRGB(pre, a, b, post, x, this.Colourspace);
                default:
                    throw new ArgumentException("Invalid gradient type.");
            }
        }
    }
}
