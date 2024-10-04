using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgRougeliketest.TurnBasedSystem.UnitEffects
{
    internal class BaseUnitEffect
    {
        public enum DurationTypes
        {
            Turns,
            Attacks,
            EnemyAttacks,
            Dodges,
        }
        private float magnitued;
        private int duration;
        private DurationTypes durationtype;

        public float Magnitued { get => magnitued; set => magnitued = value; }
        public int Duration { get => duration; set => duration = value; }
        internal DurationTypes Durationtype { get => durationtype; }

        public BaseUnitEffect(float magnitued, int duration, DurationTypes DurationType)
        {
            this.magnitued = magnitued;
            this.duration = duration;
            this.durationtype = DurationType;
        }
    }

    
}
