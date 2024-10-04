using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RpgRougeliketest.TurnBasedSystem.Units.BaseUnit;

namespace RpgRougeliketest.TurnBasedSystem.Skills
{
    public class DamageDistro
    {
        internal int[] DamageGrid = new int[9];
        public int Top { get { return DamageGrid[1]; } internal set { DamageGrid[1] = value; } }
        public int Middle { get { return DamageGrid[4]; } internal set { DamageGrid[4] = value; } }
        public int Bottom { get { return DamageGrid[7]; } internal set { DamageGrid[7] = value; } }
        public int TopLeft { get { return DamageGrid[0]; } internal set { DamageGrid[0] = value; } }
        public int Left { get { return DamageGrid[3]; } internal set { DamageGrid[3] = value; } }
        public int BottomLeft { get { return DamageGrid[6]; } internal set { DamageGrid[6] = value; } }
        public int TopRight { get { return DamageGrid[2]; } internal set { DamageGrid[2] = value; } }
        public int Right { get { return DamageGrid[5]; } internal set { DamageGrid[5] = value; } }
        public int BottomRight { get { return DamageGrid[8]; } internal set { DamageGrid[8] = value; } }
        
        public DamageDistro() { }

        public DamageDistro(BlockPosition choosenPos, int dmg)
        {
            Top = choosenPos.Top ? dmg : 0;
            Bottom = choosenPos.Bottom ? dmg : 0;
            Left = choosenPos.Left ? dmg : 0;
            Right = choosenPos.Right ? dmg : 0;
            TopLeft = choosenPos.TopLeft ? dmg : 0;
            TopRight = choosenPos.TopRight ? dmg : 0;
            BottomLeft = choosenPos.BottomLeft ? dmg : 0;
            BottomRight = choosenPos.BottomRight ? dmg : 0;
            Middle = choosenPos.Middle ? dmg : 0;
        }

        internal int Get(BlockPosition.BlockPositions pos)
        {
            return DamageGrid[(int)pos];
        }

        internal bool IsEmpty()
        {
            bool empty = true;
            for(int i = 0; i < DamageGrid.Length;i++)
            {
                if(DamageGrid[i] > 0)
                    empty = false;
            }
            return empty;
        }

        internal int Get(BlockPosition currentBlockPos)
        {
            return DamageGrid[currentBlockPos.GetIndex()];
        }
    }
}
