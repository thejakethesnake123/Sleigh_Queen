using UnityEngine;

public class PlayerForwardMovement : MonoBehaviour
{
    public int startSpeed = 25;

    public float accFactorZ = 0.5f;

    public float moveSpeed;

    public float accFactorXY = 1f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void GoingFaster()
    {
        moveSpeed = startSpeed + (transform.position.z * accFactorZ);
        GlobalMovement.globalAcceleration = moveSpeed * accFactorXY;
    }

    //void TakeOff()
    //{
    //    transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.World);
    //}

    // Update is called once per frame
    void Update()
    {
        //if (transform.position.y < -75)
        //{
        //    TakeOff();
        //}

        GoingFaster();

        if (GlobalMovement.canMove == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }
    }
}
