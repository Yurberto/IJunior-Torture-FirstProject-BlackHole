using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Hole
{
    public class AbsorbBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private AbsorbHandler _absorbHandler;

        public void Init(AbsorbHandler absorbHandler)
        {
            if (absorbHandler == null)
                throw new ArgumentNullException(nameof(absorbHandler));

            _slider.value = 0;

            _absorbHandler = absorbHandler;
        }

        public void Subscribe()
        {
            if (_absorbHandler == null)
                throw new ArgumentNullException(nameof(_absorbHandler));

            _absorbHandler.AbsorptionProgressUpdated += UpdateProgress;
        }

        public void Unsubscribe()
        {
            if (_absorbHandler == null)
                throw new ArgumentNullException(nameof(_absorbHandler));

            _absorbHandler.AbsorptionProgressUpdated -= UpdateProgress;
        }

        private void UpdateProgress(float fillRatio)
        {
            _slider.value = Mathf.Clamp01(fillRatio);
        }
    }
}


