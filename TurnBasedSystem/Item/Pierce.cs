using RpgRougeliketest.TurnBasedSystem.UnitEffects;
using RpgRougeliketest.TurnBasedSystem.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Item
{
    internal class Pierce : BaseItem
    {
        public Pierce() : base(nameof(Pierce), "If miss, attack the next Enemy in line.")
        {
        }

        internal override void onGet(BaseUnit me)
        {
            base.onGet(me);
            me.mPiercingAttacks = true;
        }

    }
}
