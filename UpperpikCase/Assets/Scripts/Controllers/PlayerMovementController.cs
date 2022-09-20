using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;


    public class PlayerMovementController : MonoBehaviour
    { 
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;
   
        private SwerveInputSystem _swerveInputSystem;
        [SerializeField] public bool _isReadyToPlay, _isReadyToMove;
    
        public bool _isGround = true;
        public bool _isFinish;
        private Sequence _sequence;
   
    
        void Start()
        {
            _swerveInputSystem =GetComponent<SwerveInputSystem>();
            DOTween.Init();
        }
        void FixedUpdate()
        {
            if (_isReadyToPlay)
            { 
                if (_isReadyToMove && _isGround)
                {
                    Move();
                }
                else if (!_isGround && _isReadyToMove )
                { 
                    Fly();
                }
            }
        }
        
        private void Move()
        {
            var velo = rb.velocity;
            velo.z = transform.forward.z * speed;
            velo.x = transform.forward.x * speed;
            rb.velocity = velo;
            Rotate();
        }

       
        private void Fly()
        {
            var velo = rb.velocity;
            velo.z = transform.forward.z * speed;
            velo.x = transform.forward.x * speed;
            rb.velocity = velo;
            Rotate();
            if (GameManager.instance.WoodCount > 0 && _swerveInputSystem.MoveFactorX!=0)
            {
                velo.y = Math.Abs(_swerveInputSystem.MoveFactorX * Time.deltaTime*1.5f);
                rb.velocity = velo;
                GameManager.instance.Flying();
            }

            else
            {
                velo.y = -0.75f;
                rb.velocity = velo;
            }
        
        }
        public void EnableMovement()
        {
            _isReadyToPlay = true;
            _isReadyToMove = true;
            _swerveInputSystem.enabled = true;

        }
        public void DeactiveMovement()
        {
            _isReadyToPlay = false;
            _isReadyToMove = false;
            _swerveInputSystem.enabled = false;
        }

        public void Rotate()
        {
            if (_swerveInputSystem.MoveFactorX!=0 )
            {
                Vector3 vec = new Vector3(0, _swerveInputSystem.MoveFactorX * rotationSpeed * Time.deltaTime, 0);
                vec.Normalize();
              //  Debug.Log(vec);
                transform.Rotate(vec);
            }
        }
       public  void PlayerStartAction()
       {

          
            gameObject.GetComponent<PlayerAnimationController>().IdlePlayerMovementAnimation();
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOMove(new Vector3(0, 50f, transform.position.z), 2f))
                .Append(transform.DOMove(new Vector3(0, 0.55f, 0), 1f)).OnComplete((() =>
                {
                    StartAction();
                }));
           

        }

        private void StartAction()
        {
            
            Vector3 angular;
            angular = Vector3.zero;
            rb.angularVelocity = angular;
            transform.DORotate(Vector3.zero, 1f);
            

        }
    
   
    }

