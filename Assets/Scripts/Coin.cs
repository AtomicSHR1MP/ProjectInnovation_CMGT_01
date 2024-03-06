using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    public AudioClip clip;
    public AudioSource source;

    private void Start()
    {
        source.clip = clip;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin collides with " + other.gameObject.name);

        // Check that the object we collided with is the player
        if (other.gameObject.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

    void CollectCoin()
    {
        Debug.Log("Coin collected!");

        GameManager.inst.CollectCoin(); // it will nform GameManager that a coin has been collected

        source.clip = clip;
        source.Play();

        MeshRenderer render = gameObject.GetComponentInChildren<MeshRenderer>();
        render.enabled = false;

        // Destroy this coin object
        // gameObject.SetActive(false);
        // Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
