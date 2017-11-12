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
            //Debug.Log("tamaedes?");
            //if (Input.GetButtonDown("Fire2"))
            //{
            //    Debug.Log("Saati tanne?");
            //    GetHeal();
            //}
        }

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
