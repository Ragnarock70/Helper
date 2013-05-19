//-----------------------
// Copyright © Ragnarock
//----------------------

using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Helper.Screen
{
    public static partial class Screen
    {
        private static class Utilities
        {
            public static Color GetColorFromABGR(uint ABGR)
            {
                var ABGRi = (int)ABGR;
                return Color.FromArgb((ABGRi & 0x000000FF),
                                      (ABGRi & 0x0000FF00) >> 8,
                                      (ABGRi & 0x00FF0000) >> 16);
            }

            public static uint[] GetRGB(uint color)
            {
                var ret = new uint[3];
                ret[0] = ((color >> 16) & 0xFF);
                ret[1] = ((color >> 8) & 0xFF);
                ret[2] = ((color) & 0xFF);
                return ret;
            }

            internal static int GetPixelSize(PixelFormat format)
            {
                int pixelSize;
                switch (format)
                {
                    case PixelFormat.Format32bppArgb:
                        pixelSize = 4;
                        break;
                    case PixelFormat.Format32bppRgb:
                        pixelSize = 4;
                        break;
                    case PixelFormat.Format24bppRgb:
                        pixelSize = 3;
                        break;
                    //case PixelFormat.Format8bppIndexed:
                    //    pixelSize = 1;
                    //    break;
                    //case PixelFormat.Format4bppIndexed:
                    //    pixelSize = 1 / 2;
                    //    break;
                    //case PixelFormat.Format1bppIndexed:
                    //    pixelSize = 1 / 8;
                    //    break;
                    default:
                        throw new Exception("Unsupported pixel format: " + format);
                }
                return pixelSize;
            }
        }
    }
}