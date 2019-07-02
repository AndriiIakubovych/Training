using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game21
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_POINTS = 21;
            const int TABLES_COUNT = 10;
            int currentGameNumber, newGameNumber = 0, colourNumber, cardNumber, card;
            bool startFirstLoop, startSecondLoop;
            Random rand = new Random();
            GamblingTable gt = new GamblingTable();
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            ConsoleKey[] keys = new ConsoleKey[TABLES_COUNT] { ConsoleKey.F1, ConsoleKey.F2, ConsoleKey.F3, ConsoleKey.F4, ConsoleKey.F5, ConsoleKey.F6, ConsoleKey.F7, ConsoleKey.F8, ConsoleKey.F9, ConsoleKey.F10 };
            MemoryStream[] ms = new MemoryStream[TABLES_COUNT];
            BinaryFormatter bf = new BinaryFormatter();
            ConsoleFont.SetConsoleFont();
            Console.OutputEncoding = Encoding.UTF8;
            gt.InitGame();
            for (int i = 0; i < ms.Length; i++)
            {
                ms[i] = new MemoryStream();
                bf.Serialize(ms[i], gt);
            }
            while (true)
            {
                Console.Clear();
                currentGameNumber = newGameNumber;
                Console.Title = "Игра \"21\" - Игровой стол №" + (currentGameNumber + 1);
                ms[currentGameNumber].Seek(0, SeekOrigin.Begin);
                gt = (GamblingTable)bf.Deserialize(ms[currentGameNumber]);
                startFirstLoop = true;
                startSecondLoop = true;
                for (int i = 0; i < gt.PlayerCardsSymbols.Length; i++)
                {
                    Console.WriteLine("Вы взяли карту: " + gt.PlayerCardsSymbols[i]);
                    Console.Write("Ваши карты: ");
                    for (int j = 0; j < gt.PlayerCardsSymbols.Length; j++)
                        Console.Write(gt.PlayerCardsSymbols[j] + " ");
                    if (i < gt.PlayerCardsSymbols.Length - 1)
                        Console.WriteLine("\nВзять ещё карту (y/n)? y\n");
                    else
                    {
                        if (gt.GetPlayerPoints() < MAX_POINTS && !gt.StopTaking)
                        {
                            Console.Write("\nВзять ещё карту (y/n)? ");
                            keyInfo = Console.ReadKey();
                            if (keyInfo.Modifiers == ConsoleModifiers.Alt && (newGameNumber = Array.IndexOf(keys, keyInfo.Key)) != -1)
                            {
                                ms[currentGameNumber].Seek(0, SeekOrigin.Begin);
                                bf.Serialize(ms[currentGameNumber], gt);
                                startFirstLoop = false;
                                startSecondLoop = false;
                                break;
                            }
                            else
                            {
                                newGameNumber = currentGameNumber;
                                gt.StopTaking = keyInfo.Key == ConsoleKey.N;
                                Console.WriteLine("\n");
                            }
                        }
                        else
                        {
                            startFirstLoop = false;
                            startSecondLoop = false;
                            Console.WriteLine("\n");
                            for (int j = 0; j < gt.ComputerCardsSymbols.Length; j++)
                                Console.WriteLine("Компьютер взял карту!");
                            gt.StopTaking = true;
                        }
                    }
                }
                if (startFirstLoop)
                    while (!gt.StopTaking)
                    {
                        Console.WriteLine("Вы взяли карту: " + gt.TakeCard(true));
                        Console.Write("Ваши карты: ");
                        for (int i = 0; i < gt.PlayerCardsSymbols.Length; i++)
                            Console.Write(gt.PlayerCardsSymbols[i] + " ");
                        if (gt.GetPlayerPoints() >= MAX_POINTS)
                        {
                            Console.WriteLine("\n");
                            break;
                        }
                        Console.Write("\nВзять ещё карту (y/n)? ");
                        keyInfo = Console.ReadKey();
                        if (keyInfo.Modifiers == ConsoleModifiers.Alt && (newGameNumber = Array.IndexOf(keys, keyInfo.Key)) != -1)
                        {
                            ms[currentGameNumber].Seek(0, SeekOrigin.Begin);
                            bf.Serialize(ms[currentGameNumber], gt);
                            startSecondLoop = false;
                            break;
                        }
                        else
                        {
                            newGameNumber = currentGameNumber;
                            gt.StopTaking = keyInfo.Key == ConsoleKey.N;
                            Console.WriteLine("\n");
                        }
                    }
                if (startSecondLoop)
                    do
                    {
                        gt.TakeCard(false);
                        Console.WriteLine("Компьютер взял карту!");
                        if (gt.GetComputerPoints() > MAX_POINTS - MAX_POINTS / 3)
                        {
                            colourNumber = rand.Next(0, gt.ColourCount);
                            cardNumber = rand.Next(0, gt.Pack[colourNumber].Length);
                            card = gt.Pack[colourNumber][cardNumber];
                            if (card > MAX_POINTS - gt.GetComputerPoints())
                                gt.StopTaking = true;
                            else
                                gt.StopTaking = false;
                        }
                        else
                            gt.StopTaking = false;
                    }
                    while (!gt.StopTaking);
                if (gt.StopTaking)
                {
                    Console.Write("\nВаши карты: ");
                    for (int i = 0; i < gt.PlayerCardsSymbols.Length; i++)
                        Console.Write(gt.PlayerCardsSymbols[i] + " ");
                    Console.WriteLine("\nВаши набранные очки: " + gt.GetPlayerPoints());
                    Console.Write("Карты компьютера: ");
                    for (int i = 0; i < gt.ComputerCardsSymbols.Length; i++)
                        Console.Write(gt.ComputerCardsSymbols[i] + " ");
                    Console.WriteLine("\nОчки, набранные компьютером: " + gt.GetComputerPoints());
                    if ((gt.GetPlayerPoints() > gt.GetComputerPoints() && gt.GetPlayerPoints() <= MAX_POINTS) || (gt.GetPlayerPoints() < gt.GetComputerPoints() && gt.GetPlayerPoints() <= MAX_POINTS && gt.GetComputerPoints() > MAX_POINTS))
                        Console.WriteLine("\nВы выиграли!");
                    if (gt.GetPlayerPoints() == gt.GetComputerPoints() || (gt.GetPlayerPoints() > MAX_POINTS && gt.GetComputerPoints() > MAX_POINTS))
                        Console.WriteLine("\nНичья!");
                    if ((gt.GetPlayerPoints() < gt.GetComputerPoints() && gt.GetComputerPoints() <= MAX_POINTS) || (gt.GetPlayerPoints() > gt.GetComputerPoints() && gt.GetPlayerPoints() > MAX_POINTS && gt.GetComputerPoints() <= MAX_POINTS))
                        Console.WriteLine("\nВы проиграли!");
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Modifiers != ConsoleModifiers.Alt || (newGameNumber = Array.IndexOf(keys, keyInfo.Key)) == -1)
                    {
                        newGameNumber = currentGameNumber;
                        gt.InitGame();
                    }
                    ms[currentGameNumber].Seek(0, SeekOrigin.Begin);
                    bf.Serialize(ms[currentGameNumber], gt);
                }
            }
        }
    }
}