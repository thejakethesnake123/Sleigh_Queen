using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelStarter : MonoBehaviour
{
    //public GameObject mainCam;
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGo;
    public AudioSource readyFX;
    public AudioSource goFX;
    public GameObject levelControl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        levelControl.GetComponent<EndRunSequence>().enabled = false;
        //mainCam.GetComponent<Animator>().enabled = true;
        if (GlobalMovement.highScore == 0)
        {
            GlobalMovement.canMove = true;
            GlobalMovement.endGame = false;
            StartCoroutine(CountSequence());
        }


        else
        {
            goFX.Play();
            GlobalMovement.canMove = true;
            GlobalMovement.endGame = false;
        }

    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(0.5f);
        countDown3.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1f);
        countDown2.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1f);
        countDown1.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1f);
        countDownGo.SetActive(true);
        goFX.Play();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
}
