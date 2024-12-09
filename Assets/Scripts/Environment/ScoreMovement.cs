using UnityEngine;

public class ScoreMovement : MonoBehaviour
{
    [SerializeField] int moveSpeed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (GlobalMovement.canMove == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.World);
        }
    }
}
