namespace RpgRougeliketest.TurnBasedSystem.Units
{
    public class Stats
    {
        internal float mAttack = 1f;
        internal float mAttackMod = 1f;
        internal float mDefence = 0f;
        internal float mDefenceMod = 1f;
        internal float mHealth = 5f;
        internal float mHealthMod = 1f;
        internal float mMagic = 0f;
        internal float mMagicMod = 1f;
        internal float mSpeed = 0f;
        internal float mSpeedMod = 1f;

        internal bool mInvul = false;

        public Stats(float mHealth, float mAttack, float mDefence, float mSpeed, float mMagic)
        {
            this.mHealth = mHealth;
            this.mAttack = mAttack;
            this.mDefence = mDefence;
            this.mSpeed = mSpeed;
            this.mMagic = mMagic;
        }

        public void ResetMod()
        {
            mAttackMod = 1f;
            mDefenceMod = 1f;
            mHealthMod = 1f;
            mMagicMod = 1f;
            mSpeedMod = 1f;
        }

        public float CurrentAttack { get { return mAttack * mAttackMod; } }
        public float CurrentDefence { get { return mDefence * mDefenceMod; } }
        public float CurrentHealth { get { return mHealth * mHealthMod; } }
        public float CurrentMagic { get { return mMagic * mMagicMod; } }
        public float CurrentSpeed { get { return mSpeed * mSpeedMod; } }
    }
}