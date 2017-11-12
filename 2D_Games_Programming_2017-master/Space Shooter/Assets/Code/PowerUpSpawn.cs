using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter {
    public class PowerUpSpawn : MonoBehaviour
    {
        [SerializeField]
        private GameObject _healthPowerToSpawn;
        [SerializeField]
        private GameObject _weaponPowerToSpawn;

        private GameObject _prefabToSpawn;


        public GameObject SpawnPowerUp()
        {
            if (RandomDrop() == true)
            {
                if(_healthPowerToSpawn == null)
                {
                    Debug.Log("Cannot Find Health Power UP!");
                    return null;
                }
                _prefabToSpawn = _healthPowerToSpawn;
                Debug.Log("Health Incoming!");
            }
            else if (RandomDrop() == false)
            {
                if (_weaponPowerToSpawn == null)
                {
                    Debug.Log("Cannot Find Weapon Power UP!");
                    return _weaponPowerToSpawn;
                }
                _prefabToSpawn = _weaponPowerToSpawn;
                Debug.Log("Weapon Incoming!");

            }
            if (_prefabToSpawn != null)
            {
                GameObject spawnedObject = Instantiate(_prefabToSpawn,
                    transform.position, transform.rotation);
                return spawnedObject;
            }
            if( _prefabToSpawn == null)
            {
                Debug.Log("Prefab to Spawn null!!!");
                return null;
            }
            return _healthPowerToSpawn;
        }

        private bool RandomDrop()
        {
            if (Random.value >= 0.5)
            {
                return true;
            }
            return false;
        }
    }
}
