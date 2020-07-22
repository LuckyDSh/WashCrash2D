using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Slider slider;
    public static int progress = 0;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
    }

    private void Update()
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
