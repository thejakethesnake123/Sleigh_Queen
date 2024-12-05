using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class StartSceneEnter : MonoBehaviour
    // Start is called once before the first execution of Update after the MonoBehaviour is created
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        // Get the VideoPlayer component
        videoPlayer = GetComponent<VideoPlayer>();

        // Add a listener for the loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video finished! Loading next scene...");
        SceneManager.LoadScene(1); // Replace "NextScene" with your scene's name
    }
}
