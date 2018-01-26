using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {
    private bool isSwitching, doneSwitching;
    private Vector3 leftPosition, rightPosition;
    public GameObject leftWeapon, rightWeapon;

	void Start () {
        leftPosition = leftWeapon.transform.position;
        rightPosition = rightWeapon.transform.position;
        isSwitching = false;
        doneSwitching = false;
	}

	void Update () {
		if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && isSwitching == false)
        {
            isSwitching = true;
        }

        if (isSwitching == true)
        {
            if (doneSwitching == false)
            {
                leftWeapon.transform.position = Vector3.MoveTowards(leftWeapon.transform.position, transform.position, Time.deltaTime);
                rightWeapon.transform.position = Vector3.MoveTowards(rightWeapon.transform.position, transform.position, Time.deltaTime);
            }
            else
            {
                leftWeapon.transform.position = Vector3.MoveTowards(leftWeapon.transform.position, leftPosition, Time.deltaTime);
                rightWeapon.transform.position = Vector3.MoveTowards(rightWeapon.transform.position, rightPosition, Time.deltaTime);
            }
        }

        if (leftWeapon.transform.position == transform.position)
        {
            doneSwitching = true;
        }

        if (leftWeapon.transform.position == leftPosition && doneSwitching == true)
        {
            isSwitching = false;
            doneSwitching = false;
        }
	}
}
