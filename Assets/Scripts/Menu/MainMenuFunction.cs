using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    [SerializeField] GameObject resumeButton;
    public AudioSource pressPlay;
    void Start()
    {
        if (GlobalMovement.paused == true)
        {
            resumeButton.SetActive(true);
        }

        else
        {
            resumeButton.SetActive(false);
        }
    }
    void Update()
    {
        if (GlobalMovement.paused == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ResumeGame();
            }
        }
    }

    public void PlayGame()
    {
        pressPlay.Play();
        GlobalMovement.highScore = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ResumeGame()
    {
        pressPlay.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
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
