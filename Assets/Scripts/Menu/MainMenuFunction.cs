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
        pressPlay.Play();
        SceneManager.LoadScene(2);
    }

    void Awake()
    {
        DontDestroyOnLoad(pressPlay); // Keeps this GameObject alive across scenes
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
