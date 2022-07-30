using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator animator;
    private SwerveInputSystem _swerveInputSystem;
    private bool isGround = true;
    private RaycastHit hit;
    private Ray isingonder;
    
    
    void Start()
    {
        _swerveInputSystem =GetComponent<SwerveInputSystem>();
        
       
    }

 
    void FixedUpdate()
    {
       
//      Debug.Log(-transform.forward);
            var velo = rb.velocity;
            velo.z = transform.forward.z * speed;
            velo.x = transform.forward.x * speed;
            rb.velocity = velo;
            if (_swerveInputSystem.MoveFactorX!=0)
            {
                Vector3 vec = new Vector3(0, _swerveInputSystem.MoveFactorX * rotationSpeed * Time.deltaTime, 0);
                vec.Normalize();
                Debug.Log(vec);
                transform.Rotate(vec);
            }
            
            if (!isGround)
            {
                
                velo.y = Math.Abs(_swerveInputSystem.MoveFactorX * Time.deltaTime*0.25f);
                rb.velocity = velo;
            }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            
            animator.SetBool("isFlying",true);
            isGround = false;
    
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            animator.SetBool("isFlying",false);
            isGround = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wood"))
        {
            other.gameObject.SetActive(false);
            StartCoroutine(GameManager.instance.ActivateWood(other.gameObject));
            GameManager.instance.WoodCount += 1;
            var rbVelocity = rb.velocity;
            rbVelocity.y = 1;
        }
    }

   
}
