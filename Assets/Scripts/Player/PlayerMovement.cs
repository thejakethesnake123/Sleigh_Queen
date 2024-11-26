using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Array of z positions for the lanes
    public float[] lanes = { -15f, -5f, 5f, 15f }; // Define these based on your scene
    private int currentLane = 1; // Start at the second lane (index 1)
    public float leftRightSpeed = 20f; // Speed of the movement to the lane

    void Update()
    { 

        // Check for input to move left or right
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }

        // Smoothly move towards the target position
        Vector3 targetPosition = new Vector3(lanes[currentLane], transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, leftRightSpeed * Time.deltaTime);
    }

    void MoveLeft()
    {
        // Move left if not in the leftmost lane
        if (currentLane > 0)
        {
            currentLane--;
        }
    }

    void MoveRight()
    {
        // Move right if not in the rightmost lane
        if (currentLane < lanes.Length - 1)
        {
            currentLane++;
        }
    }
}
