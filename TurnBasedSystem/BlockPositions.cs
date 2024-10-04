using System.Diagnostics.CodeAnalysis;

namespace RpgRougeliketest.TurnBasedSystem
{
    public struct BlockPosition
    {
        private ushort pos = 0;

        public BlockPosition(ushort pos)
        {
            this.pos = pos;
        }

        public bool Top { get { return (pos & (ushort)BlockPositionsExp.Top) > 0; } set { pos |= (ushort)BlockPositionsExp.Top; if (!value) throw new ArgumentOutOfRangeException(); } }
        public bool Bottom { get { return (pos & (ushort)BlockPositionsExp.Bottom) > 0; } set { pos |= (ushort)BlockPositionsExp.Bottom; if (!value) throw new ArgumentOutOfRangeException(); } }
        public bool Left { get { return (pos & (ushort)BlockPositionsExp.Left) > 0; } set { pos |= (ushort)BlockPositionsExp.Left; if (!value) throw new ArgumentOutOfRangeException(); } }
        public bool Right { get { return (pos & (ushort)BlockPositionsExp.Right) > 0; } set { pos |= (ushort)BlockPositionsExp.Right; if (!value) throw new ArgumentOutOfRangeException(); } }
        public bool TopLeft { get { return (pos & (ushort)BlockPositionsExp.TopLeft) > 0; } set { pos |= (ushort)BlockPositionsExp.TopLeft; if (!value) throw new ArgumentOutOfRangeException(); } }
        public bool TopRight { get { return (pos & (ushort)BlockPositionsExp.TopRight) > 0; } set { pos |= (ushort)BlockPositionsExp.TopRight; if (!value) throw new ArgumentOutOfRangeException(); } }
        public bool BottomLeft { get { return (pos & (ushort)BlockPositionsExp.BottomLeft) > 0; } set { pos |= (ushort)BlockPositionsExp.BottomLeft; if (!value) throw new ArgumentOutOfRangeException(); } }
        public bool BottomRight { get { return (pos & (ushort)BlockPositionsExp.BottomRight) > 0; } set { pos |= (ushort)BlockPositionsExp.BottomRight; if (!value) throw new ArgumentOutOfRangeException(); } }
        public bool Middle { get { return (pos & (ushort)BlockPositionsExp.Middle) > 0; } set { pos |= (ushort)BlockPositionsExp.Middle; if (!value) throw new ArgumentOutOfRangeException(); } }

        public ushort Pos { get => pos; }

        public enum BlockPositionsExp : ushort
        {
            Top = 0b0000_0001,
            Bottom = 0b0000_0010,
            Left = 0b0000_1000,
            Right = 0b0000_0100,
            TopLeft = 0b0001_0000,
            TopRight = 0b0010_0000,
            BottomLeft = 0b0100_0000,
            BottomRight = 0b1000_0000,
            Middle = 0b1_0000_0000,
            All = 0b1_1111_1111,
        }

        public enum BlockPositions : ushort
        {
            Top,
            Bottom,
            Left,
            Right,
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            Middle
        }

        public static int GetIndex(BlockPositions bp)
        {
            int ret = 0;
            switch (bp)
            {
                case BlockPosition.BlockPositions.Top:
                    ret = 1;
                    break;
                case BlockPosition.BlockPositions.Middle:
                    ret = 4;
                    break;
                case BlockPosition.BlockPositions.Bottom:
                    ret = 7;
                    break;

                case BlockPosition.BlockPositions.TopLeft:
                    ret = 0;
                    break;
                case BlockPosition.BlockPositions.Left:
                    ret = 3;
                    break;
                case BlockPosition.BlockPositions.BottomLeft:
                    ret = 6;
                    break;

                case BlockPosition.BlockPositions.TopRight:
                    ret = 2;
                    break;
                case BlockPosition.BlockPositions.Right:
                    ret = 5;
                    break;
                case BlockPosition.BlockPositions.BottomRight:
                    ret = 8;
                    break;
            }
            return ret;
        }

        public int GetIndex()
        {
            int ret = 0;
            if (Top)
                ret = 1;
            if (Middle)
                ret = 4;
            if (Bottom)
                ret = 7;

            if (TopLeft)
                ret = 0;
            if (Left)
                ret = 3;
            if (BottomLeft)
                ret = 6;

            if (TopRight)
                ret = 2;
            if (Right)
                ret = 5;
            if (BottomRight)
                ret = 8;
            return ret;
        }

        internal static BlockPositions SingleFromNumber(ushort markedIndex)
        {
            if ((markedIndex & (ushort)BlockPositionsExp.Top) > 0)
            {
                return BlockPositions.Top;
            }
            if ((markedIndex & (ushort)BlockPositionsExp.Bottom) > 0)
            {
                return BlockPositions.Bottom;
            }
            if ((markedIndex & (ushort)BlockPositionsExp.Left) > 0)
            {
                return BlockPositions.Left;
            }
            if ((markedIndex & (ushort)BlockPositionsExp.Right) > 0)
            {
                return BlockPositions.Right;
            }
            if ((markedIndex & (ushort)BlockPositionsExp.TopLeft) > 0)
            {
                return BlockPositions.TopLeft;
            }
            if ((markedIndex & (ushort)BlockPositionsExp.TopRight) > 0)
            {
                return BlockPositions.TopRight;
            }
            if ((markedIndex & (ushort)BlockPositionsExp.BottomLeft) > 0)
            {
                return BlockPositions.BottomLeft;
            }
            if ((markedIndex & (ushort)BlockPositionsExp.BottomRight) > 0)
            {
                return BlockPositions.BottomRight;
            }
            if ((markedIndex & (ushort)BlockPositionsExp.Middle) > 0)
            {
                return BlockPositions.Middle;
            }
            throw new ArgumentOutOfRangeException();
        }

        internal bool GetByIndex(int id)
        {
            if (id == 1)
                return Top;
            else if (id == 4)
                return Middle;
            else if (id == 7)
                return Bottom;

            else if (id == 0)
                return TopLeft;
            else if (id == 3)
                return Left;
            else if (id == 6)
                return BottomLeft;

            else if (id == 2)
                return TopRight;
            else if (id == 5)
                return Right;
            else if (id == 8)
                return BottomRight;

            throw new ArgumentOutOfRangeException();
        }

        internal void Set(ushort value)
        {
            pos = value;
        }

        internal void SetById(ushort id)
        {
            if (id == 1)
                Top = true;
            if (id == 4)
                Middle = true;
            if (id == 7)
                Bottom = true;

            if (id == 0)
                TopLeft = true;
            if (id == 3)
                Left = true;
            if (id == 6)
                BottomLeft = true;

            if (id == 2)
                TopRight = true;
            if (id == 5)
                Right = true;
            if (id == 8)
                BottomRight = true;
        }

        internal void Clear()
        {
            pos = 0;
        }
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return pos == ((BlockPosition)obj).pos;
        }
    }
}
