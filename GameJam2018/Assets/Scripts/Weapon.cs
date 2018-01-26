using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public int weaponState;
	
	public void Fire () {
		if (weaponState == 0)
        {
            // Behaviour for weapon state 0.
        }
        else if (weaponState == 1)
        {
            // Behaviour for weapon state 1.
        }
	}
}
