using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float baseVerticalSpeed = 21f;
    public float upDownSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (GlobalMovement.canMove == true)
        { 
            upDownSpeed = baseVerticalSpeed + GlobalMovement.globalAcceleration;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (this.gameObject.transform.position.y < GlobalMovement.topSide)
                {
                    transform.Translate(Vector3.up * upDownSpeed * Time.deltaTime);
                }
            }


            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (this.gameObject.transform.position.y > GlobalMovement.bottomSide)
                {
                    transform.Translate(Vector3.down * upDownSpeed * Time.deltaTime);
                }
            }
          
        }
    }
}
