using AtomGameJamProject.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AtomGameJamProject.Concretes.Spawners
{
    public class RockSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] rocks;
        [SerializeField] private float platformMoveSpeed;
        [SerializeField] private Transform startPosition;
        [SerializeField] private Transform movePosition1;
        [SerializeField] private Transform movePosition2;

        private Vector3 _nextPosition;
        private void Start()
        {
            _nextPosition = startPosition.position;
            InvokeRepeating("SpawnRock", 1f, 0.8f);
        }
        private void Update()
        {
            Move();
        }
        private void SpawnRock()
        {
            int ranRock = Random.Range(0, rocks.Length);

            for(int i = 0; i < rocks.Length; i++)
            {
                Instantiate(rocks[ranRock], transform.position, transform.rotation);
            }
        }
        private void Move()
        {
            if (transform.position == movePosition1.position)
                _nextPosition = movePosition2.position;

            if (transform.position == movePosition2.position)
                _nextPosition = movePosition1.position;

            transform.position = Vector3.MoveTowards(transform.position, _nextPosition, platformMoveSpeed * Time.deltaTime);
        }
    }
}