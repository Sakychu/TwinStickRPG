using RpgRougeliketest.TurnBasedSystem.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Units
{
    public class Player : BaseUnit
    {
        
        public Player() : base(72, 96) { 
            ChangeStates(10f, 1f, 0f, 1f, 1f);
            skillList.Add(new HitSet());
            choosenSkillIndex = 0;
            ShowNextMove = true;
            ShowTarget = true;
        }
        public override void onUnitKilled(BaseUnit other)
        {
            base.onUnitKilled(other);
            TBS.gTBS.TriggerAllItems(x => x.onUnitKilled(this, other));
        }
        public override void onDeath()
        {
            base.onDeath();
            TBS.gTBS.TriggerAllItems(x => x.onDeath(this));
        }
        public override void onDamageTaken(BaseUnit other, float damage)
        {
            base.onDamageTaken(other, damage);
            TBS.gTBS.TriggerAllItems(x => x.onDamageTaken(this, other, damage));
        }
        public override void onDamageDealt(BaseUnit other, float damage)
        {
            base.onDamageDealt(other, damage);
            TBS.gTBS.TriggerAllItems(x => x.onDamageDealt(this, other, damage));
        }
        public override void onAttack(BaseUnit? other)
        {
            base.onAttack(other);
            TBS.gTBS.TriggerAllItems(x => x.onAttack(this, other));
        }
    }
}
