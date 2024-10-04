using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Units
{
    public partial class BaseUnit
    {
        public virtual void onDamageTaken(BaseUnit other, float damage)
        {
        }

        public virtual void onDamageDealt(BaseUnit other, float damage)
        {
        }

        public virtual void onUnitKilled(BaseUnit other)
        {
        }

        public virtual void onDeath()
        {
        }
        public virtual void onAttack(BaseUnit? other)
        {
        }
    }
}
