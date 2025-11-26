using UnityEngine;
using UnityEngine.Video;
using System.IO;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string fileName = "FIXED_VIDEO.mp4";

    private bool isPrepared = false;

    void Start()
    {
        string path = Path.Combine(Application.streamingAssetsPath, fileName);

#if UNITY_ANDROID && !UNITY_EDITOR
        path = "file://" + path;
#endif

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = path;

        videoPlayer.prepareCompleted += Prepared;
        videoPlayer.Prepare(); // start preparing
    }

    private void Prepared(VideoPlayer vp)
    {
        isPrepared = true;
        Debug.Log("Video is ready to play!");
    }

    // Called by your Play button
    public void PlayVideo()
    {
        if (!isPrepared)
        {
            Debug.LogWarning("Video not ready yet!");
            return;
        }

        if (!videoPlayer.isPlaying)
            videoPlayer.Play();
    }
}
