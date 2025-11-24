using UnityEngine;

public class Hotspot : MonoBehaviour
{
    public int skyboxIndex;               // which skybox to switch to
    public SkyboxSwitcher switcher;       // reference to your switcher

    private void OnMouseDown()
    {
        switcher.ChangeSkybox(skyboxIndex);
    }
}
