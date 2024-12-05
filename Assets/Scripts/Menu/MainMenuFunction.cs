using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour


{
    public AudioSource pressPlay;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void PlayGame()
    {
        //pressPlay.Play();
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
