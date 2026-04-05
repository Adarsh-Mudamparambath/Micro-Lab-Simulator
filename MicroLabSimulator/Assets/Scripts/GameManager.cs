using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum Step
    {
        Start,
        Filled,
        InitialSet,
        IndicatorAdded,
        Titrating,
        Completed
    }

    public Step currentStep = Step.Start;

    public float buretteVolume = 0f;
    public float usedVolume = 0f;
    public float flowRate = 0f;

    public float initialReading = 0f;
    public float finalReading = 0f;

    public float endpointThreshold = 18.6f;
    public bool endpointReached = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (currentStep == Step.Titrating && !endpointReached)
        {
            float delta = flowRate * Time.deltaTime * 5f;

            usedVolume += delta;
            buretteVolume -= delta;

            usedVolume = Mathf.Clamp(usedVolume, 0, 50);
            buretteVolume = Mathf.Clamp(buretteVolume, 0, 50);

            if (usedVolume >= endpointThreshold)
            {
                TriggerEndpoint();
            }
        }
    }

    void TriggerEndpoint()
    {
        endpointReached = true;
        currentStep = Step.Completed;
        finalReading = buretteVolume;
        AudioManager.instance.PlaySuccess();
        UIController ui = FindObjectOfType<UIController>();
        ui.ShowResult();
    }

    public void ResetAll()
{
    currentStep = Step.Start;
    buretteVolume = 0f;
    usedVolume = 0f;
    flowRate = 0f;
    endpointReached = false;
    initialReading = 0f;
    finalReading = 0f;
}
}