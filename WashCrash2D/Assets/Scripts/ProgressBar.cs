using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public  Slider progressSlider;
    public float timeFlow = 5f;
    public static float maxTime = 100f;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        progressSlider.value = maxTime;
    }


    private void Update()
    {
        maxTime -= Time.deltaTime * timeFlow;
        SetProgress(maxTime);
    }

    public void SetMaxValue(int maxvalue)
    {
        progressSlider.maxValue = maxvalue;
        progressSlider.value = maxvalue;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetProgress(float value)
    {
        progressSlider.value = value;

        fill.color = gradient.Evaluate(progressSlider.normalizedValue);
    }

}
