using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class PowerUpHealth : PowerUp, IHealProvider
    {
        [SerializeField] private int healPower = 50;

        public Health health;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
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
