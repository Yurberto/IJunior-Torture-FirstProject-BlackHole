using UnityEngine;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelHub : MonoBehaviour
    {
        [SerializeField] private Level[] _levels;

        private int _current = 0;

        public Level GetCurrent()
        {
            return _levels[_current];
        }
    }
}
