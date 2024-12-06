using UnityEngine.SceneManagement;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    //public GameObject thePlayer;
    public AudioSource crashThud;
    public GameObject mainCam;
    Animator m_Animator;
    public GameObject levelControl;

    void Start()
    {
        //cameraAnimator.SetBool("CamShake", false);
        //m_Animator = mainCam.gameObject.GetComponent<Animator>();
    }
    //public GameObject charModel;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GlobalMovement.canMove = false;
            GlobalMovement.endGame = true;
            //charModel.GetComponent<Animator>().Play("Death");
            if (crashThud != null)
            {
                crashThud.Play();
            }
            //mainCam.GetComponent<Animator>().SetTrigger("CamShake");
            if (mainCam != null)
            {
                m_Animator = mainCam.gameObject.GetComponent<Animator>();
                m_Animator.SetTrigger("CamShake");
            }
            if (levelControl != null)
            {
                levelControl.GetComponent<LevelDistance>().enabled = false;
                levelControl.GetComponent<EndRunSequence>().enabled = true;
            }

            else
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}

