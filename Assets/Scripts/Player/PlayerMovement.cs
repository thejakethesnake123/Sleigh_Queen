using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Array of z positions for the lanes
    //public float[] lanes = { -15f, -5f, 5f, 15f }; // Define these based on your scene
    //private int currentLane = 1; // Start at the second lane (index 1)
    public float leftRightSpeed = 20f; // Speed of the movement to the lane
    public float targetPositionX;
    public Vector3 targetPosition;    

    void Update()
    { 
        if (GlobalMovement.canMove == true)
        {
            // Check for input to move left or right
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {

                    {
                        MoveLeft();
                    }
                }
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    MoveRight();
                }
                    
            }
        }
        // Smoothly move towards the target position

        targetPosition = new Vector3(targetPositionX, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, leftRightSpeed * Time.deltaTime);

        
    }

    void MoveLeft()
    {
        // Move left if not in the leftmost lane
        targetPositionX = transform.position.x - 1f;
    }

    void MoveRight()
    {
        // Move right if not in the rightmost lane
        targetPositionX = transform.position.x + 1f;
    }
}
