using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PowerUp : MonoBehaviour {

        [SerializeField] private int deSpawn = 5;
    
        public PlayerSpaceShip player;


        private Collider2D playerCollider;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            if (_rigidbody == null)
            {
                Debug.LogError("No Rigidbody2D component was found from the GameObject");
            }
        }
	
	    
	    void Update () {
            Destroy(gameObject, deSpawn);   //DeSpawns PowwerUp after deSpawn seconds.
        }        
    }
}
