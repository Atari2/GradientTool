// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.GradientStop
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System;
using System.Drawing;

namespace SFXProductions.GradientTool
{
    internal struct GradientStop : IComparable, IComparable<GradientStop>
    {
        private static ulong s_lastId;
        private ulong m_id;

        public GradientStop(double position, Vector colour)
          : this()
        {
            this.m_id = ++GradientStop.s_lastId;
            this.Position = position;
            this.Colour = colour;
        }

        public GradientStop(double position, Color colour)
          : this(position, colour.ToColourspace(GradientColourspace.RGB))
        {
        }

        public double Position { get; set; }

        public Vector Colour { get; set; }

        public ulong Id => this.m_id;

        public int CompareTo(GradientStop other) => this.Position.CompareTo(other.Position);

        int IComparable.CompareTo(object obj)
        {
            if (obj is GradientStop other)
                return this.CompareTo(other);
            throw new ArgumentException();
        }
    }
}
