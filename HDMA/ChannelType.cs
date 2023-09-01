// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HDMA.ChannelType
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

using System;

namespace SFXProductions.GradientTool.HDMA
{
    [Flags]
    internal enum ChannelType : byte
    {
        Brightness = 0,
        Red = 32, // 0x20
        Green = 64, // 0x40
        Blue = 128, // 0x80
        Yellow = Green | Red, // 0x60
        Cyan = Blue | Green, // 0xC0
        Magenta = Blue | Red, // 0xA0
        Grey = Magenta | Green, // 0xE0
    }
}
