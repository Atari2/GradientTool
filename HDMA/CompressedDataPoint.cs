﻿// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HDMA.CompressedDataPoint
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System.Collections.Generic;

namespace SFXProductions.GradientTool.HDMA
{
    internal struct CompressedDataPoint
    {
        public int Count;
        public List<DataPoint> Data;

        public CompressedDataPoint(DataPoint dataPoint)
        {
            this.Count = 1;
            this.Data = new List<DataPoint>() { dataPoint };
        }
    }
}
