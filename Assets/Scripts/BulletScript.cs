using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public Transform explosion;
    public Transform BigExplosion;
    public AudioClip explosionSound;
    public float volume = 1f;
    private Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit!");
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit " + collision.gameObject.tag + "!");
        
        if (collision.gameObject.tag == "SmallAsteroid" )
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, currentPos, volume);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "LargeAsteroid")
        {
            collision.transform.GetComponent<AsteroidController>().stats.currentHealth -= 1;
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, currentPos, volume);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Instantiate(BigExplosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position, volume);
            Destroy(collision.gameObject);
        }
    }
}
