using UnityEngine;

public class PlaneSound : MonoBehaviour
{
    public GameObject player;
    public AudioSource planeSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.position.z - player.transform.position.z < 30)
        {
            planeSound.Play();
        }
    }
}
