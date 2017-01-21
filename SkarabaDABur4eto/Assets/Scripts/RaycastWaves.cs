using System.Collections;
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

    void Start ()
    {
        if (GetComponent<Transform>().FindChild("FirePoint") != null)
            firePoint = GetComponent<Transform>().FindChild("FirePoint");
        else
            Debug.LogError("No such a child object was found.");
    }
	
	void Update ()
    {
		if(fireRate == 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

    private void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        Vector2 mousePos = Input.mousePosition;

        Vector2 firePointPosition =firePoint.position;
        Quaternion firePointRotation = firePoint.rotation;

        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100.0f, whatToHit);
        //Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);

        float x = mousePos.x - firePointPosition.x;
        float y = mousePos.y - firePointPosition.y;

        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Debug.Log("You hit " + hit.collider.name);
        }

        // float shootAngle = Mathf
        Debug.Log(angle);
        //playerController.SetFloat("ShootingARM", hei)
        GameObject wep;
        if (hit.collider != null && !hit.collider.CompareTag("Player"))
        {
            for (int i = 0; i < 3; i++)
            {
                wep = Instantiate(weaponToThrow, firePointPosition, Quaternion.identity);
                wep.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

                Vector2 direction = mousePosition - firePointPosition;
                wep.GetComponent<Rigidbody2D>().velocity = direction * fireRate;
            }
        }
        /*
        else if ((angle < 130 && angle > -170))
        {
            for (int i = 0; i < 3; i++)
            {
                wep = Instantiate(weaponToThrow, firePointPosition, Quaternion.identity);
                wep.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

                Vector2 direction = mousePosition - firePointPosition;
                wep.GetComponent<Rigidbody2D>().velocity = direction * fireRate;
            }
        }
        */
    }
}
