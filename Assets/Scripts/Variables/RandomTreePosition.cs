using UnityEngine;

public class RandomTreePosition : MonoBehaviour
{
    int randXPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        randXPos = Random.Range(-17, 18);

        transform.position = new Vector3(transform.position.x + randXPos, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
