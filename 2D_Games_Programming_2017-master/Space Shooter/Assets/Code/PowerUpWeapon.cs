using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpaceShooter {

    public class PowerUpWeapon : PowerUp {


        private Weapon specialWeapon;

        private void Awake()
        {
            specialWeapon = player.GetComponent<Weapon>();
            if (specialWeapon != null)
            {
                if (specialWeapon.isSpecialWeapon == false)
                {
                    Debug.Log("No special weapons found!");
                }
                if (specialWeapon.isSpecialWeapon == true)
                {
                    Debug.Log("SpecialWeapon Ready to Activate!");
                }
            }
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (specialWeapon.isSpecialWeapon == true)
            {
                WeaponActivate();
            }

            base.OnTriggerEnter2D(other);
        }

        public void WeaponActivate()
        {
            specialWeapon.activatedWeapons = true;

        }
    }
}
