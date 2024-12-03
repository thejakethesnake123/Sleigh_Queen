using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide; 
    public static float rightSide;
    public static float topSide;
    public static float bottomSide;
    public float internalLeft = -10f;
    public float internalRight = 10f;
    public float internalTop = 90f;
    public float internalBottom = 5f;


    private void Update()
    {
        leftSide = internalLeft;
        rightSide = internalRight;
        topSide = internalTop;
        bottomSide = internalBottom;

    }
}
