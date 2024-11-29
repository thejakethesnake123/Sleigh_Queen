using UnityEngine;

public class TerrainRaycast : MonoBehaviour
{
    public LayerMask terrainLayer; // LayerMask to ensure we only hit the terrain
    public float offset = 40f; // Height difference to maintain above the terrain
    public float moveSpeed = 3f;
    public float tiltAngleFactor = 2f; // Factor to control the tilt intensity
    public float tiltSmoothing = 5f; // Smoothing factor for the tilt rotation

    private Vector3 lastPosition; // To calculate movement direction
    private Quaternion targetRotation; // The target rotation for smooth interpolation

    void Start()
    {
        // Initialize the lastPosition with the starting position
        lastPosition = transform.position;
        targetRotation = transform.rotation;
    }

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
            Vector3 targetPosition = new Vector3(transform.position.x, terrainY + offset, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

        // Calculate movement direction and determine target tilt
        Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;

        if (velocity.magnitude > 0.01f) // Avoid tilting if the movement is negligible
        {
            float tiltAngle = -velocity.y * tiltAngleFactor; // Calculate tilt angle based on Y velocity
            Quaternion tiltRotation = Quaternion.Euler(tiltAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            targetRotation = tiltRotation; // Set the target rotation
        }

        // Smoothly interpolate to the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, tiltSmoothing * Time.deltaTime);

        // Update lastPosition for the next frame
        lastPosition = transform.position;
    }
}
