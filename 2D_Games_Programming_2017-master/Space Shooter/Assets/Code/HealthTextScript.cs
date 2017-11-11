using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpaceShooter {

    public class HealthTextScript : MonoBehaviour {

        private TextMeshPro valueText;

        [SerializeField] private Health health;
        public float Value
        {
            set
            {
                string[] tmp = valueText.text.Split(':');
                valueText.text = tmp[0] + ": " + value;
            }
        }
        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
    
}
