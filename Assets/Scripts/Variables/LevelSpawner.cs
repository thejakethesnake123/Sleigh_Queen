//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//public class LevelSpawner : MonoBehaviour
//{
//    [Header("Level Sections")]
//    [SerializeField] GameObject[] iceSections;
//    [SerializeField] GameObject[] citySections;
//    [SerializeField] GameObject[] forestSections;

//    [Header("Spawn Settings")]
//    [SerializeField] int spawnDistance = 1500;
//    [SerializeField] int forestSpawnStart = 2000;
//    [SerializeField] int citySpawnStart = 4000;
//    [SerializeField] int sectionLength = 350;

//    [Header("Borders and Prefabs")]
//    [SerializeField] GameObject levelBorder1;
//    [SerializeField] GameObject levelBorder2;
//    [SerializeField] GameObject ice;
//    [SerializeField] GameObject forest;
//    [SerializeField] GameObject city;
//    [SerializeField] GameObject player;

//    private enum LevelType { Ice, Forest, City }
//    private LevelType currentLevel;

//    private int zPosition;
//    private bool passedIce, passedForest;
//    private List<GameObject> activeSections = new List<GameObject>();

//    private void Start()
//    {
//        GlobalMovement.leftSide = -27;
//        GlobalMovement.rightSide = 27;
//        SpawnInitialIceSection();
//    }

//    private void FixedUpdate()
//    {
//        if (GlobalMovement.endGame) return;

//        UpdateLevelType();
//        UpdateBoundaries();
//        SpawnSections();
//        CleanupSections();
//    }

//    private void SpawnInitialIceSection()
//    {
//        InstantiateAndTrack(iceSections[Random.Range(0, iceSections.Length)], new Vector3(0, 0, 1300));
//        zPosition = 1700;
//    }

//    private void UpdateLevelType()
//    {
//        float playerZ = player.transform.position.z;

//        if (playerZ < forestSpawnStart)
//        {
//            currentLevel = LevelType.Ice;
//            ActivateLevel(ice, true);
//            ActivateLevel(forest, false);
//            ActivateLevel(city, false);
//            TransformLevelBorder(levelBorder1, zPosition - sectionLength);
//        }
//        else if (playerZ < citySpawnStart)
//        {
//            if (currentLevel != LevelType.Forest)
//            {
//                currentLevel = LevelType.Forest;
//                TransformLevelBorder(levelBorder1, zPosition);
//                SpawnForestStartSections();
//            }
//            ActivateLevel(forest, true);
//        }
//        else
//        {
//            if (currentLevel != LevelType.City)
//            {
//                currentLevel = LevelType.City;
//                TransformLevelBorder(levelBorder2, zPosition);
//                SpawnCityStartSections();
//            }
//            ActivateLevel(city, true);
//        }
//    }

//    private void UpdateBoundaries()
//    {
//        float playerZ = player.transform.position.z;
//        if (playerZ < levelBorder1.transform.position.z)
//        {
//            SetVerticalBoundaries(-75, -68);
//        }
//        else if (playerZ > levelBorder1.transform.position.z - 300)
//        {
//            SetVerticalBoundaries(-75, 20);
//            passedIce = true;
//        }
//        else if (playerZ > levelBorder2.transform.position.z - 400)
//        {
//            SetVerticalBoundaries(-75, 96);
//            passedForest = true;
//        }
//    }

//    private void SpawnSections()
//    {
//        if (currentLevel == LevelType.Ice)
//            TrySpawnSection(iceSections);
//        else if (currentLevel == LevelType.Forest)
//            TrySpawnSection(forestSections);
//        else if (currentLevel == LevelType.City)
//            TrySpawnSection(citySections);
//    }

//    private void SpawnForestStartSections()
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            InstantiateAndTrack(forestSections[Random.Range(0, forestSections.Length)], new Vector3(0, 0, zPosition));
//            zPosition += sectionLength;
//        }
//    }

//    private void SpawnCityStartSections()
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            InstantiateAndTrack(citySections[Random.Range(0, citySections.Length)], new Vector3(0, 0, zPosition));
//            zPosition += sectionLength;
//        }
//    }

//    private void TrySpawnSection(GameObject[] sectionPrefabs)
//    {
//        if (activeSections.Count == 0 ||
//            activeSections.Last().transform.position.z - player.transform.position.z < spawnDistance)
//        {
//            GameObject sectionToSpawn = sectionPrefabs[Random.Range(0, sectionPrefabs.Length)];
//            InstantiateAndTrack(sectionToSpawn, new Vector3(0, 0, zPosition));
//            zPosition += sectionLength;
//        }
//    }

//    private void CleanupSections()
//    {
//        for (int i = activeSections.Count - 1; i >= 0; i--)
//        {
//            if (player.transform.position.z > activeSections[i].transform.position.z + spawnDistance)
//            {
//                Destroy(activeSections[i]);
//                activeSections.RemoveAt(i);
//            }
//        }
//    }

//    private void InstantiateAndTrack(GameObject prefab, Vector3 position)
//    {
//        GameObject newSection = Instantiate(prefab, position, Quaternion.identity);
//        activeSections.Add(newSection);
//    }

//    private void TransformLevelBorder(GameObject levelBorder, float zPosition)
//    {
//        levelBorder.transform.position = new Vector3(0, 0, zPosition);
//    }

//    private void ActivateLevel(GameObject levelObject, bool state)
//    {
//        if (levelObject.activeSelf != state)
//            levelObject.SetActive(state);
//    }

//    private void SetVerticalBoundaries(float bottom, float top)
//    {
//        GlobalMovement.bottomSide = bottom;
//        GlobalMovement.topSide = top;
//    }
//}
