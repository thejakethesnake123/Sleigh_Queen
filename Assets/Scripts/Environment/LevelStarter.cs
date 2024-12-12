using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelStarter : MonoBehaviour
{
    //public GameObject mainCam;
    [SerializeField] GameObject countDown3;
    [SerializeField] GameObject countDown2;
    [SerializeField] GameObject countDown1;
    [SerializeField] GameObject countDownGo;
    public AudioSource readyFX;
    public AudioSource goFX;
    public GameObject levelControl;
    public GameObject instructions;
    public GameObject player;
    public GameObject mainCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelControl.GetComponent<EndRunSequence>().enabled = false;
        //mainCam.GetComponent<Animator>().enabled = true;
        if (GlobalMovement.highScore == 0)
        {
            player.transform.position = new Vector3(0, -75, 0);
            GlobalMovement.canMove = true;
            GlobalMovement.endGame = false;
            GlobalMovement.chimneyScore = 0;
            GlobalMovement.disRun = 0;
            mainCam.GetComponent<Animator>().enabled = true;
            StartCoroutine(CountSequence());
            instructions.SetActive(true);
        }


        else if (GlobalMovement.paused == false || GlobalMovement.endGame == true)
        {
            goFX.Play();
            player.transform.position = new Vector3(0, -75, 400);
            GlobalMovement.canMove = true;
            GlobalMovement.endGame = false;
            GlobalMovement.chimneyScore = 0;
            GlobalMovement.disRun = 0;
            mainCam.GetComponent<Animator>().enabled = true;
            instructions.SetActive(false);
        }

        else
        {
            goFX.Play();
            player.transform.position = GlobalMovement.playerPos;
            GlobalMovement.canMove = true;
            GlobalMovement.endGame = false;
            GlobalMovement.paused = false;
            mainCam.GetComponent<Animator>().enabled = false;
        }

    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(2f);
        countDown3.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1f);
        countDown3.SetActive(false);
        countDown2.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1f);
        countDown2.SetActive(false);
        countDown1.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1f);
        countDown1.SetActive(false);
        countDownGo.SetActive(true);
        goFX.Play();
        yield return new WaitForSeconds(2f);
        countDownGo.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GlobalMovement.playerPos = player.transform.position;
            Time.timeScale = 0;
            GlobalMovement.paused = true;
            GlobalMovement.canMove = false;
            SceneManager.LoadScene(0);
        }
    }
}
