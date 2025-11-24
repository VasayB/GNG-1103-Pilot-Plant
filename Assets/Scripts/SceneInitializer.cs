using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public Material skyboxMaterial; // assign this in inspector for each scene

    void Start()
    {
        if (skyboxMaterial != null)
        {
            RenderSettings.skybox = skyboxMaterial;
            DynamicGI.UpdateEnvironment();
        }
    }
}
