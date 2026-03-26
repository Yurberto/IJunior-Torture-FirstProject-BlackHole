using UnityEngine;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelFinisher
    {
        public void OnlevelFailed()
        {
            Debug.Log("LevelFailed_LevelFinisher");
        }

        public void OnLevelCompleted()
        {
            Debug.Log("LevelCompleted_LevelFinisher");
        }
    }
}
