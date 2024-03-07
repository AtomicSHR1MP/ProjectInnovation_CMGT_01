using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public int difficulty_score;
    GroundSpawner groundSpawner;
    PlayerMovement playerMovement;

    void Start()
    {
        groundSpawner = FindObjectOfType<GroundSpawner>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (playerMovement != null)
        {
            Vector3 groundPlayerVec = playerMovement.transform.position - transform.position;
            if (groundPlayerVec.sqrMagnitude > 50 * 50 && Vector3.Dot(groundPlayerVec, Vector3.forward) > 1)
            {
                groundSpawner.SpawnTile();
                Destroy(gameObject);
            }
        }
    }
}
