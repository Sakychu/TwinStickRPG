using RpgRougeliketest.TurnBasedSystem.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.Units.Enemys
{
    internal class Slime : Enemy
    {
        public Slime() : base(64, 64)
        {
            ChangeStates(2f, 1f, 0f, 0f, 0f); skillList.Add(new HitRandom());
            choosenSkillIndex = 0;
            var choosenPos = new BlockPosition(0);
            choosenPos.Clear();
            choosenPos.SetById((ushort)TBS.gTBS.mRand.Next(9));
            nextBlockPos = choosenPos;
            blockPos = choosenPos;
        }

        public override Bitmap getImage()
        {
            if (img == null)
                img = loadImage("Slime2");
            return new Bitmap(img);
        }

    }
}
