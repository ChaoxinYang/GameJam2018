using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public bool isSwitching, doneSwitching;
    public int switchSpeed;
    private Vector3 leftPosition, rightPosition;
    public Weapon leftWeapon, rightWeapon;
    public Sprite weaponSprite0, weaponSprite1;

    void Start()
    {
        isSwitching = false;
        doneSwitching = false;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && isSwitching == false)
        {
            gameObject.GetComponent<playerMovement>().enabled = false;
            leftPosition = leftWeapon.gameObject.transform.position;
            rightPosition = rightWeapon.gameObject.transform.position;
            isSwitching = true;
        }

        if (isSwitching == true)
        {
            if (doneSwitching == false)
            {
                leftWeapon.gameObject.transform.position = Vector3.MoveTowards(leftWeapon.gameObject.transform.position, transform.position, Time.deltaTime * switchSpeed);
                rightWeapon.gameObject.transform.position = Vector3.MoveTowards(rightWeapon.gameObject.transform.position, transform.position, Time.deltaTime * switchSpeed);
            }
            else
            {
                leftWeapon.gameObject.transform.position = Vector3.MoveTowards(leftWeapon.gameObject.transform.position, leftPosition, Time.deltaTime * switchSpeed);
                rightWeapon.gameObject.transform.position = Vector3.MoveTowards(rightWeapon.gameObject.transform.position, rightPosition, Time.deltaTime * switchSpeed);
            }
        }

        if (leftWeapon.gameObject.transform.position == transform.position)
        {
            if (leftWeapon.weaponState == 0)
            {
                leftWeapon.weaponState = 1;
                rightWeapon.weaponState = 0;
                leftWeapon.gameObject.GetComponent<SpriteRenderer>().sprite = weaponSprite1;
                rightWeapon.gameObject.GetComponent<SpriteRenderer>().sprite = weaponSprite0;
            }
            else
            {
                leftWeapon.weaponState = 0;
                rightWeapon.weaponState = 1;
                leftWeapon.gameObject.GetComponent<SpriteRenderer>().sprite = weaponSprite0;
                rightWeapon.gameObject.GetComponent<SpriteRenderer>().sprite = weaponSprite1;
            }
            doneSwitching = true;
        }

        if (leftWeapon.gameObject.transform.position == leftPosition && doneSwitching == true)
        {
            gameObject.GetComponent<playerMovement>().enabled = true;
            isSwitching = false;
            doneSwitching = false;
        }
    }
}
