using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public AudioSource crashThud;

    //public GameObject charModel;
    GameObject rigidBody;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GlobalMovement.canMove = false;
            //charModel.GetComponent<Animator>().Play("Death");
            crashThud.Play();

        }
     

    }
}

