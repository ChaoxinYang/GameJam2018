using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponState, bulletSpeed;
    private float weaponCooldown;
    private bool canShoot;

    void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        if (weaponState == 0)
        {
            weaponCooldown = 0.1f;
        }
        else if (weaponState == 1)
        {
            weaponCooldown = 2f;
        }
    }

    public void Fire()
    {
        if (canShoot == true)
        {
            canShoot = false;
            GameObject newBullet = ObjectPool.objectPool.GetPooledObjct("Bullet", true);
            newBullet.SetActive(true);
            newBullet.transform.position = gameObject.transform.position;
            newBullet.transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, 0, Random.Range(-5f, 5f)));
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
