using UnityEngine;

namespace Assets.Scripts.Gameplay.Units
{
    public class Defender : Unit
    {

        public Defender(int level) : base(level)
        {
        }

        public int UpGradedGold { get; set; }
    }
}
