using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelDistance : MonoBehaviour
{
    //public GameObject disDisplay;
    public TMP_Text disDisplay;
    public TMP_Text disEndDisplay;
    public TMP_Text highScoreCount;
    public bool addingDis = false;
    float scoreTime;


    void Update()
    {
        int displayedScore = GlobalMovement.disRun + GlobalMovement.chimneyScore;
        GlobalMovement.totalScore = displayedScore;
        if (GlobalMovement.totalScore > GlobalMovement.highScore)
        {
            GlobalMovement.highScore = GlobalMovement.totalScore;
        }

        disDisplay.text = "" + displayedScore;
        highScoreCount.text = "" + GlobalMovement.highScore;
        disEndDisplay.text = "" + displayedScore + " points";

        if (GlobalMovement.canMove == true)
        {
            if (addingDis == false)
            {
                addingDis = true;
                StartCoroutine(AddingDis());
            }
        }
       
    }

    IEnumerator AddingDis()
    {
        GlobalMovement.disRun += 1;
        //disDisplay.GetComponent<TextMeshProUGUI>().text = "" + disRun;
        scoreTime = 1f - (GlobalMovement.globalAcceleration / 30f);
        yield return new WaitForSeconds(scoreTime);
        addingDis = false;
    }
}
