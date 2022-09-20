using System;
using DG.Tweening;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        private PlayerMovementController _playerMovementController;
      
        private void Start()
        {
            _playerMovementController = GetComponent<PlayerMovementController>();
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Road"))
            {
                transform.DOMoveY(transform.position.y+1f, 1f);
                gameObject.GetComponent<PlayerAnimationController>().FlyingPlayerMovementAnimation();
                _playerMovementController._isGround = false;
    
            }
        }
        

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Road")&& _playerMovementController._isReadyToMove)
            {
                gameObject.GetComponent<PlayerAnimationController>().RunPlayerMovementAnimation();
                _playerMovementController._isGround = true;
               
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wood"))
            {
                other.gameObject.SetActive(false);
                StartCoroutine(GameManager.instance.ActivateWood(other.gameObject));
                GameManager.instance.WoodCount += 1;
                
            }

            if (other.CompareTag("Finish"))
            {
                transform.DOMoveY(transform.position.y + 2.5f, 1.5f);

                UIManager.instance.GameFinished();
                _playerMovementController._isFinish = true;
            }
            if (other.CompareTag("Multiplier"))
            {
                if (_playerMovementController._isFinish)
                {
                    other.tag = "Untagged";
                    Vector3 vec = other.transform.position;
                    vec.y += 0.5f;
                    transform.DOMove(vec, 1f);
                    gameObject.GetComponent<PlayerAnimationController>().IdlePlayerMovementAnimation();
                    gameObject.GetComponent<SwerveInputSystem>().enabled = false;
                    _playerMovementController._isGround = true;
                    GameManager.instance.Multiplier = Convert.ToInt32(other.name);
            
                    _playerMovementController.DeactiveMovement();
                    UIManager.instance.ActivateNextLevelPanel();
                    other.GetComponent<BoxCollider>().isTrigger = false;
                    LevelManager.instance.LevelFinished();
                    Debug.Log("Multiplier");
                
                }
                else
                {
                    _playerMovementController.DeactiveMovement();
                    _playerMovementController. _isGround = true;
                    GameManager.instance.Multiplier = 0;
                    gameObject.GetComponent<PlayerAnimationController>().IdlePlayerMovementAnimation();
                    gameObject.GetComponent<SwerveInputSystem>().enabled = false;
                    UIManager.instance.ActivateGameOverPanel();
                }
            }
        }

      
        }
}


