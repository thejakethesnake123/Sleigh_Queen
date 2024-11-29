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
    public bool addingDis = false;
    public int disRun = 0;
    
    void Update()
    {
        if (addingDis == false)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
       
    }

    IEnumerator AddingDis()
    {
        disRun += 1;
        int displayedScore = disRun + GlobalMovement.chimneyScore;
        GlobalMovement.totalScore = displayedScore;
        //disDisplay.GetComponent<TextMeshProUGUI>().text = "" + disRun;
        disDisplay.text = "Score: " + displayedScore;
        disEndDisplay.text = "Score: " + displayedScore;
        yield return new WaitForSeconds(1f);
        addingDis = false;
    }
}
