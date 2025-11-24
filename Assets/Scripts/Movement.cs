using System.Collections;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public Material[] skyBoxes;
    private int index = 0;
    public float fadeDuration = 0.5f;


    void Start()
    {
        if (skyBoxes.Length > 0)
            RenderSettings.skybox = skyBoxes[index];
    }


    // Move forward
    public void NextSkybox()
    {
        index = (index + 1) % skyBoxes.Length;
        StartCoroutine(FadeSkybox(RenderSettings.skybox, skyBoxes[index]));
    }


    // Move backward
    public void PreviousSkybox()
    {
        if (index == 2)
        {
            index = (index + 2) % skyBoxes.Length;
            StartCoroutine(FadeSkybox(RenderSettings.skybox, skyBoxes[index]));
        }
        else if (index == 5)
        {
            index = 8;
            StartCoroutine(FadeSkybox(RenderSettings.skybox, skyBoxes[index]));
        }
        else
        {
            index = (index - 1 + skyBoxes.Length) % skyBoxes.Length;
            StartCoroutine(FadeSkybox(RenderSettings.skybox, skyBoxes[index]));
        }


    }


    private IEnumerator FadeSkybox(Material from, Material to)
    {
        Material sky1 = new Material(from);
        Material sky2 = new Material(to);
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float blend = t / fadeDuration;
            sky1.SetFloat("_Exposure", 1f - blend);
            sky2.SetFloat("_Exposure", blend);
            RenderSettings.skybox = blend < 0.5f ? sky1 : sky2;
            DynamicGI.UpdateEnvironment();
            yield return null;
        }
        RenderSettings.skybox = to;
    }
}



