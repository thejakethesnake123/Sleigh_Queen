using UnityEngine;

public class PlayerForwardMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public bool playerMove = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void MoveSpeed()
    {
        if (playerMove == true)
        {
            moveSpeed = 10f;
        }

        if (playerMove == false)
        {
            moveSpeed = 0f;
        }
    }

    void PlayerPosition()
    {
        if (transform.position == new Vector3(0f, 20.4f, 100f))
        {
            playerMove = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpeed();

        PlayerPosition();

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
    }
}
