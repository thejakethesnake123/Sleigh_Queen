using UnityEngine;

public class WorldRotation : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    

    // Update is called once per frame
    void Update()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;

        transform.Rotate(0f, rotationAmount, 0f);
    }
}
