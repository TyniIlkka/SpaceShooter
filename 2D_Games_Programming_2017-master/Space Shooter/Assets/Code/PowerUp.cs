using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter { 

    public class PowerUp : PlayerSpaceShip, IHealProvider {


        [SerializeField] private int healPower = 50;
        public Health health;
        public PlayerSpaceShip player;

        protected override void Awake()
        {
            base.Awake();
            health = player.GetComponent<Health>();
        }

        // Use this for initialization
        void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (true)
            {
                IHealReceiver damageReceiver = other.GetComponent<IHealReceiver>();
                if (damageReceiver != null)
                {
                    Debug.Log("Hit a damage receiver.");
                    damageReceiver.TakeHeal(GetHeal());
                  
                    
                }
                //TODO: Add to GameOpjectPool
                /*if (!_powerUp.DisposePowerUp(this))
                {
                    Debug.LogError("Could not return the projectile back to pool!");
                    Destroy(gameObject);
                }*/
            }
        }

        public int GetHeal()
        {
            return healPower;
        }
    }
}
