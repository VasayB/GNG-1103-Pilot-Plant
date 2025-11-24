using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneHotspot : MonoBehaviour
{
    public string nextScene;

    void OnMouseDown()
    {
        StartCoroutine(GoToNext());
    }

    IEnumerator GoToNext()
    {
        // Fade out using our fader
        yield return SceneFader.Instance.StartCoroutine(SceneFader.Instance.FadeOut());

        // Load the next scene
        SceneManager.LoadScene(nextScene);
    }
}
