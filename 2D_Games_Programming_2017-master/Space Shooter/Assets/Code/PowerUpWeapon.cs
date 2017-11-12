using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpaceShooter {

    public class PowerUpWeapon : PowerUp {

        [SerializeField] private Weapon specialWeapon1;
        [SerializeField] private Weapon specialWeapon2;

        private void Awake()
        {
            
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Törmäys?");
            WeaponActivate();
        }

        public void WeaponActivate()
        {
            Debug.Log("Törmäys?");
            //Check is there Special Weapon to activate
            if (specialWeapon1 != null && specialWeapon2 != null)
            {
                if (specialWeapon1.isSpecialWeapon == false && specialWeapon2.isSpecialWeapon == false)
                {
                    Debug.Log("Weapons was not special weapon!");
                }
                if (specialWeapon1.isSpecialWeapon == true && specialWeapon2.isSpecialWeapon == true)
                {
                    specialWeapon1.WeaponActivate(true);
                    specialWeapon2.WeaponActivate(true);
                    Debug.Log("SpecialWeapons Ready to Activate!");
                }
            }
            else
            {
                Debug.Log("We didn't find SpecialWeapons!");
                return;
            }
            

        }
    }
}
