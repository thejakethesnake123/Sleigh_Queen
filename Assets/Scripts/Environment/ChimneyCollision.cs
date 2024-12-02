using UnityEngine;
using TMPro;


public class ChimneyCollision : MonoBehaviour
{
    public GameObject ChimneyPoints;
    //public Transform canvasTransform; // Reference to the Canvas transform
    void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with has the "Finish" tag
        if (other.tag == "Finish")
        {
            GlobalMovement.chimneyScore += 10;
            Debug.Log("Local score: " + GlobalMovement.chimneyScore + "");
            Debug.Log("Highscore: " + GlobalMovement.highScore + "");
            ChimneyPoints.SetActive(true);

        }
    }
}