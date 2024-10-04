using RpgRougeliketest.TurnBasedSystem.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Skills
{
    internal class HitRandom : Skill
    {
        private int HitCount = 1;
        BlockPosition choosenPos = new BlockPosition(0);
        public HitRandom() { choosenPos.SetById((ushort)TBS.gTBS.mRand.Next(9)); }
        public HitRandom(int hitcnt) { 
            HitCount = hitcnt;
            for (int i = 0; i < HitCount; i++)
            {
                choosenPos.SetById((ushort)TBS.gTBS.mRand.Next(9));
            }
        }

        public override DamageDistro Do(BaseUnit me, BaseUnit target)
        {
            DamageDistro dd = new DamageDistro(choosenPos, (int)me.currentStates.CurrentAttack);
            if(dd.IsEmpty())
            {
                choosenPos.Clear();
            }
            //dd.DamageGrid[choosenPos.GetIndex()] = (int)me.CurrentAttack;
            choosenPos.Clear();
            for(int i = 0; i < HitCount; i++)
            { 
                choosenPos.SetById((ushort)TBS.gTBS.mRand.Next(9));
            }
            return dd;
        }
        public override BlockPosition GetHitBox()
        {
            var hitBox = new BlockPosition();
            hitBox.SetById((ushort)1);

            return choosenPos;
        }

    }
}
