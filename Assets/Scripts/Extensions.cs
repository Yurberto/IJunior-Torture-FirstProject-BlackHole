using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public static class Extensions
    {
        public static float FloatToDecibel(this float value)
        {
            float decibel;

            if (value <= 0.0001f)
            {
                decibel = -80f;
            }
            else
            {
                decibel = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
                decibel = Mathf.Clamp(decibel, -80f, 0f);
            }

            return decibel;
        }
    }
}
