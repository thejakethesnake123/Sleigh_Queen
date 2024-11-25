using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -3.90f; 
    public static float rightSide = 2.90f;
    public float internalRight;
    public float internalLeft;

    // Update is called once per frame
    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;

    }
}
