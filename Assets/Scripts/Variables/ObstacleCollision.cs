using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public AudioSource crashThud;
    public GameObject mainCam;
    public GameObject levelControl;
    //public Animator cameraAnimator;


    void Start()
    {
        //cameraAnimator.SetBool("CamShake", false);
    }

    //public GameObject charModel;
    GameObject rigidBody;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GlobalMovement.canMove = false;
            //charModel.GetComponent<Animator>().Play("Death");
            crashThud.Play();
            levelControl.GetComponent<LevelDistance>().enabled = false;
            mainCam.GetComponent<Animator>().enabled = true;
            levelControl.GetComponent<EndRunSequence>().enabled = true;
            //cameraAnimator.SetBool("CamShake", true);

        }


    }
}

