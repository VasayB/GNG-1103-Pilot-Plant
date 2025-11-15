using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void LoadScene1()
    {
        SceneManager.LoadScene("Scene1");
    }
}
