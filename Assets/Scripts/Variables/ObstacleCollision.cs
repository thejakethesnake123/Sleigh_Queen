using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    //public bool isDead
    //{ get
    //    {
    //        return Health == 0;
    //    }
    //}


    //public GameObject charModel;
    GameObject rigidBody;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GlobalMovement.canMove = false;
            //charModel.GetComponent<Animator>().Play("Death");

        }


        //if(isDead)
        //{
        //    _animator.SetTrigger("death");
        //}
        //Debug.Log("Enter");
        //this.gameObject.GetComponent<BoxCollider>().enabled = false;
        //thePlayer.GetComponent<PlayerMovement>().enabled = false;

        //GlobalMovement.canMove = false;
    }
}

