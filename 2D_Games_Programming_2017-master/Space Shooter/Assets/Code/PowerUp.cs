using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PowerUp : MonoBehaviour, IHealProvider {


        [SerializeField] private int healPower = 50;
        [SerializeField] private int deSpawn = 5;

        public Health health;
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
	
	    // Update is called once per frame
	    void Update () {
            Destroy(gameObject, deSpawn);
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            IHealReceiver healReceiver = other.GetComponent<IHealReceiver>();
            if (healReceiver != null)
            {
                Debug.Log("Hit a heal receiver.");
                healReceiver.TakeHeal(GetHeal());
                Destroy(gameObject);
                    
            }
            //TODO: Add to GameOpjectPool
            /*if (!_powerUp.DisposePowerUp(this))
            {
                Debug.LogError("Could not return the projectile back to pool!");
                Destroy(gameObject);
            }*/
            
        }

        public int GetHeal()
        {
            return healPower;
        }
    }
}
