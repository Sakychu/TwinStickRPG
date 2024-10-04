using RpgRougeliketest.TurnBasedSystem.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Units.Enemys
{
    public class Chaser : Enemy
    {
        public Chaser() : base(64, 64) { ChangeStates(2f, 2f, 0f, 0f, 0f); skillList.Add(new HitSet());
            choosenSkillIndex = 0;
            unitColor = Brushes.Green;
            var choosenPos = new BlockPosition(0);
            choosenPos.Clear();
            choosenPos.SetById((ushort)TBS.gTBS.mRand.Next(9));
            nextBlockPos = choosenPos;
            blockPos = choosenPos;

            screenOffset.Y = 128;

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
            nextTargetPos = TBS.gTBS.Player.blockPos;
            GetSkill().Do(this, this);
            ShowTarget = true;

        }

        public override Bitmap getImage()
        {
            if (img == null)
                img = loadImage("SkeleHead2");
            return new Bitmap(img);
        }
    }
}
