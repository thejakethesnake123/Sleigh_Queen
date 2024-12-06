using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ChimneyCollision : MonoBehaviour
{
    public GameObject chimneyPoints;
    public AudioSource yaySound;
    public GameObject player;
    float randPos;

    private void Start()
    {
        randPos = Random.Range(-1f, 1f);
    }
    //public Transform canvasTransform; // Reference to the Canvas transform
    void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with has the "Finish" tag
        if (other.tag == "Finish")
        {
            GlobalMovement.chimneyScore += 10;

            if (chimneyPoints != null)
            {
                ShowChimneyPoints();
            }
        }
    }

    void ShowChimneyPoints()
    {
        chimneyPoints.SetActive(true);
        GameObject pointClone = Instantiate(chimneyPoints, transform.position, Quaternion.identity, player.transform);
        pointClone.transform.position = new Vector3(this.transform.position.x + randPos, player.transform.position.y - 10 + randPos, player.transform.position.z + 40 + randPos);
        pointClone.transform.rotation = Quaternion.Euler(player.transform.rotation.x, 180, player.transform.rotation.z);
        yaySound.Play();
        Destroy(pointClone, 1f);
        chimneyPoints.SetActive(false);
    }
}