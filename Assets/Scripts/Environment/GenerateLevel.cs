using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 50;
    public int zCount = 1;
    public bool creatingSection = false;
    public int secNum;



    // Update is called once per frame
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 4);
        Instantiate(section[secNum], new Vector3 (0,0,zPos), Quaternion.identity);
        zPos += 50 * zCount;
        yield return new WaitForSeconds(2);
        creatingSection = false;
    }
}
