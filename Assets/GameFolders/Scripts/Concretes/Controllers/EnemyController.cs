using AtomGameJamProject.Abstracts.Animations;
using AtomGameJamProject.Abstracts.Controllers;
using AtomGameJamProject.Abstracts.Movements;
using AtomGameJamProject.Concretes.Combat;
using AtomGameJamProject.Concretes.Managers;
using AtomGameJamProject.Concretes.Movements;
using AtomGameJamProject.Concretes.Observers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float animationWalkTime = 5f; // örnek olarak: 5 saniye yürü
        [SerializeField] private float waitTime = 3f; // örnek olarak: 3 saniye dur
        [SerializeField] private AudioClip deathClip;

        private float _currentTime;
        private bool _canMove = false;
        private bool _isLookingLeft = false;

        private EnemyHealth _health;
        private AudioSource _audioSource;

        private IMover _mover;
        private IFlip _flip;
        private IAnimation _animation;

        private void Awake()
        {
            _health = GetComponent<EnemyHealth>();
            _flip = new FlipWithScale(this);
            _mover = new MoveWithTranslate(this, moveSpeed);
            _animation = new AnimatorController(this);
            _audioSource = GetComponentInChildren<AudioSource>();
        }

        private void Update()
        {
            ControlEnemyMovements();
            DeadAction();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameManager.Instance.ChangeScene(4);
            }
        }
        private void ControlEnemyMovements()
        {
            StartCoroutine(SetWaitTime());

            if (_currentTime >= animationWalkTime) _canMove = true;
            if (_currentTime >= animationWalkTime && _currentTime >= animationWalkTime * 2) // RANDOMIZE EDILMESI GEREKEN YER 2 katsayısı
            {
                _currentTime = 0.0f;
                _canMove = false;

                if (_currentTime <= animationWalkTime)
                {
                    SetDirectionsAndMovements(-0.5f, 0f, 0f);
                    _isLookingLeft = true;
                }
            }
            if (_isLookingLeft)
                SetDirectionsAndMovements(-0.5f, 0f, 0f);
            if (_isLookingLeft && _currentTime > 2.0f) // RANDOMIZE EDILMESI GEREKEN YER 2.0f katsayısı bu sayı animationWalkTime'den küçük ama _currentTimeden büyük olmalı
                SetDirectionsAndMovements(-0.5f, -1.0f, 1.0f);

        }
        private IEnumerator SetWaitTime()
        {
            yield return new WaitForSeconds(waitTime);

            _currentTime += Time.deltaTime;

            if (_canMove && _currentTime >= animationWalkTime)
            {
                SetDirectionsAndMovements(0.5f, .5f, 1.0f);
                _isLookingLeft = false;
            }
        }
        private void SetDirectionsAndMovements(float flip, float move, float walkAnim)
        {
            _flip.Flip(flip, 0);
            _mover.Move(move);
            _animation.WalkAnimation(walkAnim);
        }
        private void DeadAction()
        {
            if (_health.Health <= 0) 
            {
                _audioSource.volume = 0.1f;
                _audioSource.PlayOneShot(deathClip);
                _animation.DeadAnimation();
            }
        }
    }
}