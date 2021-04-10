using AtomGameJamProject.Abstracts.Controllers;
using AtomGameJamProject.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.Movements
{
    public class JumpWithAddForce : IJump
    {
        private IEntityController _controller;
        private float _jumpSpeed;
        private bool _isJump;
        public bool IsJump { get => _isJump; set => _isJump = value; }

        public JumpWithAddForce(IEntityController controller, float jumpSpeed)
        {
            _controller = controller;
            _jumpSpeed = jumpSpeed;
        }
        public void Jump()
        {
            _controller.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpSpeed);
        }
    }
}