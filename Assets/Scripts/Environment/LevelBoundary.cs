using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -3.46f; 
    public static float rightSide = 3.41f;
    public float internalRight;
    public float internalLeft;

    // Update is called once per frame
    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;

    }
}
