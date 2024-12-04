using UnityEngine;

public class PlayerForwardMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float accSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void PlayerPosition()
    {
        accSpeed = moveSpeed + (transform.position.z / 80);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition();

        if (GlobalMovement.canMove == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * accSpeed, Space.World);
        }
    }
}
