using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelStarter : MonoBehaviour
{
    //public GameObject mainCam;
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGo;
    public AudioSource readyFX;
    public AudioSource goFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //mainCam.GetComponent<Animator>().enabled = true;
        if (GlobalMovement.highScore == 0)
        {
            StartCoroutine(CountSequence());
        }

        else
        {
            goFX.Play();
            GlobalMovement.canMove = true;
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
        GlobalMovement.canMove = true;

    }
}
