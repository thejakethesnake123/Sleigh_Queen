using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public AudioSource crashThud;
    public GameObject mainCam;
    Animator m_Animator;
    public GameObject levelControl;
    //public Animator cameraAnimator;


    void Start()
    {
        //cameraAnimator.SetBool("CamShake", false);
        m_Animator = mainCam.gameObject.GetComponent<Animator>();
    }

    //public GameObject charModel;
    GameObject rigidBody;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GlobalMovement.canMove = false;
            GlobalMovement.endGame = true;
            //charModel.GetComponent<Animator>().Play("Death");
            crashThud.Play();
            levelControl.GetComponent<LevelDistance>().enabled = false;
            //mainCam.GetComponent<Animator>().SetTrigger("CamShake");
            m_Animator.SetTrigger("CamShake");
            levelControl.GetComponent<EndRunSequence>().enabled = true;
            //cameraAnimator.SetBool("CamShake", true);

        }


    }
}

