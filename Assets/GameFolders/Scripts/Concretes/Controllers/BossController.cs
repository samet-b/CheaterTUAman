using AtomGameJamProject.Abstracts.Controllers;
using AtomGameJamProject.Concretes.Managers;
using AtomGameJamProject.Concretes.Observers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.Controllers
{
    public class BossController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float bossSpeed;
        [SerializeField] private AudioClip[] gruntClips;
        [SerializeField] private AudioObserver _audioObserver;
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;
        [SerializeField] private GameObject[] rocks;
        [SerializeField] private Transform[] rockSpawnPoints;

        private Animator _animator;

        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int Health { get => health; set => health = value; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            Health = maxHealth;
        }
        private void Start()
        {
            InvokeRepeating("SpawnRock", 1f, 2f);
        }
        private void Update()
        {
            BossMove();
            Dead();
        }
        private void BossMove()
        {
            float mov = Mathf.PingPong(Time.time * bossSpeed, 5f);
            transform.position = new Vector3(mov, transform.position.y, transform.position.z);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            int ranClip = Random.Range(0, gruntClips.Length);
            
            if(collision.gameObject.tag == "Bullet")
            {
                Health--;
                _animator.SetTrigger("damage");
                _audioObserver.PlayOneShot(gruntClips[ranClip]);
            }
        }
        private void Dead()
        {
            if (Health <= 0)
            {
                Health = 0;
                GameManager.Instance.ChangeScene(7);
            }
        }
        private void SpawnRock()
        {
            int ranRock = Random.Range(0, rocks.Length);
            for(int i = 0; i < rockSpawnPoints.Length; i++)
            {
                GameObject rock = Instantiate(rocks[ranRock], rockSpawnPoints[i].position, Quaternion.identity) as GameObject;

                rock.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Time.deltaTime * 300);
            }
        }
    }
}