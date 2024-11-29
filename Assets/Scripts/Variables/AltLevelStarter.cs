using UnityEngine;

public class AltLevelStarter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalMovement.totalScore > GlobalMovement.highScore - 1)
        {
            GlobalMovement.highScore = GlobalMovement.totalScore;
        }
    }
}