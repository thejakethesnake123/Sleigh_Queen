using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndRunSequence : MonoBehaviour
{
    public GameObject liveDis;
    public GameObject endScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(1);
        liveDis.SetActive(false);
        endScreen.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(1);

    }


 
}
