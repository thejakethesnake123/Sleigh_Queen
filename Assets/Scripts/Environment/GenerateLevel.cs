using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 50;
    public int zCount = 1;
    public bool creatingSection = false;
    public int secNum;
    public int spawnPoint = 2000;

    public GameObject player; // Reference to the player transform
    private List<GameObject> sectionInstances = new List<GameObject>(); // List to store section instances

    private void Start()
    {
        int i = 4;
        while (i > 0)
        {
            secNum = Random.Range(0, 6);
            GameObject newSection = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
            sectionInstances.Add(newSection); // Add to the list
            zPos += 50 * zCount;
            i -= 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        var lastClone = sectionInstances.Last();
        if (lastClone.transform.position.z - player.transform.position.z < spawnPoint)
        {
            secNum = Random.Range(0, 3);
            GameObject newSection = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
            sectionInstances.Add(newSection); // Add to the list
            zPos += 50 * zCount;
        }

        // Generate new sections
        //if (!creatingSection)
        //{
        //    creatingSection = true;
        //    StartCoroutine(GenerateSection());
        //}

        // Check and destroy sections if player is far enough ahead
        for (int i = sectionInstances.Count - 1; i >= 0; i--) // Iterate backward to safely remove items
        {
            GameObject destroyInstance = sectionInstances[i];
            if (player.transform.position.z > destroyInstance.transform.position.z + 200)
            {
                Destroy(destroyInstance);
                sectionInstances.RemoveAt(i); // Remove from the list
            }
        }
    }

    //IEnumerator GenerateSection()
    //{
    //    secNum = Random.Range(0, 3);
    //    GameObject newSection = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
    //    sectionInstances.Add(newSection); // Add to the list
    //    zPos += 50 * zCount;
    //    yield return new WaitForSeconds(3);
    //    creatingSection = false;
    //}
}
