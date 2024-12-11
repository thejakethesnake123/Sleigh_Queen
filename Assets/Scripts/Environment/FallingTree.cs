using UnityEngine;

public class FallingTree : MonoBehaviour
{
    public GameObject player;
    public AudioSource treeFall;
    [SerializeField] int randLottery;
    [SerializeField] int treeValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randLottery = Random.Range(0, 3);
        treeValue = Random.Range(0, 3);
    }

    void ToFallOrNotToFall()
    {
        if (transform.parent.position.z - player.transform.position.z < 30)
        {
            treeFall.Play();
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
