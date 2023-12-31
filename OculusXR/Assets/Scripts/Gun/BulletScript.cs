using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletScript : MonoBehaviour
{
    public float bulletDamage = 10f; // Amount of damage the bullet deals
    public GameObject explosionPrefab; // Prefab of the explosion effect

    public void OnTriggerEnter(Collider collider)
    {
        IDamagable shootable = collider.GetComponent<IDamagable>();
        if (shootable != null)
        {
            shootable.TakeDamage(bulletDamage);
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
