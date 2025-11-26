using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitGameButton()
    {
        Debug.Log("Quit button pressed.");
        Application.Quit();
    }
}
