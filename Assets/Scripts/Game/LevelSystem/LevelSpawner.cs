using System;

namespace Assets.Scripts.Game.LevelGamplay
{
    public class LevelSpawner
    {
        private Level[] _levels;

        public LevelSpawner(Level[] levels)
        {
            if (levels == null)
                throw new ArgumentNullException(nameof(levels));

            _levels = levels;
        }

        public Level Spawn(int index)
        {
            if (index < 0 || index >= _levels.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            Level spawned = _levels[index];
            return spawned;
        }
    }
}
