// GroundSpawner.cs
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> segmentList;
    [SerializeField] int difficultyWindowSize = 50;

    Vector3 nextSpawnPoint;
    float deletionDistance;
    float initialDeletionDistance;
    float playerPositionZ;
    PlayerMovement playerMovement;

    int current_difficulty = 0;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();

        for (int i = 0; i < 15; i++)
        {
            SpawnTile();
        }
    }

    private void Update()
    {
        playerPositionZ = playerMovement.transform.position.z;
        deletionDistance = initialDeletionDistance + playerMovement.GetSpeed() * Time.deltaTime;

        foreach (Transform child in transform)
        {
            if (child.position.z < playerPositionZ - deletionDistance)
            {
                Destroy(child.gameObject);
            }
        }
    }

    // void LoadSegments()
    // {
    //     string path = "Assets/Prefabs/Segments/";

    //     Object[] segmentObjects = Resources.LoadAll(path);

    //     Debug.Log("segmenty::::");
    //     Debug.Log(segmentObjects.Length);

    //     segmentList = new List<GameObject>();

    //     foreach (var obj in segmentObjects)
    //     {
    //         GameObject prefab = (GameObject)obj;

    //         if (prefab.GetComponent<Segment>() != null)
    //         {
    //             segmentList.Add(prefab);
    //         }
    //     }
    // }

    public void SpawnTile()
    {
        List<GameObject> aviableSegments = GetAviableSegments(current_difficulty);
        GameObject segment = aviableSegments[Random.Range(0, aviableSegments.Count)];
        Instantiate(segment, Vector3.forward * (current_difficulty * 20), Quaternion.identity);

        Debug.Log("Spawned tile: " + current_difficulty + 
            " of difficulty: " + segment.GetComponent<Segment>().difficulty_score);

        current_difficulty++;
    }

    List<GameObject> GetAviableSegments(int difficulty)
    {
        List<GameObject> segmentsByDifficulty = new List<GameObject>();


        foreach (GameObject segmentPrefab in segmentList)
        {
            Segment segmentScript = segmentPrefab.GetComponent<Segment>();
            if (
                segmentScript != null &&
                segmentScript.difficulty_score <= difficulty &&
                segmentScript.difficulty_score > difficulty - difficultyWindowSize
            ){
                segmentsByDifficulty.Add(segmentPrefab);
            }
        }


        return segmentsByDifficulty;
    }
}
