using UnityEngine;

namespace Assets.Scripts.Test
{
    public class AbsorptionCounter
    {
        private int _absorptions = 0;

        public void Add()
        {
            Debug.Log($"FallingObjectAbsorbed - {++_absorptions}");
        }
    }
}
