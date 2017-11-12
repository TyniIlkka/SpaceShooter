using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{

    public class PowerUpHealth : PowerUp, IHealProvider
    {

        
        [SerializeField] private int healPower = 50;

        public Health health;

        // Activates Healing when hit with player.
        public void OnTriggerEnter2D(Collider2D other)
        {
            IHealReceiver healReceiver = other.GetComponent<IHealReceiver>();
            if (healReceiver != null)
            {
                Debug.Log("Hit a heal receiver.");
                healReceiver.TakeHeal(GetHeal());
                Destroy(gameObject);
            }
            if (healReceiver == null)
            {
                Debug.Log("No healReceiver!");
            }
        }

        public int GetHeal()
        {
            Debug.Log("Healed: " + healPower);
            return healPower;
        }
    }
}
