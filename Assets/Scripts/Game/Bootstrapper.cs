using UnityEngine;

namespace Assets.Scripts.Game
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private _Game _game;

        private void Awake()
        {
            Debug.Log("Awake_Bootstrapper");

            _game.Activate();
        }
    }
}
