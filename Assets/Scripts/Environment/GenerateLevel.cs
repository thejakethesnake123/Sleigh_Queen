using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject[] iceSection;
    [SerializeField] GameObject[] citySection;
    [SerializeField] GameObject[] forestSection;
    int zPos;
    int secNum;
    [SerializeField] int spawnPoint = 1500;
    [SerializeField] int forestSpawnStart = 2000;
    [SerializeField] int citySpawnStart = 4000;
    int levelCount;
    bool createdCitySection = false;
    bool createdForestSection = false;
    [SerializeField] GameObject levelBorder1;
    [SerializeField] GameObject levelBorder2;
    [SerializeField] GameObject ice;
    [SerializeField] GameObject forest;
    [SerializeField] GameObject city;


    [SerializeField] GameObject player; // Reference to the player transform
    private List<GameObject> iceSectionInstances = new List<GameObject>(); // List to store section instances
    private List<GameObject> citySectionInstances = new List<GameObject>();
    private List<GameObject> forestSectionInstances = new List<GameObject>();

    bool passedIce;
    bool passedForest;
    bool problemSolved;

    private void Start()
    {
        GlobalMovement.leftSide = -27;
        GlobalMovement.rightSide = 27;

        if (passedIce != true)
        {

            for (int i = 0; i < 1; i++)
            {
                secNum = Random.Range(0, iceSection.Length);
                GameObject newIceSection = Instantiate(iceSection[secNum], new Vector3(0, 0, 1300), Quaternion.identity);
                iceSectionInstances.Add(newIceSection); // Add to the list
                zPos = 1660;
            }
        }


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GlobalMovement.endGame == false)
        {

            //spawn points for different level sections
            if (player.transform.position.z < forestSpawnStart)
            {
                levelCount = 1;

                if (problemSolved == false)
                {
                    ice.SetActive(true);
                    passedIce = false;
                    createdForestSection = false;
                    //forest.SetActive(false);
                    passedForest = false;
                    //city.SetActive(false);
                    levelBorder1.transform.position = new Vector3(0, 0, 10000);
                    levelBorder2.transform.position = new Vector3(0, 0, 10000);
                    problemSolved = true;
                }
            }

            if (player.transform.position.z > forestSpawnStart && player.transform.position.z < citySpawnStart)
            {
                levelCount = 2;
                forest.SetActive(true);
            }

            if (player.transform.position.z > citySpawnStart)
            {
                levelCount = 3;
                city.SetActive(true);
            }


            //set boundaries for up-down movement in different levels 
            if (player.transform.position.z < levelBorder1.transform.position.z)
            {
                GlobalMovement.bottomSide = -75;
                GlobalMovement.topSide = -68;
            }

            if (player.transform.position.z > levelBorder1.transform.position.z - 100)
            {
                GlobalMovement.bottomSide = -75;
                GlobalMovement.topSide = 18;
                passedIce = true;
            }

            if (player.transform.position.z > levelBorder2.transform.position.z - 200)
            {
                GlobalMovement.bottomSide = -75;
                GlobalMovement.topSide = 96;
                passedForest = true;
            }

            if (citySectionInstances.Count == 0)
            {
                createdCitySection = false;
            }

            if (levelCount == 1)
            {
                var lastIceClone = iceSectionInstances.Last();
                if (lastIceClone.transform.position.z - player.transform.position.z < spawnPoint)
                {
                    secNum = Random.Range(0, iceSection.Length);
                    GameObject newIceSection = Instantiate(iceSection[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
                    iceSectionInstances.Add(newIceSection); // Add to the list
                    zPos += 350;
                }
            }


            else if (levelCount == 2)
            {
                forest.SetActive(true);
                if (passedForest == false)
                {
                    if (createdForestSection == false)
                    {
                        levelBorder1.transform.position = new Vector3(0, -68, zPos);
                        secNum = 0;
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject newForestSection = Instantiate(forestSection[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
                            forestSectionInstances.Add(newForestSection); // Add to the list
                            zPos += 350;
                            secNum++;
                        }
                        createdForestSection = true;
                    }

                    if (createdForestSection == true)
                    {
                        var lastForestClone = forestSectionInstances.Last();
                        if (lastForestClone.transform.position.z - player.transform.position.z < spawnPoint)
                        {
                            secNum = Random.Range(3, forestSection.Length);
                            GameObject newForestSection = Instantiate(forestSection[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
                            forestSectionInstances.Add(newForestSection); // Add to the list
                            zPos += 350;
                        }
                    }
                }

            }

            else if (levelCount == 3)
            {
                city.SetActive(true);
                if (createdCitySection == false)
                {
                    levelBorder2.transform.position = new Vector3(0, 17, zPos);
                    secNum = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        GameObject newCitySection = Instantiate(citySection[secNum], new Vector3(0, 0, zPos - 100), Quaternion.identity);
                        citySectionInstances.Add(newCitySection); // Add to the list
                        zPos += 250;
                        secNum++;
                    }
                    createdCitySection = true;
                }

                if (createdCitySection == true)
                {
                    var lastCityClone = citySectionInstances.Last();
                    if (lastCityClone.transform.position.z - player.transform.position.z < spawnPoint)
                    {
                        secNum = Random.Range(1, citySection.Length);
                        GameObject newCitySection = Instantiate(citySection[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
                        citySectionInstances.Add(newCitySection); // Add to the list
                        zPos += 250;
                    }
                }
            }

            // Check and destroy sections if player is far enough ahead
            for (int i = iceSectionInstances.Count - 1; i >= 0; i--) // Iterate backward to safely remove items
            {
                GameObject destroyIceInstance = iceSectionInstances[i];
                if (player.transform.position.z > destroyIceInstance.transform.position.z + 280)
                {
                    Destroy(destroyIceInstance);
                    iceSectionInstances.RemoveAt(i); // Remove from the list
                }
            }

            for (int i = citySectionInstances.Count - 1; i >= 0; i--) // Iterate backward to safely remove items
            {
                GameObject destroyCityInstance = citySectionInstances[i];
                if (player.transform.position.z > destroyCityInstance.transform.position.z + 350)
                {
                    Destroy(destroyCityInstance);
                    citySectionInstances.RemoveAt(i); // Remove from the list
                }
            }

            for (int i = forestSectionInstances.Count - 1; i >= 0; i--) // Iterate backward to safely remove items
            {
                GameObject destroyForestInstance = forestSectionInstances[i];
                if (player.transform.position.z > destroyForestInstance.transform.position.z + 200)
                {
                    Destroy(destroyForestInstance);
                    forestSectionInstances.RemoveAt(i); // Remove from the list
                }
            }

            //if (iceSectionInstances.Count == 0 && passedIce == true)
            //{
            //    ice.SetActive(false);
            //}

            //if (forestSectionInstances.Count == 0 && passedForest == true)
            //{
            //    forest.SetActive(false);
            //}
        }
    }
}