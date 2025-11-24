using UnityEngine;

public class SkyboxSwitcher : MonoBehaviour
{
    public Material[] skyboxes;   // your skybox array

    public void ChangeSkybox(int index)
    {
        if (index >= 0 && index < skyboxes.Length)
        {
            RenderSettings.skybox = skyboxes[index];
            DynamicGI.UpdateEnvironment(); // updates lighting
        }
    }
}
