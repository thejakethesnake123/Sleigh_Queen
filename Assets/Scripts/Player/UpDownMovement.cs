using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float targetPositionY;
    public Vector3 targetPosition;
    public float upDownSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }

        targetPosition = new Vector3(transform.position.x, targetPositionY, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, upDownSpeed * Time.deltaTime);
    }

    void MoveUp()
    {
        targetPositionY = transform.position.y + 30f;
    }


    void MoveDown()
    {

        targetPositionY = transform.position.y - 30f;
    }
}
