using UnityEngine;

public class PlaneSound : MonoBehaviour
{
    public GameObject player;
    [SerializeField] AudioSource planeSound;
    [SerializeField] float planePositionX;
    [SerializeField] float planePositionY;
    bool soundPlayed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        planePositionX = Random.Range(-27, 28);
        planePositionY = Random.Range(97, 105);
        transform.position = new Vector3(planePositionX, planePositionY, transform.position.z);
        soundPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.position.z - player.transform.position.z < 30)
        {
            if (soundPlayed == false)
            {
                planeSound.Play();
                soundPlayed = true;
            }
            
        }
    }
}
