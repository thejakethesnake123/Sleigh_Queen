using UnityEngine;

public class PlayerForwardMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void PlayerPosition()
    {
        if (transform.position.z > 10000f)
        {
            GlobalMovement.canMove = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition();

        if (GlobalMovement.canMove == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }
    }
}
