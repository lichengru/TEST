﻿using System;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            HanoiGame game = new HanoiGame();
            game.Setup();
            game.Paly();          
            Console.ReadKey();
        }
    }
}
