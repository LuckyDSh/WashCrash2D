using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
    #region Variables 
    [HideInInspector] public static Slider s_meltBarSlider;
    public float timeFlow = 5f;
    public static float maxTime = 100f;
    public static float initialTime;
    public Gradient gradient;
    public Image fill;
    private new Animation animation;
    [HideInInspector]
    public static bool isOn;
    #endregion

    #region UnityMethods
    private void Start()
    {
        maxTime = 100f;
        animation = GetComponent<Animation>();
        initialTime = maxTime;
        s_meltBarSlider = gameObject.GetComponent<Slider>();
        s_meltBarSlider.value = maxTime;
        isOn = true;
    }

    private void Update()
    {
        if (isOn)
        {
            maxTime -= Time.deltaTime * timeFlow;
            SetProgress(maxTime);
        }
        if (LevelUp.s_isOnNewLevel)
        {
            StartCoroutine(FreezeMeltBar());
            LevelUp.s_isOnNewLevel = false;
        }
    }
    #endregion

    public void SetMaxValue(int maxvalue)
    {
        s_meltBarSlider.maxValue = maxvalue;
        s_meltBarSlider.value = maxvalue;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetProgress(float value)
    {
        s_meltBarSlider.value = value;

        fill.color = gradient.Evaluate(s_meltBarSlider.normalizedValue);//
    }

    public IEnumerator FreezeMeltBar()
    {
        // set the MeltBar to max
        s_meltBarSlider.value = s_meltBarSlider.maxValue;
        isOn = false;
        maxTime = initialTime;
        animation.Play();

        // make ut stay for 3 sec
        yield return new WaitForSeconds(3f);

        // turn on the timer again
        animation.Stop();
        isOn = true;
    }

}
