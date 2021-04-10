using AtomGameJamProject.Abstracts.Controllers;
using AtomGameJamProject.Abstracts.Inputs;
using AtomGameJamProject.Abstracts.Movements;
using AtomGameJamProject.Concretes.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.Controllers
{
    public class HandController : MonoBehaviour
    {
        [SerializeField] private Transform bullet;
        [SerializeField] private Transform muzzle;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private bool isLookingLeft;

        private IInput _input;
        private Vector3 _mousePos;

        private void Awake()
        {
            _input = new PcInput();
        }

        private void Update()
        {
            if (_input.IsFireButtonDown) ShootBullet();

            if (_input.Horizontal < 0) isLookingLeft = true;
            if (_input.Horizontal > 0) isLookingLeft = false;
        }
        void ShootBullet()
        {
            Transform tempBullet;
            tempBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);

            if (isLookingLeft)
            {
                tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.right * -1 * bulletSpeed);
            }
            if (!isLookingLeft)
                tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.right * bulletSpeed);

        }
        public void ControlHand(Vector3 mousePos)
        {
            _mousePos = mousePos;
            _mousePos = Input.mousePosition;

            Vector3 aimDis = (Camera.main.ScreenToWorldPoint(_mousePos) - this.transform.position).normalized;

            float angle = Mathf.Atan2(aimDis.y, aimDis.x);
            float degreeAngle = angle * Mathf.Rad2Deg + 90;

            Vector3 rotationVector = new Vector3(0f, 0f, degreeAngle);
            this.transform.rotation = Quaternion.Euler(rotationVector);
        }
    }
}