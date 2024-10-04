using RpgRougeliketest.TurnBasedSystem.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Skills
{
    internal class HitSet : Skill
    {
        BlockPosition choosenPos = new BlockPosition(0);
        public HitSet() { Do(null, null); }

        public override DamageDistro Do(BaseUnit me, BaseUnit target)
        {
            DamageDistro dd = new DamageDistro();
            if(me == null || target == null)
                return dd;
            //if (me != null)
            //{
            //    for (int i = 0; i < 9; i++)
            //    {
            //        if (i % 2 == (evenood ? 1 : 0))
            //            dd.DamageGrid[i] = (int)me.CurrentAttack;

            //    }
            //}
            dd.DamageGrid[me.targetPos.GetIndex()] = (int)me.currentStates.CurrentAttack;
            choosenPos.Clear();
            choosenPos = me.targetPos;
            //choosenPos.Clear();
            //for (int i = 0; i < 9; i++)
            //{

            //    if (i % 2 == (evenood ? 0 : 1))
            //        choosenPos.SetById((ushort)i);

            //}
            //evenood = !evenood;
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
