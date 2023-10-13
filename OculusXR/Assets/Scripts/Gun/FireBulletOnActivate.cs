using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 30.0f;
    public float fireRate = 1f;

    //public ParticleSystem muzzleFlash;

    private bool isFiring = false;
    private float nextTimeToFire = 0f;

    public int maxAmmo = 5;
    private int currentAmmo = -1;
    public float reloadTime = 3f;
    private bool isReloading = false;

    public Animator anim;
    
    [SerializeField] private AudioSource reloadSound;
    [SerializeField] private AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {
        if (currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
        }

        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();

        if( !isFiring && Time.time >= nextTimeToFire )
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            grabbable.activated.AddListener(FireBullet);
        }
    }

    public void OnEnbale()
    {
        isReloading = false;
        //anim.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            Debug.Log("Has bullets");
            return;
        }

        if (currentAmmo <= 0)
        {
            Debug.Log("Reloading now");
            StartCoroutine(Reload());
            return;
        }
    }

    public static event Action GunFired; //to show in the UI Wrist band

    public void FireBullet(ActivateEventArgs arg)
    {
        isFiring = true;
        currentAmmo--;

        GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        //forward moves the object in the direction of the blue axis

        //muzzleFlash.Play();
        shootSound.Play();

        //muzzleFlash.Stop();

        isFiring = false;
        Destroy(spawnedBullet,5);

        GunFired?.Invoke(); //delegate call
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");

        //anim.SetBool("Reloading", true);

        reloadSound.Play();
        Debug.Log("Waiting shd start");
        yield return new WaitForSeconds(reloadTime - .25f);

        //anim.SetBool("Reloading", false);
        Debug.Log("Waiting over ig");
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
