using System;
using UnityEngine;

namespace Assets.Scripts.Game.Level
{
    public class Pauser
    {
        public void Pause()
        {
            Time.timeScale = 0.0f;
        }

        public void Unpause()
        {
            Time.timeScale = 1.0f;
        }
    }
}
