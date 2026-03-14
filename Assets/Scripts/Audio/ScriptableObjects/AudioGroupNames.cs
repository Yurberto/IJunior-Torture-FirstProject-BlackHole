using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    [CreateAssetMenu(fileName = nameof(AudioGroupNames), menuName = nameof(ScriptableObject) + "/" + nameof(AudioGroupNames))]
    public class AudioGroupNames : ScriptableObject
    {
        [SerializeField] private string _master = "MasterVolume";
        [SerializeField] private string _music = "MusicVolume";
        [SerializeField] private string _sfx = "SFXVolume";

        public string Master => _master;
        public string Music => _music;
        public string SFX => _sfx;
    }
}



