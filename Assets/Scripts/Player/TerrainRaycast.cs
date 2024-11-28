using UnityEngine;

public class TerrainRaycast : MonoBehaviour
{
    public LayerMask terrainLayer; // LayerMask to ensure we only hit the terrain
    public float offset = 40f; // Height difference to maintain above the terrain

    void Update()
    {
        // Cast a ray downwards from the player's position
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        // Check if the raycast hits the terrain
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, terrainLayer))
        {
            // Get the y position of the hit point
            float terrainY = hit.point.y;

            // Adjust the player's y position to maintain the offset
            transform.position = new Vector3(transform.position.x, terrainY + offset, transform.position.z);
        }
    }
}
