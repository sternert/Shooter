using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    public class Level
    {
        public string LevelName { get; set; }

        public Boss Boss { get; set; }

        public IList<Wave> Waves { get; set; }
    }
}
