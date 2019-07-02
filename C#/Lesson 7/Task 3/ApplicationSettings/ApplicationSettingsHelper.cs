using System;
using System.IO;
using System.Drawing;

namespace ApplicationSettings
{
    class ApplicationSettingsHelper
    {
        private static ConsoleColor RGBConsoleColor(byte red, byte green, byte blue)
        {
            ConsoleColor result = 0;
            Color color;
            double delta = double.MaxValue, temp;
            string name;
            foreach (ConsoleColor consoleColor in Enum.GetValues(typeof(ConsoleColor)))
            {
                name = Enum.GetName(typeof(ConsoleColor), consoleColor);
                color = Color.FromName(name == "DarkYellow" ? "Orange" : name);
                temp = Math.Pow(color.R - red, 2) + Math.Pow(color.G - green, 2) + Math.Pow(color.B - blue, 2);
                if (temp == 0)
                    return consoleColor;
                if (temp < delta)
                {
                    delta = temp;
                    result = consoleColor;
                }
            }
            return result;
        }

        public static void ReadSettings()
        {
            using (FileStream fs = new FileStream("Settings.dat", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                byte red, green, blue;
                int width, height;
                string title;
                BinaryReader br = new BinaryReader(fs);
                red = br.ReadByte();
                green = br.ReadByte();
                blue = br.ReadByte();
                width = br.ReadInt32();
                height = br.ReadInt32();
                title = br.ReadString();
                Console.BackgroundColor = RGBConsoleColor(red, green, blue);
                Console.Clear();
                if (width <= Console.LargestWindowWidth && height <= Console.LargestWindowHeight)
                {
                    if (width > Console.WindowWidth)
                        Console.BufferWidth = width;
                    if (height > Console.WindowHeight)
                        Console.BufferHeight = height;
                    Console.SetWindowSize(width, height);
                }
                Console.Title = title;
            }
        }

        public static void WriteSettings(byte red, byte green, byte blue, int width, int height, string title)
        {
            using (FileStream fs = new FileStream("Settings.dat", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(red);
                bw.Write(green);
                bw.Write(blue);
                bw.Write(width);
                bw.Write(height);
                bw.Write(title);
                bw.Flush();
                fs.Seek(0, SeekOrigin.Begin);
            }
        }
    }
}