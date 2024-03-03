// GroundSpawner.cs
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    [SerializeField] GameObject whirlpoolPrefab;

    Vector3 nextSpawnPoint;
    float deletionDistance;
    float initialDeletionDistance;
    float playerPositionZ;
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        nextSpawnPoint = Vector3.zero;

        for (int i = 0; i < 15; i++)
        {
            SpawnTile(i >= 3);
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

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            Quaternion krakenRotation = Quaternion.Euler(0, 90, 0);
            Quaternion sharkRotation = Quaternion.Euler(3, 180, 0);
            Quaternion cannonRotation = Quaternion.Euler(0, 180, 0);
            Quaternion whirlpoolRotation = Quaternion.identity;

            bool spawnKraken = Random.value < 0.01f;
            bool spawnShark = Random.value < 0.01f;
            bool spawnRock = Random.value < 0.01f; // Adjust the spawn probability as needed
            bool spawnCannon = Random.value < 0.01f; // Adjust the spawn probability as needed
            bool spawnWhirlpool = Random.value < 0.5f; // Adjust the spawn probability as needed

            if (spawnKraken)
            {
                temp.GetComponent<GroundTile>().SpawnKrakens(krakenRotation);
            }

            if (spawnShark)
            {
                temp.GetComponent<GroundTile>().SpawnSharks(sharkRotation);
            }

            temp.GetComponent<GroundTile>().SpawnCoins();

            if (spawnRock)
            {
                temp.GetComponent<GroundTile>().SpawnRock(Quaternion.identity);
            }

            if (spawnCannon)
            {
                temp.GetComponent<GroundTile>().SpawnCannon(cannonRotation);
            }

            if (spawnWhirlpool)
            {
                temp.GetComponent<GroundTile>().SpawnWhirlpool();
            }
        }
    }
}
