using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.AbilityNew
{
    public class AbilityView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private TextMeshProUGUI _cost;
        [SerializeField] private TextMeshProUGUI _ratio;

        private Ability _ability;

        public void Init(Ability ability)
        {
            if (ability == null) 
                throw new ArgumentNullException(nameof(ability));

            _ability = ability;
            _name.text = _ability.Name;

            _ability.LevelUp += UpdateInfo;
            UpdateInfo();
        }

        public void Dispose()
        {
            _ability.LevelUp -= UpdateInfo;
        }

        private void UpdateInfo()
        {
            _level.text = _ability.Level.ToString();
            _cost.text = _ability.Cost.ToString();
            _ratio.text = _ability.Ratio.ToString();
        }
    }
}
