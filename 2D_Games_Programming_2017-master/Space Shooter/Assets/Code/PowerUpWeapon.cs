using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpaceShooter {

    public class PowerUpWeapon : PowerUp {

        [SerializeField] private Weapon specialWeapon1;
        [SerializeField] private Weapon specialWeapon2;

        private void Awake()
        {
            specialWeapon1.isSpecialWeapon = true;
            specialWeapon2.isSpecialWeapon = true;
        }

        public void Update()
        {

        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            ActivateWeapon();
            Destroy(gameObject);
        }

        public void ActivateWeapon()
        {
            Debug.Log("Törmäys?");
            //Check is there Special Weapon to activate
            if (specialWeapon1 != null && specialWeapon2 != null)
            {
                if (specialWeapon1.isSpecialWeapon == false && specialWeapon2.isSpecialWeapon == false)
                {
                    Debug.Log("Weapons was not special weapon!");
                }
                if (specialWeapon1.isSpecialWeapon == true || specialWeapon2.isSpecialWeapon == true)
                {
                    specialWeapon1.activetedWeapons = true;
                    specialWeapon2.WeaponActivate(true);
                    Debug.Log("SpecialWeapons should be Activated!");
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
