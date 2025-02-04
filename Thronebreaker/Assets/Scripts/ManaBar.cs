using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxMana(int mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetMana(int mana)
    {
        slider.value = mana;
    }
}
