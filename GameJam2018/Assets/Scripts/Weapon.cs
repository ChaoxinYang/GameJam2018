using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponState, bulletSpeed;
    private float weaponCooldown;
    private bool canShoot;
    private string ammoToShoot;
    private Quaternion bulletOffset;

    void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        if (weaponState == 0)
        {
            weaponCooldown = 0.05f;
        }
        else if (weaponState == 1)
        {
            weaponCooldown = .4f;
        }
    }

    public void Fire()
    {
        if (canShoot == true)
        {
            canShoot = false;

            if (weaponState == 0)
            {
                bulletOffset = Quaternion.Euler(new Vector3(0, 0, Random.Range(-5f, 5f)));
                ammoToShoot = "Bullet";
            }
            if (weaponState == 1)
            {
                bulletOffset = Quaternion.Euler(new Vector3(0, 0, 0));
                ammoToShoot = "Rocket";
            }

            GameObject newBullet = ObjectPool.objectPool.GetPooledObjct(ammoToShoot, true);
            newBullet.SetActive(true);
            newBullet.transform.position = gameObject.transform.position;
            newBullet.transform.rotation = transform.rotation * bulletOffset;
            newBullet.GetComponent<Rigidbody2D>().AddForce(-newBullet.transform.right * bulletSpeed);
            StartCoroutine("WeaponCooldown");
        }
    }
    
    IEnumerator WeaponCooldown()
    {
        yield return new WaitForSeconds(weaponCooldown);
        canShoot = true;
    }
}
