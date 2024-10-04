using RpgRougeliketest.TurnBasedSystem.Events;
using RpgRougeliketest.TurnBasedSystem.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static RpgRougeliketest.TurnBasedSystem.BlockPosition;
using EventArgs = RpgRougeliketest.TurnBasedSystem.Events.EventArgs;

namespace RpgRougeliketest.TurnBasedSystem.Units
{
    public partial class BaseUnit
    {
        internal Stats baseStates = null;
        internal Stats currentStates = null;
        internal BlockPosition blockPos = new BlockPosition((ushort)BlockPositionsExp.Middle);
        internal BlockPosition? nextBlockPos = null;
        public BlockPosition CurrentBlockPos { get { return blockPos; } }
        public BlockPosition? NextBlockPos { get { return nextBlockPos; } }

        internal BlockPosition targetPos = new BlockPosition((ushort)BlockPositionsExp.Middle);
        internal BlockPosition? nextTargetPos = null;
        public BlockPosition CurrentTargetPos { get { return targetPos; } }
        public BlockPosition? NextTargetPos { get { return nextTargetPos; } }

        internal List<Skill> skillList = new List<Skill>();
        internal int choosenSkillIndex = -1;

        internal Brush unitColor = Brushes.Red;
        Size? mImageSize = null;
        public Size ImageSize { get { return mImageSize ?? new Size(0, 0); } }
        internal Vector2 screenOffset = new Vector2(0, 0);
        public Vector2 ScreenOffset { get => screenOffset; set => screenOffset = value; }
        public bool ShowNextMove { get; internal set; }
        public bool ShowTarget { get; internal set; }

        Bitmap mImage = null;

        internal bool mDead = false;
        internal bool mPiercingAttacks = false;

        public BaseUnit(int imageWidth, int imageHeight)
        {
            mImageSize = new Size(imageWidth, imageHeight);
            mImage = new Bitmap(imageWidth, imageHeight);
            ShowNextMove = false;
        }

        public BaseUnit() : this(256, 256) { }

        public virtual Bitmap getImage()
        {
            if (mImage == null)
                throw new Exception();
            if (mImage != null && mImageSize != null)
            {
                var drawingGraphics = Graphics.FromImage(mImage);
                drawingGraphics.FillRectangle(unitColor, 0, 0, (int)(mImageSize?.Width), (int)(mImageSize?.Height));
                drawingGraphics.DrawRectangle(Pens.Black, 0, 0, (int)(mImageSize?.Width), (int)(mImageSize?.Height));
                int halfHeight = (int)(mImageSize?.Height / 2);
                int halfWidth = (int)(mImageSize?.Width / 2);
                drawingGraphics.DrawRectangle(Pens.Black, 0, 0, halfWidth, halfHeight);
                drawingGraphics.DrawRectangle(Pens.Black, halfWidth, halfHeight, halfWidth, halfHeight);
            }
            return mImage;
        }

        public void ChangeStates(float mHealth, float mAttack, float mDefence, float mSpeed, float mMagic)
        {
            this.baseStates = new Stats(mHealth,  mAttack,  mDefence,  mSpeed,  mMagic);
            this.currentStates = new Stats(mHealth,  mAttack,  mDefence,  mSpeed,  mMagic);
        }

        public Skill? GetSkill()
        {
            if (choosenSkillIndex < 0 || choosenSkillIndex > skillList.Count)
                return null;

            return skillList[choosenSkillIndex];
        }

        internal void IntentMove(BlockPosition.BlockPositionsExp bp)
        {
            nextBlockPos = new BlockPosition((ushort)bp);
        }

        internal virtual Image loadImage(String name)
        {
            var img = Image.FromFile($"image\\units\\{name}.png");
            return img;
        }

    }
}
