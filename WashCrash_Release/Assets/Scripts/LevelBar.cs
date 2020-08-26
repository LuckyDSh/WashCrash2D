using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Slider slider;
    public static int progress;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
        progress = 0;
    }

    private void FixedUpdate()
    {
        SetValue(progress);
    }

    public void SetMaxValue(int max)
    {
        slider.maxValue = max;
    }

    public void SetValue(int value)
    {
        slider.value = value;
    }

}
