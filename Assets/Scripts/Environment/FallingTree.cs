using UnityEngine;

public class FallingTree : MonoBehaviour
{
    public GameObject player;
    [SerializeField] AudioSource treeFall;
    [SerializeField] int randLottery;
    [SerializeField] int treeValue;
    bool soundPlayed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randLottery = Random.Range(1, 4);
        treeValue = Random.Range(1, 4);
        soundPlayed = false;
    }

    void ToFallOrNotToFall()
    {


        if (transform.parent.position.z - player.transform.position.z < 80)
        {
            if (soundPlayed == false)
            {
                treeFall.Play();
                soundPlayed = true;
            }
        }

        if (transform.parent.position.z - player.transform.position.z < 40)
        {
            Quaternion targetRotation = Quaternion.Euler(0, 0, 75);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1.2f * Time.deltaTime);
        }
    }


// Update is called once per frame
    void Update()
    {

        if (treeValue == randLottery)
        {
            ToFallOrNotToFall();
        }
    }
}
