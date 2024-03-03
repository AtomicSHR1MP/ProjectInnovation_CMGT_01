// GroundTile.cs
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject krakenPrefab;
    [SerializeField] GameObject sharkPrefab;
    [SerializeField] GameObject cannonPrefab;
    [SerializeField] GameObject rockPrefab;
    [SerializeField] GameObject whirlpoolPrefab;

    private void Start()
    {
        groundSpawner = FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnKrakens(Quaternion rotation)
    {
        int krakenSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(krakenSpawnIndex).transform;

        Instantiate(krakenPrefab, spawnPoint.position, rotation, transform);
    }

    public void SpawnSharks(Quaternion rotation)
    {
        int sharkSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(sharkSpawnIndex).transform;

        Instantiate(sharkPrefab, spawnPoint.position, rotation, transform);
    }

    public void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    public void SpawnRock(Quaternion rotation)
    {
        if (Random.value < 0.5f) // Adjust the spawn probability as needed
        {
            int rockSpawnIndex = Random.Range(2, 5);
            Transform spawnPoint = transform.GetChild(rockSpawnIndex).transform;

            Instantiate(rockPrefab, spawnPoint.position, Quaternion.identity, transform);
        }
    }

    public void SpawnCannon(Quaternion rotation)
    {
        int cannonSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(cannonSpawnIndex).transform;

        Instantiate(cannonPrefab, spawnPoint.position, rotation, transform);
    }

    public void SpawnWhirlpool()
    {
        int whirlpoolSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(whirlpoolSpawnIndex).transform;

        Instantiate(whirlpoolPrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}