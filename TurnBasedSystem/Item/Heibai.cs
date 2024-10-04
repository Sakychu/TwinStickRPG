using RpgRougeliketest.TurnBasedSystem.UnitEffects;
using RpgRougeliketest.TurnBasedSystem.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Item
{
    internal class Heibai : BaseItem
    {
        public Heibai() : base(nameof(Heibai), "Triples damage if you dodge to the same spot as you attack!")
        {
        }

        internal override void onAttack(BaseUnit me, BaseUnit? other)
        {
            base.onAttack(me, other);
            if(me.blockPos.Pos == me.targetPos.Pos)
            {
                me.currentStates.mAttackMod = 3f;
            }
        }
    }
}
