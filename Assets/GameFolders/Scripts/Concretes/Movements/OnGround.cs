using AtomGameJamProject.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.Movements
{
    public class OnGround : MonoBehaviour, IOnGround
    {
        [SerializeField] private Transform[] footTransfroms;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float distance;

        private bool _isOnGround;
        public bool IsOnGround { get => _isOnGround; set => _isOnGround = value; }

        private void Update()
        {
            CheckTransform(footTransfroms);
        }
        private void CheckTransform(Transform[] footTransfroms)
        {
            foreach (var footTransform in footTransfroms)
            {
                RaycastHit2D ray = Physics2D.Raycast(footTransform.position, footTransform.forward, distance, layerMask);
                Debug.DrawRay(footTransform.position, footTransform.forward * distance, Color.red);

                if (ray.collider != null) _isOnGround = true;
                else _isOnGround = false;
            }
        }
    }
}