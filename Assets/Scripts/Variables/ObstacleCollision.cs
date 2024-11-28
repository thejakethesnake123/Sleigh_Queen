using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public AudioSource crashThud;
    public GameObject mainCam;
    public GameObject levelControl;

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

        }
     

    }
}

