using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Finish")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }

    }
}
