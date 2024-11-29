using UnityEngine;

public class TerrainTilting : MonoBehaviour
{
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


    // Update is called once per frame
    void Update()
    {
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