using RpgRougeliketest.TurnBasedSystem.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Units.Enemys
{
    public class EnemyBoss : Enemy
    {
        public EnemyBoss() : base(128, 128) { ChangeStates(5f, 3f, 0f, 0f, 0f); skillList.Add(new HitPattern());
            choosenSkillIndex = 0;
        }

        public override void onDeath()
        {
            base.onDeath();
            //TBS.gTBS.AddEnemy(new Enemy());
        }

        public override void onDamageTaken(BaseUnit other, float damage)
        {
            base.onDamageTaken(other, damage);
            var choosenPos = new BlockPosition(0);
            choosenPos.Clear();
            choosenPos.SetById((ushort)TBS.gTBS.mRand.Next(9));
            nextBlockPos = choosenPos;
        }

        internal void IntentNextTurn()
        {
            
        }
    }
}
