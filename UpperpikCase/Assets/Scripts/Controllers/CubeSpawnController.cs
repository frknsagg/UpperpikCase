using System;
using System.Security;
using UnityEngine;

namespace Controllers
{
    public class CubeSpawnController : MonoBehaviour
    {
        private Transform _player;
        [SerializeField] private GameObject multiplierCube;
        private bool _isLeft = false;
        [SerializeField] private Transform lastMultiplierSpawn;
        private int _multiplierNo = 4;

        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (lastMultiplierSpawn==null)
            {
                lastMultiplierSpawn = GameObject.FindWithTag("Multiplier").GetComponent<Transform>();
            }
            if (lastMultiplierSpawn.position.z-_player.position.z<12)
            {
                MultiplierCubeSpawn();
            }
        
        }

        public void MultiplierCubeSpawn()
        {
            Vector3 vec = lastMultiplierSpawn.position;
            vec.z += 4f;
            vec.x = !_isLeft ? vec.x-5 : vec.x+5;
            
            var obje = Instantiate(multiplierCube,vec,Quaternion.identity);
            obje.transform.SetParent(transform);
            lastMultiplierSpawn = obje.transform;
            obje.name = (_multiplierNo++).ToString();
            
            _isLeft = !_isLeft;
        }
    }
}
