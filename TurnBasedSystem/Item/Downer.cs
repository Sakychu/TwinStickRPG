using RpgRougeliketest.TurnBasedSystem.UnitEffects;
using RpgRougeliketest.TurnBasedSystem.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Item
{
    internal class Downer : BaseItem
    {
        public Downer() : base(nameof(Downer), "Doubles damage if you dodge in to the bottom Row!")
        {
        }

        internal override void onAttack(BaseUnit me, BaseUnit? other)
        {
            base.onAttack(me, other);
            if(me.blockPos.Bottom || me.blockPos.BottomRight|| me.blockPos.BottomLeft)
            {
                //me.AddEffect(new AttackUp(1, 1, UnitEffects.DurationType.Attacks));
                me.currentStates.mAttackMod = 2f;
            }
        }
    }
}
