using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapsMat; // Rename to trapsMat
    public Material goalMat;

    public Toggle colorblindMode;

    private void Start()
    {
        // Subscribe to the onValueChanged event of the colorblindMode toggle
        if (colorblindMode != null)
        {
            colorblindMode.onValueChanged.AddListener(OnColorblindModeChanged);
        }

        // Manually trigger the event once to test
        OnColorblindModeChanged(colorblindMode.isOn);
    }

    private void OnColorblindModeChanged(bool newValue)
    {
        Debug.Log("OnColorblindModeChanged method called. New value: " + newValue);

        if (newValue)
        {
            // Colorblind mode is on
            Debug.Log("Setting colors for Colorblind Mode ON");
            trapsMat.color = new Color32(255, 112, 0, 1); // Orange color
            goalMat.color = Color.blue;
        }
        else
        {
            // Colorblind mode is off
            Debug.Log("Setting colors for Colorblind Mode OFF");
            trapsMat.color = new Color32(255, 0, 0, 1); // Original red color
            goalMat.color = new Color32(0, 255, 0, 1); // Original green color
        }
    }

    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");
    }

    public void QuitMaze()
    {
        Debug.Log("Quit Game");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
