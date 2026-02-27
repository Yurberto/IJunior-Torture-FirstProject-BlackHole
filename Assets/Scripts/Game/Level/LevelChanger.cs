using System;

namespace Assets.Scripts.Game
{
    public class LevelChanger
    {
        private Level[] _levels;

        private int _current = 0;

        public LevelChanger (Level[] levels)
        {
            if (levels == null)
                throw new ArgumentNullException(nameof(levels));

            _levels = levels;
        }

        public bool TryChangeToNext()
        {
            if (_current + 1 >= _levels.Length)
                return false;

            ++_current;
            return true;
        }
    }
}