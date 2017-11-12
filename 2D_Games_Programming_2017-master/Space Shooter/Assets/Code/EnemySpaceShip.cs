using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemySpaceShip : SpaceShipBase
    {
        [SerializeField]
        private float _reachedDistance = 0.5f;

        [SerializeField] private int _score;
        [SerializeField] private PowerUp powerUps;
        [SerializeField] private PowerUpSpawn _powerUpSpawner;
        [SerializeField] private float changeToDrop = 30;

        private float randomFloat = 0;
        private GameObject[] _movementTargets;
        private int _currentMovementTargetIndex = 0;

        public Transform CurrentMovementTarget
        {
            get
            {
                return _movementTargets[_currentMovementTargetIndex].transform;
            }
        }

        public override Type UnitType
        {
            get { return Type.Enemy; }
        }

        protected override void Awake()
        {
            base.Awake();
            changeToDrop = changeToDrop / 100;
        }

        protected override void Update()
        {
            base.Update();

            Shoot();
        }

        protected override void Die()
        {
            base.Die();

            //Goes through spawn or not to spawn power up
            SpawnOrNotToPowerUp();

            if (LevelController.Current != null)
            {
                LevelController.Current.EnemyDestroyed();
            }

            GameManager.Instance.IncrementScore(_score);
        }

        public void SetMovementTargets(GameObject[] movementTargets)
        {
            _movementTargets = movementTargets;
            _currentMovementTargetIndex = 0;
        }

        protected override void Move()
        {
            if (_movementTargets == null || _movementTargets.Length == 0)
            {
                return;
            }

            UpdateMovementTarget();
            Vector3 direction =
                (CurrentMovementTarget.position - transform.position).normalized;
            transform.Translate(direction * Speed * Time.deltaTime);
        }

        private void UpdateMovementTarget()
        {
            // Have we reached our current movement target or not?
            if (Vector3.Distance(transform.position,
                CurrentMovementTarget.position) < _reachedDistance)
            {
                // We have reached the target, let's update it.
                if (_currentMovementTargetIndex >= _movementTargets.Length - 1)
                {
                    // we have reached the end of our path. Let's use the first target point
                    // as our next target.
                    _currentMovementTargetIndex = 0;
                }
                else
                {
                    _currentMovementTargetIndex++;
                }
            }
        }
        //Spawn power up to enemy location.
        public PowerUp SpawnPower()
        {
            GameObject spawnedPowerUp = _powerUpSpawner.SpawnPowerUp();
            if (spawnedPowerUp != null)
            {
                powerUps = spawnedPowerUp.GetComponent<PowerUp>();
            }

            return powerUps;
        }

        public void SpawnOrNotToPowerUp()
        {
            randomFloat = Random.Range(0f, 1f);
            if (changeToDrop > randomFloat)
            {
                SpawnPower();
                Debug.Log("Drop!");
            }
        }
    }
}
