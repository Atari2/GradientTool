// Decompiled with JetBrains decompiler
// Type: SFXProductions.GradientTool.HDMA.GradientChannelsHelper
// Assembly: GradientTool, Version=0.8.2.1, Culture=neutral, PublicKeyToken=null
// MVID: 818AB9B3-796A-4A49-8B90-C00D066A321B
// Assembly location: C:\Users\aless\Downloads\gradient-tool-v0.8.2.1\GradientTool.exe

namespace SFXProductions.GradientTool.HDMA
{
    internal static class GradientChannelsHelper
    {
        private static readonly string[] s_channelNames = new string[15]
        {
      "Red, Green, Blue",
      "Red, Green",
      "Green, Blue",
      "Red, Blue",
      "Cyan, Red",
      "Yellow, Blue",
      "Magenta, Green",
      "Red",
      "Green",
      "Blue",
      "Cyan",
      "Yellow",
      "Magenta",
      "Grey",
      "Brightness"
        };

        public static string GetChannelString(GradientChannels channelType) => GradientChannelsHelper.s_channelNames[(int)channelType];
    }
}
