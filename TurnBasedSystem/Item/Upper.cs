using RpgRougeliketest.TurnBasedSystem.UnitEffects;
using RpgRougeliketest.TurnBasedSystem.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Item
{
    internal class Upper : BaseItem
    {
        public Upper() : base(nameof(Upper), "Doubles damage if you dodge in the top row!") 
        {
        }

        internal override void onAttack(BaseUnit me, BaseUnit? other)
        {
            base.onAttack(me, other);
            if(me.blockPos.Top || me.blockPos.TopLeft || me.blockPos.TopRight)
            {
                //me.AddEffect(new AttackUp(1, 1, UnitEffects.DurationType.Attacks));
                me.currentStates.mAttackMod = 2f;
            }
        }
    }
}
