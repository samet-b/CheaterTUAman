using AtomGameJamProject.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.Movements
{
    public class PlatformMove : MonoBehaviour, IMover
    {
        [SerializeField] private float platformMoveSpeed;
        [SerializeField] private Transform startPosition;
        [SerializeField] private Transform movePosition1;
        [SerializeField] private Transform movePosition2;

        private Vector3 _nextPosition;
        private void Start()
        {
            _nextPosition = startPosition.position;
        }
        private void Update()
        {
            Move(0);
        }
        public void Move(float direction)
        {
            if(transform.position == movePosition1.position) 
                _nextPosition = movePosition2.position;
            
            if (transform.position == movePosition2.position)
                _nextPosition = movePosition1.position;

            transform.position = Vector3.MoveTowards(transform.position, _nextPosition, platformMoveSpeed * Time.deltaTime);

        }
    }
}