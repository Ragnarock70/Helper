//-----------------------
// Copyright © Ragnarock
//----------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using Helper.WinAPI;

namespace Helper.Screen
{
    public static partial class Screen
    {
        public static class Pixel
        {
            #region Search

            /// <summary>
            /// Search a pixel within a rectangle
            /// </summary>
            /// <param name="left">Left coordinate of rectangle.</param>
            /// <param name="top">top coordinate of rectangle.</param>
            /// <param name="right">right coordinate of rectangle.</param>
            /// <param name="bottom">bottom coordinate of rectangle.</param>
            /// <param name="color">Color value of pixel to find.</param>
            /// <param name="hWnd">Window handle to be used (IntPtr.Zero for desktop)</param>
            /// <param name="variation">A number between 0 and 255 to indicate the allowed number of shades of variation of the red, green, and blue components of the colour. Default is 0 (exact match).</param>
            /// <returns>Returns a point with pixel's coordiates or Point.Empty</returns>
            public static Point Search(int left, int top, int right, int bottom, Color color, IntPtr hWnd,int variation = 0)
            {
                return Search(left, top, right, bottom, (uint)color.ToArgb(), hWnd, variation);
            }

            /// <summary>
            /// Search a pixel within a rectangle
            /// </summary>
            /// <param name="left">Left coordinate of rectangle.</param>
            /// <param name="top">top coordinate of rectangle.</param>
            /// <param name="right">right coordinate of rectangle.</param>
            /// <param name="bottom">bottom coordinate of rectangle.</param>
            /// <param name="color">Colour value of pixel to find.</param>
            /// <param name="hWnd">Window handle to be used (IntPtr.Zero for desktop)</param>
            /// <param name="variation">A number between 0 and 255 to indicate the allowed number of shades of variation of the red, green, and blue components of the colour. Default is 0 (exact match).</param>
            /// <returns>Returns a point with pixel's coordiates or Point.Empty</returns>
            public static unsafe Point Search(int left, int top, int right, int bottom, uint color, IntPtr hWnd,int variation = 0)
            {
                if (hWnd == IntPtr.Zero)
                    hWnd = PInvoke.GetDesktopWindow();

                using (var scrnshot = Screenshot(hWnd))
                {
                    var ret = Point.Empty;

                    var bmpData = scrnshot.LockBits(new Rectangle(0, 0, scrnshot.Width, scrnshot.Height),
                                                    ImageLockMode.ReadOnly, scrnshot.PixelFormat);
                    var pixelSize = Utilities.GetPixelSize(scrnshot.PixelFormat);
                    var RGB = Utilities.GetRGB(color);

                    if (right > bmpData.Width)
                        right = bmpData.Width;
                    if (bottom > bmpData.Height)
                        bottom = bmpData.Height;


                    if (variation == 0)
                        for (int y = top; y < bottom; y++)
                        {
                            byte* row = (byte*)bmpData.Scan0 + (y * bmpData.Stride);

                            for (int x = left; x < right; x++)
                            {
                                //blue -> greed -> red (-> alpha)
                                if (row[x * pixelSize] == RGB[2] &&
                                    row[x * pixelSize + 1] == RGB[1] &&
                                    row[x * pixelSize + 2] == RGB[0])
                                {
                                    ret = new Point(x, y);
                                    break;
                                }
                            }
                            if (ret != Point.Empty)
                                break;

                        }
                    else
                        for (int y = top; y < bottom; y++)
                        {
                            byte* row = (byte*)bmpData.Scan0 + (y * bmpData.Stride);

                            for (int x = left; x < right; x++)
                            {
                                //blue -> greed -> red (-> alpha)
                                if (row[x * pixelSize] <= RGB[2] + variation && row[x * pixelSize] >= RGB[2] - variation &&
                                    row[x * pixelSize + 1] <= RGB[1] + variation &&
                                    row[x * pixelSize + 1] >= RGB[1] - variation &&
                                    row[x * pixelSize + 2] <= RGB[0] + variation &&
                                    row[x * pixelSize + 2] >= RGB[0] - variation)
                                {
                                    ret = new Point(x, y);
                                    break;
                                }
                            }
                            if (ret != Point.Empty)
                                break;

                        }
                    scrnshot.UnlockBits(bmpData);
                    return ret;
                }
            }

            /// <summary>
            /// Search all pixels within a rectangle.
            /// </summary>
            /// <param name="left">Left coordinate of rectangle.</param>
            /// <param name="top">top coordinate of rectangle.</param>
            /// <param name="right">right coordinate of rectangle.</param>
            /// <param name="bottom">bottom coordinate of rectangle.</param>
            /// <param name="color">Color value of pixel to find.</param>
            /// <param name="hWnd">Window handle to be used (IntPtr.Zero for desktop)</param>
            /// <param name="variation">A number between 0 and 255 to indicate the allowed number of shades of variation of the red, green, and blue components of the colour.  Default is 0 (exact match).</param>
            /// <returns>Returns a list of points with pixel's coordiates</returns>
            public static List<Point> SearchAll(int left, int top, int right, int bottom, Color color, IntPtr hWnd,int variation = 0)
            {
                return SearchAll(left, top, right, bottom, (uint)color.ToArgb(), hWnd, variation);
            }

            /// <summary>
            /// Search all pixels within a rectangle.
            /// </summary>
            /// <param name="left">Left coordinate of rectangle.</param>
            /// <param name="top">top coordinate of rectangle.</param>
            /// <param name="right">right coordinate of rectangle.</param>
            /// <param name="bottom">bottom coordinate of rectangle.</param>
            /// <param name="color">Colour value of pixel to find.</param>
            /// <param name="hWnd">Window handle to be used (IntPtr.Zero for desktop)</param>
            /// <param name="variation">A number between 0 and 255 to indicate the allowed number of shades of variation of the red, green, and blue components of the colour. Default is 0 (exact match).</param>
            /// <returns>Returns a list of points with pixel's coordiates</returns>
            public static unsafe List<Point> SearchAll(int left, int top, int right, int bottom, uint color, IntPtr hWnd,int variation = 0)
            {
                if (hWnd == IntPtr.Zero)
                    hWnd = PInvoke.GetDesktopWindow();

                using (var scrnshot = Screenshot(hWnd))
                {
                    var ret = new Stack<Point>();
                    var bmpData = scrnshot.LockBits(new Rectangle(0, 0, scrnshot.Width, scrnshot.Height),
                                                    ImageLockMode.ReadOnly, scrnshot.PixelFormat);
                    var pixelSize = Utilities.GetPixelSize(scrnshot.PixelFormat);
                    var RGB = Utilities.GetRGB(color);

                    if (right > bmpData.Width)
                        right = bmpData.Width;
                    if (bottom > bmpData.Height)
                        bottom = bmpData.Height;

                    if (variation == 0)
                        for (int y = top; y < bottom; y++)
                        {
                            byte* row = (byte*)bmpData.Scan0 + (y * bmpData.Stride);

                            for (int x = left; x < right; x++)
                            {
                                //blue -> greed -> red (-> alpha)
                                if (row[x * pixelSize] == RGB[2] &&
                                    row[x * pixelSize + 1] == RGB[1] &&
                                    row[x * pixelSize + 2] == RGB[0])
                                {
                                    ret.Push(new Point(x, y));
                                }
                            }
                        }
                    else
                        for (int y = top; y < bottom; y++)
                        {
                            byte* row = (byte*)bmpData.Scan0 + (y * bmpData.Stride);

                            for (int x = left; x < right; x++)
                            {
                                //blue -> greed -> red (-> alpha)
                                if (row[x * pixelSize] <= RGB[2] + variation && row[x * pixelSize] >= RGB[2] - variation &&
                                    row[x * pixelSize + 1] <= RGB[1] + variation &&
                                    row[x * pixelSize + 1] >= RGB[1] - variation &&
                                    row[x * pixelSize + 2] <= RGB[0] + variation &&
                                    row[x * pixelSize + 2] >= RGB[0] - variation)
                                {
                                    ret.Push(new Point(x, y));
                                }
                            }
                        }
                    scrnshot.UnlockBits(bmpData);

                    return ret.ToList();
                }
            }

            #endregion

            #region Screenshot

            /// <summary>
            /// Takes a screenshot of desired window.
            /// </summary>
            /// <param name="hWnd">Window/s handle (IntPtr.Zero for desktop).</param>
            /// <returns>Window's screenshot.</returns>
            /// 
            /// <!-- Source: http://www.developerfusion.com/code/4630/capture-a-screen-shot/ -->
            public static Bitmap Screenshot(IntPtr hWnd)
            {
                if (hWnd == IntPtr.Zero)
                    hWnd = PInvoke.GetDesktopWindow();

                // get te hDC of the target window
                var hdcSrc = PInvoke.GetWindowDC(hWnd);
                // get the size
                var windowRect = new RECT();
                PInvoke.GetWindowRect(hWnd, ref windowRect);
                var width = windowRect.Right - windowRect.Left;
                var height = windowRect.Bottom - windowRect.Top;
                // create a device context we can copy to
                var hdcDest = PInvoke.CreateCompatibleDC(hdcSrc);
                // create a bitmap we can copy it to,
                // using GetDeviceCaps to get the width/height
                var hBitmap = PInvoke.CreateCompatibleBitmap(hdcSrc, width, height);
                // select the bitmap object
                var hOld = PInvoke.SelectObject(hdcDest, hBitmap);
                // bitblt over
                PInvoke.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, TernaryRasterOperations.SRCCOPY);
                // restore selection
                PInvoke.SelectObject(hdcDest, hOld);
                // clean up
                PInvoke.DeleteDC(hdcDest);
                PInvoke.ReleaseDC(hWnd, hdcSrc);
                // get a .NET image object for it
                var bmp = Image.FromHbitmap(hBitmap);
                // free up the Bitmap object
                PInvoke.DeleteObject(hBitmap);


                //if (!bmp.Size.IsEmpty)
                //    bmp.Save("IMG\\scrn" + Environment.TickCount + ".bmp", ImageFormat.Bmp);

                return bmp;
            }

            /// <summary>
            /// Takes a screenshot of the desired window.
            /// </summary>
            /// <param name="hWnd">Window's handle (IntPtr.Zero for desktop).</param>
            /// <returns>Window's screenshot.</returns>
            ///<remarks>Very slow.. Use 'Screenshot' method instead.</remarks>
            public static Bitmap ScreenshotWithGetPixel(IntPtr hWnd)
            {
                if (hWnd == IntPtr.Zero)
                    hWnd = PInvoke.GetDesktopWindow();

                var hdcSrc = PInvoke.GetWindowDC(hWnd);

                var windowRect = new RECT();
                PInvoke.GetWindowRect(hWnd, ref windowRect);
                var width = windowRect.Right - windowRect.Left;
                var height = windowRect.Bottom - windowRect.Top;

                var bmp = new Bitmap(width, height);

                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        bmp.SetPixel(x, y, Utilities.GetColorFromABGR(PInvoke.GetPixel(hdcSrc, x, y)));
                    }
                return bmp;
            }

            #endregion

            #region GetPixel

            /// <summary>
            /// Get the pixel's color at (X;Y).
            /// </summary>
            /// <param name="x">X coordinate.</param>
            /// <param name="y">Y coordinate.</param>
            /// <param name="hWnd">Window's handle (IntPtr.Zero for desktop).</param>
            /// <returns>Pixel's color.</returns>
            public static Color GetPixelColor(int x, int y, IntPtr hWnd)
            {
                return Utilities.GetColorFromABGR(GetPixelColourValue(x, y, hWnd));
            }

            /// <summary>
            /// Get the pixel's color at (X;Y).
            /// </summary>
            /// <param name="x">X coordinate.</param>
            /// <param name="y">Y coordinate.</param>
            /// <param name="hWnd">Window's handle (IntPtr.Zero for desktop).</param>
            /// <returns>Pixel's color in decimal.</returns>
            public static uint GetPixelColourValue(int x, int y, IntPtr hWnd)
            {
                if (hWnd == IntPtr.Zero)
                    hWnd = PInvoke.GetDesktopWindow();

                var hdcSrc = PInvoke.GetWindowDC(hWnd);
                return PInvoke.GetPixel(hdcSrc, x, y);
            }

            #endregion
        }
    }
}