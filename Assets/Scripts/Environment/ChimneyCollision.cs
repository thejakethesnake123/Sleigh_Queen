using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ChimneyCollision : MonoBehaviour
{
    public GameObject ChimneyPoints;
    public AudioSource yaySound;

    //public Transform canvasTransform; // Reference to the Canvas transform
    void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with has the "Finish" tag
        if (other.tag == "Finish")
        {
            GlobalMovement.chimneyScore += 10;

            if (ChimneyPoints != null)
            {
                ShowChimneyPoints();
            }

            void ShowChimneyPoints()
            {
                //ChimneyPoints.SetActive(true);
                Debug.Log("+10");
                Instantiate(ChimneyPoints, transform.position, Quaternion.identity, transform);
                yaySound.Play();

            }

        }



        

        
    }
}