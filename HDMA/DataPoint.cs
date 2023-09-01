// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HDMA.DataPoint
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System;

namespace SFXProductions.GradientTool.HDMA
{
    internal struct DataPoint : IEquatable<DataPoint>
    {
        public ushort Data1;
        public ushort Data2;
        public ushort Data3;

        public static bool operator ==(DataPoint left, DataPoint right) => (int)left.Data1 == (int)right.Data1 && (int)left.Data2 == (int)right.Data2 && (int)left.Data3 == (int)right.Data3;

        public static bool operator !=(DataPoint left, DataPoint right) => (int)left.Data1 != (int)right.Data1 || (int)left.Data2 != (int)right.Data2 || (int)left.Data3 != (int)right.Data3;

        public override int GetHashCode() => (int)this.Data1 ^ (int)this.Data2 ^ (int)this.Data3;

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case DataPoint dataPoint:
                    return dataPoint == this;
                default:
                    return false;
            }
        }

        public bool Equals(DataPoint other) => this == other;
    }
}
