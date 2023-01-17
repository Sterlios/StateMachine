using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void Initialize(float startValue)
    {
        _slider.value = startValue;
    }

    public void OnValueChanged(int value, int maxValue)
    {
        _slider.value = (float)value / maxValue;
    }
}
