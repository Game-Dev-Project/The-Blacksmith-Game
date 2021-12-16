using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient grad;
    public Image fill;
    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = grad.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        fill.color = grad.Evaluate(slider.normalizedValue);
    }
}
