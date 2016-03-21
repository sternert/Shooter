using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    public class Wave {
        public int WaveNumber { get; set; }
        public int NumberOfAsteroids { get; set; }
        public float SpeedMultiplier { get; set; }
        public float AsteroidDelay { get; set; }
        public IList<WaveAsteroid> WaveAsteroids { get; set; }
    }

    public class WaveAsteroid {
        public Asteroid Asteroid { get; set; }
        public float ProbabilityWeight { get; set; }
    }
}