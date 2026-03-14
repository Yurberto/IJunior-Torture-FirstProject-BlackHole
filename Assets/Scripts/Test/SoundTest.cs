using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Test
{
    public class SoundTest : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _audioSource;
        private void OnEnable()
        {
            _button.onClick.AddListener(_audioSource.Play);
        }
    }
}
