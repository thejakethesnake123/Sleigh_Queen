using TMPro;
using UnityEngine;

public class AltLevelStarter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GlobalMovement.canMove = true;
        Debug.Log(GlobalMovement.highScore);
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalMovement.localScore > GlobalMovement.highScore - 1)
        {
            GlobalMovement.highScore = GlobalMovement.localScore;
        }
    }
}