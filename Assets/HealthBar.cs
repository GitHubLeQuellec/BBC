using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider Slider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetMaxhealth(int health)
    {
        Slider.maxValue = health;
        Slider.value = health;
    }
    public void SetHealth(int health)
    {
        Slider.value = health;
    }
}
