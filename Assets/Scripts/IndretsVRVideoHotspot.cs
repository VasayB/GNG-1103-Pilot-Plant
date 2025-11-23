using System.Collections;
using UnityEngine;
using UnityEngine.Video;

namespace IndretsVRVirtualTour
{
    public class IndretsVRVideoHotspot : MonoBehaviour
    {
        [Header("Video to play")]
        public VideoPlayer videoPlayer;

        [Header("Camera positions")]
        public Transform targetCameraPoint;      // Where camera moves to watch
        public Transform returnCameraPoint;      // Where camera goes after video ends

        private Vector3 savedCamPos;
        private Quaternion savedCamRot;
        private bool hasSavedCamera = false;

        private void Start()
        {
            if (videoPlayer != null)
            {
                videoPlayer.playOnAwake = false;
                videoPlayer.Stop();
                videoPlayer.gameObject.SetActive(true);

                // Listen for when video finishes
                videoPlayer.loopPointReached += OnVideoFinished;
            }
        }

        public void ActivateHotspot()
        {
            StartCoroutine(PlayVideoRoutine());
        }

        private IEnumerator PlayVideoRoutine()
        {
            Camera cam = Camera.main;

            if (cam != null)
            {
                // Save camera position BEFORE teleport
                if (!hasSavedCamera)
                {
                    savedCamPos = cam.transform.position;
                    savedCamRot = cam.transform.rotation;
                    hasSavedCamera = true;
                }

                // Move camera to video view
                if (targetCameraPoint != null)
                {
                    cam.transform.position = targetCameraPoint.position;
                    cam.transform.rotation = targetCameraPoint.rotation;
                }
            }

            // Play the video
            if (videoPlayer != null)
            {
                videoPlayer.Stop();
                videoPlayer.Play();
            }

            yield break;
        }

        private void OnVideoFinished(VideoPlayer vp)
        {
            Camera cam = Camera.main;

            // Stop video + hide quad (optional)
            if (videoPlayer != null)
            {
                videoPlayer.Stop();
                videoPlayer.gameObject.SetActive(false);
            }

            // Return camera to a view
            if (cam != null)
            {
                if (returnCameraPoint != null)
                {
                    cam.transform.position = returnCameraPoint.position;
                    cam.transform.rotation = returnCameraPoint.rotation;
                }
                else if (hasSavedCamera)
                {
                    cam.transform.position = savedCamPos;
                    cam.transform.rotation = savedCamRot;
                }
            }

            hasSavedCamera = false;
        }

        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ActivateHotspot();
            }
        }

        private void OnDestroy()
        {
            if (videoPlayer != null)
            {
                videoPlayer.loopPointReached -= OnVideoFinished;
            }
        }
    }
}
