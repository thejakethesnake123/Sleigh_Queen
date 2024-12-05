using UnityEngine;

public class PlayerForwardMovement : MonoBehaviour
{
    public int startSpeed = 25;

    public int accSpeed = 50;

    float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void GoingFaster()
    {
        moveSpeed = startSpeed + (transform.position.z / accSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        GoingFaster();

        if (GlobalMovement.canMove == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }
    }
}
