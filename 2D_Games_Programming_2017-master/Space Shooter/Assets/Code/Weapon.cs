using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
	public class Weapon : MonoBehaviour
	{
		[SerializeField]
		private float _cooldownTime = 1.5f;
		[SerializeField]
		private Projectile _projectilePrefab;
        [SerializeField]
        private bool activetedWeapons = false;
        [SerializeField]
        public bool isSpecialWeapon = false;
        [SerializeField]
        public bool isNormallWeapon = false;
        [SerializeField]
        private float _activeTimeSpecial = 5f;

        private float _timeSinceActivated = 0f;
        

        private float _timeSinceShot = 0f;
		private bool _isInCooldown = false;
		private SpaceShipBase _owner;

		public void Init( SpaceShipBase owner )
		{
			_owner = owner;
		}
		
		public bool Shoot()
		{
            if (!isSpecialWeapon && isNormallWeapon)
            {
                if (_isInCooldown )
                {
                    return false;
                }

                // Get the projectile from the pool and set its position and rotation.
                Projectile projectile = LevelController.Current.GetProjectile(_owner.UnitType);
                if (projectile != null)
                {
                    projectile.transform.position = transform.position;
                    projectile.transform.rotation = transform.rotation;
                    projectile.Launch(this, transform.up);

                    // Go to the cooldown phase.
                    _isInCooldown = true;
                    // We just shot the projectile so time since shot is 0.
                    _timeSinceShot = 0;

                    return true;
                }
                return false;
            }
            if (isSpecialWeapon && activetedWeapons && !isNormallWeapon)
            {
                Debug.Log("ammuuu");
                if (_isInCooldown)
                {
                    return false;
                }
                // Get the projectile from the pool and set its position and rotation.
                Projectile projectile = LevelController.Current.GetProjectile(_owner.UnitType);
                if (projectile != null)
                {
                    projectile.transform.position = transform.position;
                    projectile.transform.rotation = transform.rotation;
                    projectile.Launch(this, transform.up);

                    // Go to the cooldown phase.
                    _isInCooldown = true;
                    // We just shot the projectile so time since shot is 0.
                    _timeSinceShot = 0;

                    return true;
                }
                return false;

            }
            return false;
			
		}

		public bool DisposeProjectile( Projectile projectile )
		{
			return LevelController.Current.ReturnProjectile(_owner.UnitType, projectile);
		}
		
		protected virtual void Update()
		{
			if(_isInCooldown)
			{
				_timeSinceShot += Time.deltaTime;
				if(_timeSinceShot >= _cooldownTime)
				{
					_isInCooldown = false;
				}
			}

            if (activetedWeapons)
            {
                _timeSinceActivated += Time.deltaTime;
                if(_timeSinceActivated >= _activeTimeSpecial)
                {
                    activetedWeapons = false;
                }
            }
		}

        public void WeaponActivate(bool state)
        {
            Debug.Log("PaaseekoTanne?" + state);
            activetedWeapons = state;
            _timeSinceActivated = 0;
        }
	}
}
