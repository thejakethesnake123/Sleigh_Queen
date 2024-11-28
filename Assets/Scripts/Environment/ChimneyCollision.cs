using UnityEngine;

public class ChimneyCollision : MonoBehaviour
{
    public static int chimneysHit = 0;

    void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with has the "Finish" tag
        if (other.tag == "Finish")
        {
            chimneysHit += 1;
            GlobalMovement.localScore += 10;
            Debug.Log("You have hit " + chimneysHit + " chimneys.");
            Debug.Log("Local score: " + GlobalMovement.localScore + "");
            Debug.Log("Highscore: " + GlobalMovement.highScore + "");
        }
    }
}