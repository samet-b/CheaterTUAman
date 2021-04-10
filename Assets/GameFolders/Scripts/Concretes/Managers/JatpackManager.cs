using PreparingForJamProject.Concretes.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JatpackManager : MonoBehaviour
{
    [SerializeField] private CameraController cameraController;
    private ParticleSystem jatPackFlame;
    public float speed, jumpforce;
    Rigidbody2D rb;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jatPackFlame = FindObjectOfType<ParticleSystem>();

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            cameraController.IsCameraShake = true;
            cameraController.ShakeCamera();
            rb.AddForce(Vector2.up * jumpforce);
            jatPackFlame.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            cameraController.IsCameraShake = false;
            jatPackFlame.Stop();
        }
    }

    private void FixedUpdate()
    {
       /* if (Input.GetKey(KeyCode.Space))  {
          
        }
        else if (Input.GetKeyUp(KeyCode.Space)){
           
        }*/
        
    }
}
