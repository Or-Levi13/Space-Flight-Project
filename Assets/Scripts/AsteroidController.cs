using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Asteroid_Stats
{
    public float maxHealth;
    public float currentHealth;
}
public class AsteroidController : MonoBehaviour
{
    public Asteroid_Stats stats;
    public Transform BigExplosion;
    public AudioClip explosionSound;
    public float volume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        stats.currentHealth = stats.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.currentHealth <= 0)
        {
            Instantiate(BigExplosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position, volume);
            Destroy(gameObject);
        }   
    }
}
