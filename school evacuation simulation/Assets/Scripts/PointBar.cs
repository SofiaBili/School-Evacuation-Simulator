using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointBar : MonoBehaviour
{
    public Slider slider;
    public void SetPoints(int points){
        slider.value = points;
    }
}
