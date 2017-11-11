using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SpaceShooter.States;

namespace SpaceShooter.UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _currentHealth;

        private void OnEnable()
        {
            CurrentHealth(GameManager.Instance.CurrentHealth);
        }

        private void Update()
        {
            int testi = CurrentHealth(GameManager.Instance.CurrentHealth);
            Debug.Log(testi+ " testi");
        }
        
        private int CurrentHealth(int amount)
        {
            Debug.Log(amount);
            if (_currentHealth != null)
            {
                _currentHealth.text = "Health: " + amount;
            }
            return amount;
        }
    }
}
