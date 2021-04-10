using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletDamage, lifeTime;


    private void Start()
    {
        Destroy(gameObject,lifeTime);
    }
}
