using RpgRougeliketest.TurnBasedSystem.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Units.Enemys
{
    public class Advanced : Enemy
    {
        public Advanced() : base(64, 128) { ChangeStates(2f, 1f, 0f, 0f, 0f); skillList.Add(new HitRandom(2));
            choosenSkillIndex = 0;
            unitColor = Brushes.Yellow;
            var choosenPos = new BlockPosition(0);
            choosenPos.Clear();
            choosenPos.SetById((ushort)TBS.gTBS.mRand.Next(9));
            nextBlockPos = choosenPos;
            blockPos = choosenPos;
        }

        public override void onDeath()
        {
            base.onDeath();
            //TBS.gTBS.AddEnemy(new Enemy());
        }

        internal override void IntentNextTurn()
        {
            var choosenPos = new BlockPosition(0);
            choosenPos.Clear();
            choosenPos.SetById((ushort)TBS.gTBS.mRand.Next(9));
            nextBlockPos = choosenPos;

            targetPos = TBS.gTBS.Player.blockPos;
            ShowTarget = false;

        }
    }
}
