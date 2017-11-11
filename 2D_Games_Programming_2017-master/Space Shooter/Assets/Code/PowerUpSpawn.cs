using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter {
    public class PowerUpSpawn : MonoBehaviour
    {
        [SerializeField]
        private GameObject _prefabToSpawn;
      

        public GameObject SpawnPowerUp()
        {
            GameObject spawnedObject = Instantiate(_prefabToSpawn,
                transform.position, transform.rotation);
            return spawnedObject;
        }
    }
}
