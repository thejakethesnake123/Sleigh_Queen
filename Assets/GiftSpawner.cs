using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
    public GameObject giftPrefab; // Assign the cube prefab in the Inspector
    private Transform dropPosition; // Optional: Set a specific drop position relative to the spawner
    public int chimneysHit = 0;


    void Update()
    {
        // Check if the Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropCube();
        }
    }

    public void DropCube()
    {
        // Create a new cube instance
        GameObject droppedGift = Instantiate(giftPrefab, transform.position, transform.rotation);

        // Optionally override the drop position if specified
        if (dropPosition != null)
        {
            droppedGift.transform.position = dropPosition.position;
        }

        // Make sure the cube is no longer a child of the spawner
        droppedGift.transform.parent = null;

        // Add any additional physics or interactions here if needed

        void OnCollisionEnter(Collision collision)
        {
            // Check if the object collided with has the "Player" tag
            if (collision.gameObject.CompareTag("Finish"))
            {
                chimneysHit =+ 1;
                Debug.Log("You have hit " + chimneysHit + " chimneys.");
            }
        }

        if (droppedGift.transform.position.y < 0.8f)
        {
            Destroy(droppedGift);
        }
    }
}
