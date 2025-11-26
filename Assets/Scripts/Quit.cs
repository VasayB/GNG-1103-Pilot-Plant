using UnityEngine;

public class QuitButton : MonoBehaviour
{
    // Call this function from your UI button or XR interactable
    public void QuitGame()
    {
        Debug.Log("Quit button pressed.");

        // If running in the editor, stop play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running in a build, quit the application
        Application.Quit();
#endif
    }
}