using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public void ChangeSlider(float value)
    {
        GetComponent<Slider>().value = value;
    }

}
