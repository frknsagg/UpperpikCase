using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using  DG.Tweening;

public class OpponentMovement : MonoBehaviour
{
    private NavMeshAgent _opponent;
    private Vector3 _target;
    private PlayerAnimationController _playerAnimationController;
    private bool _isGround = true;
    
    
    private void Start()
    {

        _playerAnimationController = GetComponent<PlayerAnimationController>();
        _opponent = GetComponent<NavMeshAgent>();
        _playerAnimationController.IdlePlayerMovementAnimation();
        _opponent.speed = 0;
        

    }

    private void Update()
    {
        
       // _opponent.baseOffset = 2;
        if (_opponent.remainingDistance <= _opponent.stoppingDistance )
        {
            SetRandomTarget();
            
        }

        
        
        if (!_isGround)
        {
            _playerAnimationController.FlyingPlayerMovementAnimation();
            
        }
        else
        {
            _playerAnimationController.RunPlayerMovementAnimation();
        }
    }

    private void SetRandomTarget()
    {
        _target = new Vector3(Random.Range(-5, 5), transform.position.y, transform.position.z + 100);
        _playerAnimationController.RunPlayerMovementAnimation();
        _opponent.SetDestination(_target);
        _opponent.speed = 2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            _isGround = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
           
            
            _isGround = true;
    
        }
    }



    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         Vector3 dir = transform.position + (collision.contacts[0].normal * 5f);
    //         transform.DOMove(dir, 2f);
    //     }
    //
    //     if (collision.gameObject.CompareTag("Finish"))
    //     {
    //
    //         animator.SetBool(İsGameStart, false);
    //         GetComponent<CapsuleCollider>().enabled = false;
    //         _rb.velocity = new Vector3(0, 0, 0);
    //         _opponent.speed = 0;
    //     }
    //
    // }

    
    
    
}
