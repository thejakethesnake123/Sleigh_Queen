using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float leftRightSpeed; // Speed of the movement to the lane
    public float baseHorizontalSpeed = 21f;   

    void Update()
    { 
        if (GlobalMovement.canMove == true)
        {
            leftRightSpeed = baseHorizontalSpeed + GlobalMovement.globalAcceleration;
            // Check for input to move left or right
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > GlobalMovement.leftSide)
                {

                    {
                        transform.Translate(Vector3.right * leftRightSpeed * Time.deltaTime);
                    }
                }
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < GlobalMovement.rightSide)
                {
                    transform.Translate(Vector3.left * leftRightSpeed * Time.deltaTime);
                }
                    
            }
        }
        // Smoothly move towards the target position
        
    }
}
