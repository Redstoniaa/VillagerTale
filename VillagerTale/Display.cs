﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VillagerTale
{
    public enum Align
    {
        Left,
        Center,
        Right
    }

    class Display
    {
        public static void Text(Align alignment, bool wait, params string[] text)
        {
            foreach (string print in text)
            {
                if (alignment == Align.Center)
                {
                    for (int i = 0; i < (Console.WindowWidth - print.Length) / 2; i++)
                    {
                        Console.Write(" ");
                    }
                }

                else if (alignment == Align.Right)
                {
                    for (int i = 0; i < Console.WindowWidth - print.Length - 1; i++)
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine(print);
            }

            if (wait)
            {
                if (Key() == ConsoleKey.Escape)
                {
                    Game.Pause();
                }
            }
        }

        public static void Text(Align alignment, params string[] text)
        {
            Text(alignment, true, text);
        }

        public static void Text(params string[] text)
        {
            Text(Align.Left, text);
        }

        public static void Crawl(Align alignment, bool wait, params string[] text)
        {
            foreach (string print in text)
            {
                if (alignment == Align.Center)
                {
                    for (int i = 0; i < (Console.WindowWidth - print.Length) / 2; i++)
                    {
                        Console.Write(" ");
                    }
                }

                else if (alignment == Align.Right)
                {
                    for (int i = 0; i < Console.WindowWidth - print.Length - 1; i++)
                    {
                        Console.Write(" ");
                    }
                }

                CrawlText(print);
            }

            Console.WriteLine();

            if (wait)
            {
                if (Key() == ConsoleKey.Escape)
                {
                    Game.Pause();
                }
            }
        }

        public static void Crawl(Align alignment, params string[] text)
        {
            Crawl(alignment, true, text);
        }

        public static void Crawl(params string[] text)
        {
            Crawl(Align.Left, text);
        }

        private static void CrawlText(string text)
        {
            foreach (char character in text)
            {
                string cha = character.ToString();
                Console.Write(cha);
                if (Console.KeyAvailable)
                {
                    continue;
                }

                else if (cha == ",")
                {
                    Wait(200);
                }

                else if (cha == ".")
                {
                    Wait(500);
                }

                else
                {
                    Wait(50);
                }
            }

            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        public static bool Confirm(string text, Align alignment = Align.Left)
        {
            Text(alignment, false, $"{text} (ENTER to confirm, any other key to deny)");

            ConsoleKey key = Key();
            if (key == ConsoleKey.Enter)
            {
                return true;
            }

            return false;
        }

        public static void CenterVertical(int lines)
        {
            for (int i = 0; i < (Console.WindowHeight - lines) / 2; i++)
            {
                Console.WriteLine();
            }
        }

        public static void Wait(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        public static ConsoleKey Key(out ConsoleKeyInfo info)
        {
            while (Console.KeyAvailable)    // this clears the buffer of keys stacked up on each other
                Console.ReadKey(true);
            info = Console.ReadKey(true);
            return info.Key;
        }

        public static ConsoleKey Key()
        {
            return Key(out _);
        }
    }
}