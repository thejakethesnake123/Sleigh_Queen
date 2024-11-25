using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Array of z positions for the lanes
    public float[] lanes = { 632f, 628.5f, 623.5f, 620f }; // Define these based on your scene
    private int currentLane = 1; // Start at the second lane (index 1)

    public float moveSpeed = 25f; // Speed of the movement to the lane

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
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, lanes[currentLane]);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
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
