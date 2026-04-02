using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.AbilitySystem
{
    public class AbilityUpgraderView : MonoBehaviour
    {
        [SerializeField] private Sprite _defaultIcon;
        [SerializeField] private Sprite _upgradeAvailableIcon;
        [Space]
        [SerializeField] private Image _imageSource;
        [SerializeField] private Button _upgradeButton;
        [Space]
        [SerializeField] private ParticleSystem _upgradeEffect;
        [SerializeField] private AudioSource _upgradeSound;

        private AbilityUpgrader _abilityUpgrader;

        public void Init(AbilityUpgrader abilityUpgrader)
        {
            if (abilityUpgrader == null)
                throw new ArgumentNullException(nameof(abilityUpgrader));

            _abilityUpgrader = abilityUpgrader;
            _upgradeButton.interactable = false;

            UpdateUpgradeAvailabilityInfo(_abilityUpgrader.CanUpgrade);
        }

        public event Action UpgradeButtonClicked;

        public void Subscibe()
        {
            _abilityUpgrader.Upgraded += OnUpgraded;
            _abilityUpgrader.UpgradeAvailabilityToggled += UpdateUpgradeAvailabilityInfo;

            _upgradeButton.onClick.AddListener(OnUpgradeButtonClicked);
        }

        public void UnSubscribe()
        {
            _abilityUpgrader.Upgraded -= OnUpgraded;
            _abilityUpgrader.UpgradeAvailabilityToggled -= UpdateUpgradeAvailabilityInfo;

            _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClicked);
        }

        private void OnUpgraded()
        {
            
            Debug.Log("MakeEffectsGreatAgain");

            StartCoroutine(PlayUpgradeAnimation());
        }

        private void UpdateUpgradeAvailabilityInfo(bool canUpgrade)
        {
            _upgradeButton.interactable = canUpgrade;
            _imageSource.sprite = canUpgrade ? _upgradeAvailableIcon : _defaultIcon;
        }

        private void OnUpgradeButtonClicked()
        {
            UpgradeButtonClicked?.Invoke();
        }

        private System.Collections.IEnumerator PlayUpgradeAnimation()
        {
            Color originalColor = _imageSource.color;
            _imageSource.color = Color.white;

            yield return new WaitForSeconds(0.1f);

            _imageSource.color = originalColor;
        }
    }
}