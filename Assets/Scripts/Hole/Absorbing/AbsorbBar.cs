using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Hole
{
    public class AbsorbBar : MonoBehaviour
    {
        [SerializeField] private Image _filled;

        private AbsorbHandler _absorbHandler;

        public void Init(AbsorbHandler absorbHandler)
        {
            if (absorbHandler == null)
                throw new ArgumentNullException(nameof(absorbHandler));

            _filled.type = Image.Type.Filled;
            _filled.fillMethod = Image.FillMethod.Horizontal;
           _filled.fillAmount = 0;

            _absorbHandler = absorbHandler;

            _absorbHandler.AbsorptionProgressChanged += OnAbsorptionProgressChanged;
        }

        public void Dispose()
        {
            _absorbHandler.AbsorptionProgressChanged -= OnAbsorptionProgressChanged;
        }

        private void OnAbsorptionProgressChanged(float fillRatio)
        {
            _filled.fillAmount = Mathf.Clamp01(fillRatio);
            Debug.Log($"AbsorbBar_OnAbsorptionProgressChanged({fillRatio})");
        }
    }
}


