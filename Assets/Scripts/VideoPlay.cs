using UnityEngine;
using UnityEngine.Video;

public class PlayVideoOnInteract : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void PlayVideo()
    {
        videoPlayer.Play();
    }
}
