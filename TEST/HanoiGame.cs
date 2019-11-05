﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TEST
{
    public class HanoiGame
    {
        int disk;
        int from;
        int to;
        int aux = 0;

        public void Setup()
        {
            try
            {
                //輸入高度
                Console.WriteLine("請輸入河內塔的高度：");
                string input = Console.ReadLine();
                disk = int.Parse(input);


                Console.WriteLine("起始地的柱子:(1,2,3)");
                input = Console.ReadLine();
                from = int.Parse(input);

                Console.WriteLine("目的地的柱子：(1,2,3)");
                input = Console.ReadLine();
                to = int.Parse(input);

            }
            catch (FormatException)
            {
                Console.WriteLine("輸入錯誤請輸入數字");
                Setup();
            }
            catch (OverflowException)
            {
                Console.WriteLine("爆炸了QAQ,請重新輸入");
                Setup();
            }
            #region // 取得 第三柱子
            /* 例如 輸入 1 3  得到  2
             *      輸入 1 2  得到  3
             *      輸入 2 3  得到  1
             */

            int[] temp = { 1, 2, 3 };
            foreach (int item in temp)
            {
                if (item != from && item != to)
                {
                    aux = item;
                    break;
                }
            }
            #endregion

        }
        public void Paly()
        {
            while (from > 3 || from < 1 || to < 1 || to > 3 || from == to || disk < 1)
            {
                if (disk < 1)
                {
                    Console.WriteLine("最低要有一層才能玩!!");
                    Console.WriteLine("==============================");
                    Setup();
                }
                else if(from>3||from<0)
                {
                    Console.WriteLine("輸入錯誤!! 起始點只能輸入1~3。");
                    Console.WriteLine("==============================");
                    Setup();
                }
                else if(to>3||to<1)
                {
                    Console.WriteLine("輸入錯誤!! 目的地只能輸入1~3。");
                    Console.WriteLine("==============================");
                    Setup();
                }
                else if (from == to)
                {
                    Console.WriteLine("起始點不能和目的地一樣啦!!");
                    Console.WriteLine("==============================");
                    Setup();
                }
               
            }
            Hanoi(disk, from, to, aux);
            Exit();
        }
        public void Exit()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("是否在玩一次? <Y/N>");
            try
            {
                string input = Console.ReadLine();
                string x = input;
                if (x == "Y" || x == "y")
                {
                    Setup();
                    Paly();
                }
                else if (x == "N" || x == "n")
                {
                    Console.WriteLine("感謝你的遊玩");
                }
                else
                {
                    Console.WriteLine("輸入錯誤請輸入<Y/N>");
                    Exit();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("輸入錯誤，請重新輸入");
                Exit();
            }
        }

        public static void Hanoi(int Disk, int Src, int Dest, int Aux)
        {
            if (Disk == 1)
            {
                Console.WriteLine($"將第{Disk}個圓盤由{Src}移到{Dest} ");
            }
            else
            {
                Hanoi(Disk - 1, Src, Aux, Dest);
                Console.WriteLine($"將第{Disk}個圓盤由{Src}移到{Dest} ");
                Hanoi(Disk - 1, Aux, Dest, Src);
            }
        }








    }
}
