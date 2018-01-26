using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public int weaponState, bulletSpeed;
    public float weaponCooldown;
    public GameObject bullet;
    private bool canShoot;


    void Start()
    {
        canShoot = true;
    }

    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
    */

    public void Fire() {
        if (canShoot == true)
        {
            canShoot = false;
            GameObject newBullet = ObjectPool.objectPool.GetPooledObjct("Bullet", true);
            newBullet.SetActive(true);
            newBullet.transform.position = gameObject.transform.position;
            newBullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeed);
            StartCoroutine("WeaponCooldown");
        }
	}

    IEnumerator WeaponCooldown()
    {
        yield return new WaitForSeconds(weaponCooldown);
        canShoot = true;
    }
}
