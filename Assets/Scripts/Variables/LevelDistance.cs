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
    public int disRun;
    public bool addingDis = false;
    
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
        //disDisplay.GetComponent<TextMeshProUGUI>().text = "" + disRun;
        disDisplay.text = "" + disRun + GlobalMovement.localScore;
        disEndDisplay.text = "" + disRun;
        yield return new WaitForSeconds(0.5f);
        addingDis = false;
    }
}
