using TMPro.Examples;
using UnityEngine;

public class ChimneyCollision : MonoBehaviour
{
    public int chimneysHit = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(chimneysHit);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with has the "Player" tag
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            chimneysHit = chimneysHit + 1;
            Debug.Log("You have hit " + chimneysHit + " chimneys.");
        }
    }
}
