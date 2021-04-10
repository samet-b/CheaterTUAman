using AtomGameJamProject.Abstracts.Controllers;
using AtomGameJamProject.Abstracts.Movements;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AtomGameJamProject.Concretes.Controllers
{
    [RequireComponent(typeof(BoxCollider2D)), RequireComponent(typeof(Rigidbody2D))]

    public sealed class GameCharacterController : AtomGameJamProject.Abstracts.Controllers.CharacterController, IEntityController
    {
        [SerializeField] private AudioClip laserFire;

        private HandController _hand;
        private Vector3 _mousePos;


        protected override void Awake()
        {
            base.Awake();
            _hand = GetComponentInChildren<HandController>();
        }

        protected override void Update()
        {
            base.Update();
            CheckJumpAction();
            _hand.ControlHand(_mousePos);
            if (_input.IsFireButtonDown) audioObserver.PlayOneShot(laserFire);
        }
        private void FixedUpdate()
        {
            JumpAction();
        }
        protected override void JumpAction()
        {
            base.JumpAction();
        }
        protected override void CheckJumpAction()
        {
            base.CheckJumpAction();
        }
    }
}