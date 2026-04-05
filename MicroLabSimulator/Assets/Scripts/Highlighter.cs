using UnityEngine;

public class Highlighter : MonoBehaviour
{
    public GameObject fillBtn;
    public GameObject initialBtn;
    public GameObject indicatorBtn;
    public GameObject slider;

    void Update()
    {
        var step = GameManager.instance.currentStep;

        fillBtn.SetActive(step == GameManager.Step.Start);
        initialBtn.SetActive(step == GameManager.Step.Filled);
        indicatorBtn.SetActive(step == GameManager.Step.InitialSet);
        slider.SetActive(step == GameManager.Step.IndicatorAdded || step == GameManager.Step.Titrating);
    }
}