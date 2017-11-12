using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SpaceShooter.States;

namespace SpaceShooter.UI
{
    public class HealthUI : MonoBehaviour
    {
        //Health GUI
        
        [SerializeField]
        private TextMeshProUGUI _currentHealth;

        private void OnEnable()
        {
            CurrentHealth(GameManager.Instance.CurrentHealth);
        }

        private void Update()
        {
            CurrentHealth(GameManager.Instance.CurrentHealth);
        }
        
        private void CurrentHealth(int amount)
        {
            if (_currentHealth != null)
            {
                _currentHealth.text = "Health: " + amount;
            }
        }
    }
}
