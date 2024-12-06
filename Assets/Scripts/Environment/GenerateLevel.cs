using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject[] iceSection;
    public GameObject[] citySection;
    public GameObject[] forestSection;
    //public GameObject endSection;
    public int zPos = 50;
    public int zCount = 1;
    int secNum;
    int secNumTrans;
    public int spawnPoint = 1500;
    public int forestSpawnStart = 2000;
    public int citySpawnStart = 4000;
    public int numOfIceSections = 6;
    public int numOfCitySections = 6;
    public int numOfForestSections = 1;
    int levelCount;
    bool createdCitySection = false;
    bool createdForestSection = false;
    public GameObject levelBorder1;
    public GameObject levelBorder2;

    public GameObject player; // Reference to the player transform
    private List<GameObject> iceSectionInstances = new List<GameObject>(); // List to store section instances
    private List<GameObject> citySectionInstances = new List<GameObject>();
    private List<GameObject> forestSectionInstances = new List<GameObject>();

    private void Start()
    {
        levelBorder1.transform.position = new Vector3(0, 0, 10000);
        levelBorder2.transform.position = new Vector3(0, 0, 10000);

        for (int i = 0; i < 1; i++)
        {
            secNum = Random.Range(0, numOfIceSections);
            GameObject newIceSection = Instantiate(iceSection[secNum], new Vector3(0, 0, 800), Quaternion.identity);
            iceSectionInstances.Add(newIceSection); // Add to the list
            zPos = 800 + (80 * zCount);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalMovement.endGame == false)
        {
            
            //spawn points for different level sections
            if (player.transform.position.z < forestSpawnStart)
            {
                levelCount = 1;
            }

            if (player.transform.position.z > forestSpawnStart)
            {
                levelCount = 2;
            }

            if (player.transform.position.z > citySpawnStart)
            {
                levelCount = 3;
            }

           
            //set boundaries for up-down movement in different levels 
            if (player.transform.position.z < levelBorder1.transform.position.z)
            {
                LevelBoundary.bottomSide = -75;
                LevelBoundary.topSide = -65;
            }

            if (player.transform.position.z > levelBorder1.transform.position.z - 300)
            {
                LevelBoundary.bottomSide = -75;
                LevelBoundary.topSide = 30;
            }

            if (player.transform.position.z > levelBorder2.transform.position.z - 300)
            {
                LevelBoundary.bottomSide = -75;
                LevelBoundary.topSide = 97;
            }

            if (levelCount == 1)
            {
                var lastIceClone = iceSectionInstances.Last();
                if (lastIceClone.transform.position.z - player.transform.position.z < spawnPoint)
                {
                    secNum = Random.Range(0, numOfIceSections);
                    GameObject newIceSection = Instantiate(iceSection[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
                    iceSectionInstances.Add(newIceSection); // Add to the list
                    zPos += 70 * zCount;
                }
            }

            else if (levelCount == 3)
            {
                if (createdCitySection == false)
                {
                    levelBorder2.transform.position = new Vector3(0, 25, zPos - 240);
                    secNum = Random.Range(0, numOfCitySections);
                    GameObject newCitySection = Instantiate(citySection[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
                    citySectionInstances.Add(newCitySection); // Add to the list
                    zPos += 50 * zCount;
                    createdCitySection = true;
                }


                var lastCityClone = citySectionInstances.Last();
                if (lastCityClone.transform.position.z - player.transform.position.z < spawnPoint)
                {
                    secNum = Random.Range(0, numOfCitySections);
                    GameObject newCitySection = Instantiate(citySection[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
                    citySectionInstances.Add(newCitySection); // Add to the list
                    zPos += 50 * zCount;
                }
            }

            //else
            //{
            //    Instantiate(endSection, new Vector3(0, 0, zPos), Quaternion.identity);
            //    zPos += 50 * zCount;
            //}


            else if (levelCount == 2)
            {
                if (createdForestSection == false)
                {
                    levelBorder1.transform.position = new Vector3(0, -70, zPos + 100);
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject newForestSection = Instantiate(forestSection[secNumTrans], new Vector3(0, 0, zPos), Quaternion.identity);
                        forestSectionInstances.Add(newForestSection); // Add to the list
                        zPos += 70 * zCount;
                        secNumTrans++;
                    }
                    createdForestSection = true;
                }

                var lastForestClone = forestSectionInstances.Last();
                if (lastForestClone.transform.position.z - player.transform.position.z < spawnPoint)
                {
                    secNum = Random.Range(3, numOfForestSections);
                    GameObject newForestSection = Instantiate(forestSection[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
                    forestSectionInstances.Add(newForestSection); // Add to the list
                    zPos += 50 * zCount;
                }
            }

            // Check and destroy sections if player is far enough ahead
            for (int l = iceSectionInstances.Count - 1; l >= 0; l--) // Iterate backward to safely remove items
            {
                GameObject destroyIceInstance = iceSectionInstances[l];
                if (player.transform.position.z > destroyIceInstance.transform.position.z + 200)
                {
                    Destroy(destroyIceInstance);
                    iceSectionInstances.RemoveAt(l); // Remove from the list
                }
            }

            for (int j = citySectionInstances.Count - 1; j >= 0; j--) // Iterate backward to safely remove items
            {
                GameObject destroyCityInstance = citySectionInstances[j];
                if (player.transform.position.z > destroyCityInstance.transform.position.z + 200)
                {
                    Destroy(destroyCityInstance);
                    citySectionInstances.RemoveAt(j); // Remove from the list
                }
            }

            for (int k = forestSectionInstances.Count - 1; k >= 0; k--) // Iterate backward to safely remove items
            {
                GameObject destroyForestInstance = forestSectionInstances[k];
                if (player.transform.position.z > destroyForestInstance.transform.position.z + 200)
                {
                    Destroy(destroyForestInstance);
                    forestSectionInstances.RemoveAt(k); // Remove from the list
                }
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
