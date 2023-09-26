using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20.0f;

    private bool isFiring = false;
    //private float nextTimeToFire = 0f;

    public int maxAmmo = 5;
    private int currentAmmo;
    public float reloadTime = 3f;
    private bool isReloading = false;

    public Animator anim;
    public ParticleSystem muzzleFlash;

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
        grabbable.activated.AddListener(FireBullet);
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
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
    }

    public static event Action GunFired; //to show in the UI Wrist band

    public void FireBullet(ActivateEventArgs arg)
    {
        muzzleFlash.Play();

        isFiring = true;
        currentAmmo--;

        GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        //forward moves the object in the direction of the blue axis

        shootSound.Play();
        isFiring = false;
        Destroy(spawnedBullet,5);

        GunFired?.Invoke(); //delegate call
    }

    public IEnumerator Reload()
    {
        isReloading = true;

        //anim.SetBool("Reloading", true);

        reloadSound.Play();

        yield return new WaitForSeconds(reloadTime - .25f);

        //anim.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
