using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleport1 : MonoBehaviour
{
    Animator m_Animator;
    public GameObject thePlayer;
    public GameObject animationSleighqueen;


    //public AudioSource teleport;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Animator = animationSleighqueen.gameObject.GetComponent<Animator>();
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
            m_Animator.SetTrigger("WinJump");
            SceneManager.LoadScene(0);
        }

       
    }

    //IEnumerator TeleportStage2()
    //{
    //    yield return new WaitForSeconds(1);        
    //    SceneManager.LoadScene(1);

    //}
}
