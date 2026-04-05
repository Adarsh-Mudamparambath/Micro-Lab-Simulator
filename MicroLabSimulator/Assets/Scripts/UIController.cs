using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI instructionText;
    public GameObject startPanel;

    public void StartExperiment()
    {
        AudioManager.instance.PlayClick();
        startPanel.SetActive(false);
        GameManager.instance.currentStep = GameManager.Step.Start;
        instructionText.text = "Step 1: Click Fill Burette";
    }

    public void FillBurette()
    {
        AudioManager.instance.PlayClick();
        if (GameManager.instance.currentStep != GameManager.Step.Start)
        {
            instructionText.text = "❌ You must start first!";
            AudioManager.instance.PlayError();
            return;
        }

        GameManager.instance.buretteVolume = 50f;
        GameManager.instance.currentStep = GameManager.Step.Filled;

        instructionText.text = "Step 2: Set Initial Reading";
    }

    public void SetInitialReading()
    {
        AudioManager.instance.PlayClick();
        if (GameManager.instance.currentStep != GameManager.Step.Filled)
        {
            instructionText.text = "❌ Fill burette first!";
            AudioManager.instance.PlayError();
            return;
        }

        GameManager.instance.initialReading = GameManager.instance.buretteVolume;
        GameManager.instance.currentStep = GameManager.Step.InitialSet;

        // AudioManager.instance.PlaySuccess();

        instructionText.text = "Step 3: Add Indicator";
    }
    public void AddIndicator()
    {
        AudioManager.instance.PlayClick();

        if (GameManager.instance.currentStep != GameManager.Step.InitialSet)
        {
            instructionText.text = "❌ Set initial reading first!";
            AudioManager.instance.PlayError();
            return;
        }

        GameManager.instance.currentStep = GameManager.Step.IndicatorAdded;

        instructionText.text = "Step 4: Start Titration (use slider)";
    }
    public TextMeshProUGUI readingText;

    void Update()
    {
        readingText.text = "Burette: " + GameManager.instance.buretteVolume.ToString("F2") + " mL";
    }

    public GameObject resultPanel;
    public TextMeshProUGUI resultText;

    public void ShowResult()
    {
        float used = GameManager.instance.initialReading - GameManager.instance.finalReading;

        resultPanel.SetActive(true);

        resultText.text =
            "Initial: " + GameManager.instance.initialReading.ToString("F2") +
            "\nFinal: " + GameManager.instance.finalReading.ToString("F2") +
            "\nUsed: " + used.ToString("F2") + " mL";
    }

    public UnityEngine.UI.Slider stopcockSlider;

    public void ResetExperiment()
    {
        AudioManager.instance.PlayClick();
        GameManager.instance.ResetAll();

        instructionText.text = "Click Start to begin";
        resultPanel.SetActive(false);
        stopcockSlider.value = 0f;
        FindObjectOfType<FlaskController>().ResetFlask();
    }

    public void ExitGame()
    {
        AudioManager.instance.PlayClick();

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void BackToStartPanel()
    {
        startPanel.SetActive(true);


    }
}