using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGo;
    public AudioSource readyFX;
    public AudioSource goFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(1.5f);
        countDown3.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDown2.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDown1.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDownGo.SetActive(true);
        goFX.Play();
        GlobalMovement.canMove = true;

    }
}
