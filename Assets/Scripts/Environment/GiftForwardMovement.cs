using UnityEngine;

public class GiftForwardMovement : MonoBehaviour
{
    public float dropSpeed = 10f;
    private bool touchGround = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            touchGround = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!touchGround)
        {
            transform.Translate(Vector3.down * Time.deltaTime * dropSpeed, Space.World);
        }
    }
}
