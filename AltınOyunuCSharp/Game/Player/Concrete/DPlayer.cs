using AltınOyunuCSharp.Game.Map.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Player.Concrete
{
    public class DPlayer : Player
    {
        public DPlayer(int gold, string name, int cordY, int cordX, int cost, int moveLenght) : base(gold, name, cordY, cordX, cost, moveLenght)
        {
        }

        public override int[] SearchForGold(IMap map)
        {
            List<string> goldSquareList = map.GetGoldList();
            throw new NotImplementedException();
        }
    }
}
