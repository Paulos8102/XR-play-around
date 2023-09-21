using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletScript : MonoBehaviour
{
    public float bulletDamage = 10f; // Amount of damage the bullet deals
    //public GameObject explosionPrefab; // Prefab of the explosion effect

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            BoxLife box = other.GetComponent<BoxLife>();
            if (box != null)
            {
                box.TakeDamage(bulletDamage);
                DestroyBullet();
            }
        }
    }

    public void DestroyBullet()
    {
        //if (explosionprefab != null)
        //{
        //    instantiate(explosionprefab, transform.position, quaternion.identity);
        //}
        Destroy(gameObject);
    }
}
