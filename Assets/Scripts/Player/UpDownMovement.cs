using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    //public float targetPositionY;
    //public Vector3 targetPosition;
    public float upDownSpeed = 16f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (GlobalMovement.canMove == true)
        { 

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (this.gameObject.transform.position.y < LevelBoundary.topSide)
                {
                    transform.Translate(Vector3.up * upDownSpeed * Time.deltaTime);
                }
            }


            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (this.gameObject.transform.position.y > LevelBoundary.bottomSide)
                {
                    transform.Translate(Vector3.down * upDownSpeed * Time.deltaTime);
                }
            }
          
        }
    }
}
