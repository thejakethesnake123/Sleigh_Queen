using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
    public GameObject giftPrefab; // Assign the cube prefab in the Inspector
    private Transform dropPosition; // Optional: Set a specific drop position relative to the spawner
    [SerializeField] Material[] materials;


    void Update()
    {
        // Check if the Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropGift();

            AssignRandomMaterials(giftPrefab);
        }
    }

    public void DropGift()
    {
        // Create a new cube instance
        GameObject droppedGift = Instantiate(giftPrefab, transform.position, transform.rotation);

        // Optionally override the drop position if specified
        if (dropPosition != null)
        {
            droppedGift.transform.position = dropPosition.position;
        }

        float randRotX = Random.Range(0f, 90f);
        float randRotY = Random.Range(0f, 90f);
        float randRotZ = Random.Range(0f, 90f);

        // Convert the random Euler angles to a Quaternion
        droppedGift.transform.rotation = Quaternion.Euler(randRotX, randRotY, randRotZ);


        // Randomize the scale values between 20 and 40
        float randScaleX = Random.Range(0.4f, 0.9f);
        float randScaleY = Random.Range(0.4f, 0.9f);
        float randScaleZ = Random.Range(0.4f, 0.9f);
        droppedGift.transform.localScale = new Vector3(randScaleX, randScaleY, randScaleZ);


        // Make sure the cube is no longer a child of the spawner
        droppedGift.transform.parent = null;

        // Add any additional physics or interactions here if needed


        Destroy(droppedGift, 5f);
        
    }

    private void AssignRandomMaterials(GameObject parentObject)
    {
        // Loop through each child of the parent object.
        foreach (Transform child in parentObject.transform)
        {
            // Get the MeshRenderer component.
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();

            if (meshRenderer != null)
            {
                // Assign a random material from the array to this child.
                Material[] childMaterials = meshRenderer.materials;
                for (int i = 0; i < childMaterials.Length; i++)
                {
                    int randomIndex = Random.Range(0, materials.Length);
                    childMaterials[i] = materials[randomIndex];
                }
                meshRenderer.materials = childMaterials;
            }
        }
    }
}
