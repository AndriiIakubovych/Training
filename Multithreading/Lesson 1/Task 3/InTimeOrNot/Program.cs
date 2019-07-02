using System;
using System.Threading;

namespace InTimeOrNot
{
    class Program
    {
        private static int millisecondsCount = 0;

        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(SetMillisecondsCounting));
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            Random rand = new Random();
            ConsoleKey[] keys = new ConsoleKey[] { ConsoleKey.F1, ConsoleKey.F2, ConsoleKey.F3, ConsoleKey.F4, ConsoleKey.F5, ConsoleKey.F6, ConsoleKey.F7, ConsoleKey.F8, ConsoleKey.F9, ConsoleKey.F10, ConsoleKey.F11, ConsoleKey.F12, ConsoleKey.D0, ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6, ConsoleKey.D7, ConsoleKey.D8, ConsoleKey.D9, ConsoleKey.Oem1, ConsoleKey.Oem2, ConsoleKey.Oem3, ConsoleKey.Oem4, ConsoleKey.Oem5, ConsoleKey.Oem6, ConsoleKey.Oem7, ConsoleKey.OemPlus, ConsoleKey.OemMinus, ConsoleKey.OemComma, ConsoleKey.OemPeriod, ConsoleKey.A, ConsoleKey.B, ConsoleKey.C, ConsoleKey.D, ConsoleKey.E, ConsoleKey.F, ConsoleKey.G, ConsoleKey.H, ConsoleKey.I, ConsoleKey.J, ConsoleKey.K, ConsoleKey.O, ConsoleKey.P, ConsoleKey.Q, ConsoleKey.R, ConsoleKey.S, ConsoleKey.T, ConsoleKey.U, ConsoleKey.V, ConsoleKey.W, ConsoleKey.X, ConsoleKey.Y, ConsoleKey.Z, ConsoleKey.Tab, ConsoleKey.Enter, ConsoleKey.Spacebar, ConsoleKey.Backspace, ConsoleKey.Escape, ConsoleKey.Insert, ConsoleKey.Home, ConsoleKey.Delete, ConsoleKey.End, ConsoleKey.PageUp, ConsoleKey.PageDown, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.Add, ConsoleKey.Subtract, ConsoleKey.Multiply, ConsoleKey.Divide, ConsoleKey.NumPad0, ConsoleKey.NumPad1, ConsoleKey.NumPad2, ConsoleKey.NumPad3, ConsoleKey.NumPad4, ConsoleKey.NumPad5, ConsoleKey.NumPad6, ConsoleKey.NumPad7, ConsoleKey.NumPad8, ConsoleKey.NumPad9, ConsoleKey.Decimal };
            string[] keysName = new string[] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ";", "/ (?)", "~", "[", "\\", "]", "'", "=", "- (_)", ", (<)", ". (>)", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Tab", "Enter", "Space", "Backspace", "Esc", "Insert", "Home", "Delete", "End", "Page Up", "Page Down", "Up", "Down", "Left", "Right", "+", "-", "*", "/", "Num 0", "Num 1", "Num 2", "Num 3", "Num 4", "Num 5", "Num 6", "Num 7", "Num 8", "Num 9", "." };
            int keyNumber;
            Console.Title = "Успел, не успел";
            thread.Start();
            while (true)
            {
                keyNumber = rand.Next(0, keys.Length);
                millisecondsCount = 0;
                Console.Write("Нажмите клавишу \"" + keysName[keyNumber] + "\" на клавиатуре! ");
                while (keyInfo.Key != keys[keyNumber])
                    keyInfo = Console.ReadKey(true);
                Console.WriteLine("\nЗатраченное время: " + (millisecondsCount * 10 + Math.Round((double)millisecondsCount / 2)) + " мс\n");
                keyInfo = new ConsoleKeyInfo();
                Thread.Sleep(rand.Next(0, 10000));
            }
        }

        static void SetMillisecondsCounting()
        {
            Timer timer = new Timer(new TimerCallback(IncreaseMillisecondsCount));
            timer.Change(0, 1);
        }

        static void IncreaseMillisecondsCount(object timer)
        {
            millisecondsCount++;
        }
    }
}