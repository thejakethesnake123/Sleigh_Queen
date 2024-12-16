using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndRunSequence : MonoBehaviour
{
    [SerializeField] GameObject liveDis;
    [SerializeField] GameObject endScreen;
    [SerializeField] AudioSource GameOver;
    [SerializeField] GameObject mainCam;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(1);
        mainCam.GetComponent<Animator>().enabled = true;
        liveDis.SetActive(false);
        GameOver.Play();

        endScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        GlobalMovement.paused = false;
        SceneManager.LoadScene(1);

    }


 
}
