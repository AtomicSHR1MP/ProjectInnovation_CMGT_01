using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive_Barell : MonoBehaviour
{

    public float knockbackForce = 100f;
    public GameObject[] explosionPrefabWithSmokeandEverything;
    public float delay = 0.2f;
    private AudioSource source = null;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                // Calculate the direction from the barrel to the player
                Vector3 directionToPlayer = other.transform.position - transform.position;

                // Apply knockback force instantly
                playerRigidbody.AddForce(directionToPlayer.normalized * knockbackForce, ForceMode.Impulse);

                //coroutine ? 
                StartCoroutine(SpawnExplosions());
            }
        }
    }

    IEnumerator SpawnExplosions()
    {
        for(int i = 0;i< explosionPrefabWithSmokeandEverything.Length;i++)
        {

           
            //yield?
            yield return new WaitForSeconds(delay);

            source.Play();

            //instantiate explosioins
            Instantiate(explosionPrefabWithSmokeandEverything[i],transform.position, Quaternion.identity);
        }

        MeshRenderer render = gameObject.GetComponentInChildren<MeshRenderer>();

        render.enabled = false;
        Destroy(gameObject);
        
    }

}
