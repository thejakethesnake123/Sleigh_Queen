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
    public int disRun = 0;

    void Start()
    {
        GlobalMovement.chimneyScore = 0;
    }
    
    void Update()
    {
        int displayedScore = disRun + GlobalMovement.chimneyScore;
        GlobalMovement.totalScore = displayedScore;
        if (GlobalMovement.totalScore > GlobalMovement.highScore)
        {
            GlobalMovement.highScore = GlobalMovement.totalScore;
        }

        disDisplay.text = "Score: " + displayedScore;
        highScoreCount.text = "Highscore: " + GlobalMovement.highScore;
        disEndDisplay.text = "Score: " + displayedScore;

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
        disRun += 1;
        //disDisplay.GetComponent<TextMeshProUGUI>().text = "" + disRun;
        yield return new WaitForSeconds(1f);
        addingDis = false;
    }
}
