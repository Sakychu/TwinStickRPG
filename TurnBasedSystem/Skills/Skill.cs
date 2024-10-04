using RpgRougeliketest.TurnBasedSystem.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Skills
{
    public abstract class Skill
    {

        public virtual DamageDistro Do(BaseUnit me, BaseUnit target)
        { 
            DamageDistro dd = new DamageDistro();
            for (int i = 0;i < dd.DamageGrid.Length; i++)
            {
                dd.DamageGrid[i] = (int)me.currentStates.CurrentAttack;
            }
            return dd;
        }

        public virtual BlockPosition GetHitBox()
        {
            return new BlockPosition(0b1_1111_1111);
        }
    }
}
