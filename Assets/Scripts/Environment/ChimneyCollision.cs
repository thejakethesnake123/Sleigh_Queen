using UnityEngine;

public class ChimneyCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with has the "Finish" tag
        if (other.tag == "Finish")
        {
            GlobalMovement.chimneyScore += 10;
            Debug.Log("Local score: " + GlobalMovement.chimneyScore + "");
            Debug.Log("Highscore: " + GlobalMovement.highScore + "");
        }
    }
}