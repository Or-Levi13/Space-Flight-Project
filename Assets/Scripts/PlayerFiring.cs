using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public float bulletSpeed = 30;
    public float lifeTime = 3;

    public AudioClip firingSound;
    public float volume = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet1 = Instantiate(bulletPrefab);
        GameObject bullet2 = Instantiate(bulletPrefab);

        AudioSource.PlayClipAtPoint(firingSound, bulletSpawn1.transform.position, volume);

        Physics.IgnoreCollision(bullet1.GetComponent<Collider>(),
            bulletSpawn1.parent.GetComponent<Collider>());

        bullet1.transform.position = bulletSpawn1.position;

        Vector3 rotation1 = bullet1.transform.rotation.eulerAngles;

        bullet1.transform.rotation = Quaternion.Euler(rotation1.x, transform.eulerAngles.y, rotation1.z);
        
        bullet1.GetComponent<Rigidbody>().AddForce(bulletSpawn1.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet1, lifeTime));


        Physics.IgnoreCollision(bullet2.GetComponent<Collider>(),
            bulletSpawn2.parent.GetComponent<Collider>());

        bullet2.transform.position = bulletSpawn2.position;

        Vector3 rotation2 = bullet2.transform.rotation.eulerAngles;

        bullet2.transform.rotation = Quaternion.Euler(rotation2.x, transform.eulerAngles.y, rotation2.z);

        bullet2.GetComponent<Rigidbody>().AddForce(bulletSpawn2.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet2, lifeTime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }


}
