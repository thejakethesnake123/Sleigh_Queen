using TMPro.Examples;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        GlobalMovement.canMove = false;
    }
}
