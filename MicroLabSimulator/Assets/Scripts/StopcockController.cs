using UnityEngine;
using UnityEngine.UI;

public class StopcockController : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.onValueChanged.AddListener(UpdateFlow);
    }

    void UpdateFlow(float value)
    {
        if (GameManager.instance.currentStep != GameManager.Step.IndicatorAdded &&
            GameManager.instance.currentStep != GameManager.Step.Titrating)
        {
            slider.value = 0;
            return;
        }

        GameManager.instance.currentStep = GameManager.Step.Titrating;
        GameManager.instance.flowRate = value;
    }
}