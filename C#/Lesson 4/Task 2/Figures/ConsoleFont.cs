﻿using System;
using System.Runtime.InteropServices;

namespace Figures
{
    class ConsoleFont
    {
        private const int STD_OUTPUT_HANDLE = -11;
        private const int TMPF_TRUETYPE = 4;
        private const int LF_FACESIZE = 32;
        private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal unsafe struct CONSOLE_FONT_INFO_EX
        {
            internal uint cbSize;
            internal uint nFont;
            internal COORD dwFontSize;
            internal int fontFamily;
            internal int fontWeight;
            internal fixed char faceName[LF_FACESIZE];
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct COORD
        {
            internal short x;
            internal short y;

            internal COORD(short x, short y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetCurrentConsoleFontEx(IntPtr consoleOutput, bool maximumWindow, ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int dwType);

        public static void SetConsoleFont(string fontName = "Lucida Console")
        {
            unsafe
            {
                IntPtr hnd = GetStdHandle(STD_OUTPUT_HANDLE);
                if (hnd != INVALID_HANDLE_VALUE)
                {
                    CONSOLE_FONT_INFO_EX info = new CONSOLE_FONT_INFO_EX();
                    info.cbSize = (uint)Marshal.SizeOf(info);
                    CONSOLE_FONT_INFO_EX newInfo = new CONSOLE_FONT_INFO_EX();
                    newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
                    newInfo.fontFamily = TMPF_TRUETYPE;
                    IntPtr ptr = new IntPtr(newInfo.faceName);
                    Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);
                    newInfo.dwFontSize = new COORD(info.dwFontSize.x, info.dwFontSize.y);
                    newInfo.fontWeight = info.fontWeight;
                    SetCurrentConsoleFontEx(hnd, false, ref newInfo);
                }
            }
        }
    }
}