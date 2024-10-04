using RpgRougeliketest.TurnBasedSystem.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Skills
{
    internal class HitAll : Skill
    {
        public HitAll() { }
        public override DamageDistro Do(BaseUnit me, BaseUnit target)
        {
            DamageDistro dd = new DamageDistro();
            for (int i = 0; i < dd.DamageGrid.Length; i++)
            {
                dd.DamageGrid[i] = (int)me.currentStates.CurrentAttack;
            }
            return dd;
        }

        public override BlockPosition GetHitBox()
        {
            return new BlockPosition((ushort)BlockPosition.BlockPositionsExp.All);
        }
    }
}
