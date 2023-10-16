using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletScript : MonoBehaviour
{
    public float bulletDamage = 10f; // Amount of damage the bullet deals
    public GameObject explosionPrefab; // Prefab of the explosion effect
    //private GameObject bulletPrefab;
    //
    //private void Start()
    //{
    //    BulletScript bullet = bulletPrefab.GetComponent<Collider>();
    //}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            BoxLife box = other.GetComponent<BoxLife>();
            if (box != null)
            {
                box.TakeDamage(bulletDamage);
            }
            
        }
        DestroyBullet();
        //bullet will get destroyed if it hits any object (-u-)
    }

    public void DestroyBullet()
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
