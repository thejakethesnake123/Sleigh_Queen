using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleport1 : MonoBehaviour
{
    public GameObject thePlayer;
    //public AudioSource teleport;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    GameObject rigidBody;


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {            
            //teleport.Play();
            SceneManager.LoadScene(0);
        }


    }

    //IEnumerator TeleportStage2()
    //{
    //    yield return new WaitForSeconds(1);        
    //    SceneManager.LoadScene(1);

    //}
}
