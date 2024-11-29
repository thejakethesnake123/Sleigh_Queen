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

    public GameObject player; // Reference to the player transform
    private List<GameObject> sectionInstances = new List<GameObject>(); // List to store section instances

    // Update is called once per frame
    void Update()
    {
        // Generate new sections
        if (!creatingSection)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }

        // Check and destroy sections if player is far enough ahead
        for (int i = sectionInstances.Count - 1; i >= 0; i--) // Iterate backward to safely remove items
        {
            GameObject sectionInstance = sectionInstances[i];
            if (player.transform.position.z > sectionInstance.transform.position.z + 200)
            {
                Destroy(sectionInstance);
                sectionInstances.RemoveAt(i); // Remove from the list
            }
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 3);
        GameObject newSection = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        sectionInstances.Add(newSection); // Add to the list
        zPos += 50 * zCount;
        yield return new WaitForSeconds(3);
        creatingSection = false;
    }
}
