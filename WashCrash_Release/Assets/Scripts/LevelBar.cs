/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Slider slider;
    public static float progress; // used in LevelUp
    public static int decreaser = 10; // used in Enemy and LevelUp
    public static float slider_maxValue;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider_maxValue = slider.maxValue;
        slider.value = 0;
        progress = 0;
        decreaser = 10;
    }

    private void FixedUpdate()
    {
        SetValue(progress);
    }

    public void SetMaxValue(int max)
    {
        slider.maxValue = max;
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }

}
