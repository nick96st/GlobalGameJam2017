﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWaves : MonoBehaviour
{
    [SerializeField]
    float fireRate;

    public float Damage;
    public LayerMask whatToHit;

    float timeToFire = 0.0f;

    Transform firePoint;

    [SerializeField]
    GameObject weaponToThrow;

    [SerializeField]
    Animator playerController;

    bool isShooting;

    float waveSpawnTimer = 2.0f;

    public AudioClip audio;
    private AudioSource source;

    void Start ()
    {
        if (GetComponent<Transform>().FindChild("FirePoint") != null)
            firePoint = GetComponent<Transform>().FindChild("FirePoint");
        else
            Debug.LogError("No such a child object was found.");
    }
	
	void Update ()
    {
        if (fireRate == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
            else
            {
                isShooting = false;
                playerController.SetFloat("Speed", 0.0f);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
            else
            {
                isShooting = false;
                playerController.SetFloat("Speed", 0.0f);
            }
        }

        playerController.SetBool("isShooting", isShooting);
    }

    private void Shoot()
    {
        isShooting = true;
        // playerController.SetBool("isShooting", isShooting);

        source = GetComponent<AudioSource>();
        source.PlayOneShot(audio);

        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        Vector2 mousePos = Input.mousePosition;

        Vector2 firePointPosition = firePoint.position;
        Quaternion firePointRotation = firePoint.rotation;

        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 1.0f, whatToHit);

        float x = mousePosition.x - firePointPosition.x;
        float y = mousePosition.y - firePointPosition.y;

        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        // checker so it does shoot at himself

        if(angle >=- 90 && angle <= 90)
        {
            if (this.GetComponent<Transform>().localRotation.y != 0)
            {
                isShooting = false;
                return;
            }
        }
        else
        {
            if (this.GetComponent<Transform>().localRotation.y == 0)
            {
                isShooting = false;
                return;
            }
        }

        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        GameObject wep;
        Vector2 direction = mousePosition - firePointPosition;
        if (hit.collider != null && !hit.collider.CompareTag("Player"))
        {
            wep = Instantiate(weaponToThrow, firePointPosition, rotation);
            wep.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            wep.GetComponent<Rigidbody2D>().velocity = direction * fireRate;
        }
        else
        {
            wep = Instantiate(weaponToThrow, firePointPosition, rotation);
            wep.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            wep.GetComponent<Rigidbody2D>().velocity = direction * fireRate;
        }

        if (isShooting)
        {
            playerController.SetFloat("Angle", angle);
        }

        return;
    }
    /*
    IEnumerator ShootAnim()
    {
        isShooting = true;
    }*/
}
