using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static int playerLives = 1;

    Animator animator;
    public Transform explosion;
    public AudioClip explosionSound;
    public float volume = 1f;
    public Transform playerShip;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            LeftRoll("LeftRoll");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            RightRoll("RightRoll");
        }
        /*if (animator.GetCurrentAnimatorStateInfo(0).IsName("LeftRoll"))
        {
            Vector3 temp = new Vector3(-6.0f, 0, 0);
            transform.position += temp * Time.deltaTime;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("RightRoll"))
        {
            Vector3 temp = new Vector3(6.0f, 0, 0);
            transform.position += temp * Time.deltaTime;
        }*/

    }
    private void LeftRoll(string v)
    {
        animator.SetTrigger(v);
        
    }
    private void RightRoll(string v)
    {
        animator.SetTrigger(v);
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ship hit " + collision.gameObject.tag + "!");

        if (collision.gameObject.tag == "SmallAsteroid" || collision.gameObject.tag == "LargeAsteroid" || collision.gameObject.tag == "Enemy")
        {
            
            StartCoroutine(PlayerDeath());
        }
    }

    private IEnumerator PlayerDeath()
    {
        
        Instantiate(explosion, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position, volume);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
}
