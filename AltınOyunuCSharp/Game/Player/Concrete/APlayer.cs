﻿using AltınOyunuCSharp.Game.Map.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Player.Concrete
{
    public class APlayer : Player
    {
        public APlayer(int gold, string name, int cordY, int cordX, int cost, int moveLenght) : base(gold, name, cordY, cordX, cost, moveLenght)
        {
        }

        public override int[] SearchForGold(IMap map)
        {
            List<string> goldSquareList = map.GetGoldList();
            int minY = int.MaxValue, minX = int.MaxValue,totalMin = int.MaxValue;


            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXX");
            goldSquareList.ForEach(Console.WriteLine);
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXX");

            foreach (var item in goldSquareList)
            {
                string[] goldCordData = item.Split(',');
                int min = Math.Abs(this.lastYCord - Int32.Parse(goldCordData[0])) + Math.Abs(this.lastXCord - Int32.Parse(goldCordData[1]));
                if (min < totalMin)
                { 
                    totalMin = min; 
                    minY = Int32.Parse(goldCordData[0]); 
                    minX = Int32.Parse(goldCordData[1]); }
            }


            int[] selectedGold= { minY, minX };
            this.SetLog("Hedef: Y:" + minY + " X:" + minX + " olarak belirlendi.");
            this.SetTargetedGold(minY, minX);
            return selectedGold;
            
        }
    }
}
