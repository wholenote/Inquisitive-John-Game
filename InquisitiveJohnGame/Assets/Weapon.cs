using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firepoint;
    public GameObject bulletPrefab;
    public AudioClip shootSound;
    private AudioSource source;
    private float volLowRange = .9f;
    private float volHighRange = 1.0f;

    void Awake()
    {

        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(shootSound, vol);
        }
	}
    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
}
