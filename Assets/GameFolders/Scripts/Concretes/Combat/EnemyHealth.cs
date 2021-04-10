using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtomGameJamProject.Concretes.Combat
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private int maxhealth;

        public int Health { get => health; set => health = value; }

        private void OnEnable()
        {
            Health = maxhealth;
        }
        private void Update()
        {
            if (Health <= 0) Destroy(this.gameObject, .3f);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                Health--;
                Debug.Log(Health);
            }
        }
    }
}

