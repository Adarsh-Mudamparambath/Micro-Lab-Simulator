using UnityEngine;

public class FlaskController : MonoBehaviour
{
    public Renderer flaskRenderer;
    public Color normalColor = Color.clear;
    public Color endColor = Color.magenta;

    void Start()
    {
        flaskRenderer.material.color = normalColor;
    }

    void Update()
    {
        if (GameManager.instance.endpointReached)
        {
            flaskRenderer.material.color = endColor;
        }
    }

    public void ResetFlask()
{
    flaskRenderer.material.color = normalColor;
}
}