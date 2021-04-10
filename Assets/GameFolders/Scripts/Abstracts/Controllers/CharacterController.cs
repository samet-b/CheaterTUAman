using AtomGameJamProject.Abstracts.Animations;
using AtomGameJamProject.Abstracts.Inputs;
using AtomGameJamProject.Abstracts.Interacts;
using AtomGameJamProject.Abstracts.Movements;
using AtomGameJamProject.Concretes.Controllers;
using AtomGameJamProject.Concretes.Interacts;
using AtomGameJamProject.Concretes.Movements;
using AtomGameJamProject.Concretes.Observers;
using PreparingForJamProject.Concretes.Controllers;
using UnityEngine;

namespace AtomGameJamProject.Abstracts.Controllers
{
    public abstract class CharacterController : MonoBehaviour, IEntityController
    {
        [Header("----Speeds----")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpSpeed;

        [Header("----Others----")]
        [SerializeField] private float scaleValue;
        [SerializeField] private CameraController cameraController;

        [Header("----AudioClips----")]
        [SerializeField] protected AudioObserver audioObserver;
        [SerializeField] private AudioClip[] jumpClips;
        [SerializeField] private AudioClip[] walkClips;

        private IMover _mover;
        protected IInput _input;
        private IJump _jump;
        private IOnGround _onGround;
        protected IFlip _flip;
        private IAnimation _animation;
        private IInteract _interact;

        protected float hor;

        protected virtual void Awake()
        {
            _flip = new FlipWithScale(this);
            _jump = new JumpWithAddForce(this, jumpSpeed);
            _mover = new MoveWithTranslate(this, moveSpeed);
            _input = new PcInput();
            _animation = new AnimatorController(this);
            _onGround = GetComponent<OnGround>();
            _interact = FindObjectOfType<InteractWithFlash>();
        }
        protected virtual void Update()
        {
            hor = _input.Horizontal;
            MoveAction(hor);
            FlipAction(hor, scaleValue);
            AnimatorAction(hor);
        }
        protected virtual void InteractAction()
        {
            if (_input.IsInteractButtonDown) 
            {
                Debug.Log("OKEY");
                _interact.Interact();
            }
        }
        protected virtual void CheckJumpAction()
        {
            if (_input.Jump && _onGround.IsOnGround) _jump.IsJump = true;
        }
        protected virtual void JumpAction()
        {
            int ranNum = Random.Range(0, jumpClips.Length);

            if (_jump.IsJump && _onGround.IsOnGround)
            {
                audioObserver.IsSoundPlaying = true;
                audioObserver.CurrentAudioTime = 0.0f;
                audioObserver.PlayOneShot(jumpClips[ranNum]);
                cameraController.IsCameraShake = true;
                cameraController.ShakeCamera();
                _jump.IsJump = false;
                _onGround.IsOnGround = false;
                _jump.Jump();
            }
            
        }
        protected virtual void MoveAction(float hor)
        {
            int ranNum = Random.Range(0, walkClips.Length);

            if (hor == 0) {return; }
            if (hor != 0) _mover.Move(hor);

            if (_onGround.IsOnGround && hor != 0 && audioObserver.AudioPlayTime == audioObserver.CurrentAudioTime) 
            {
                audioObserver.IsSoundPlaying = true;
                audioObserver.CurrentAudioTime = 0.0f;
                audioObserver.PlayOneShot(walkClips[ranNum]);
            }
        }
        protected virtual void FlipAction(float hor, float scaleValue)
        {
            _flip.Flip(hor, scaleValue);
        }
        protected virtual void AnimatorAction(float hor)
        {
            hor = Mathf.Abs(hor);
            _animation.WalkAnimation(hor);
        }
    }
}