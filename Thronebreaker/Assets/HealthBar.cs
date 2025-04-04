using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        Debug.Log($"Max health set to {health}");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
