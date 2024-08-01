using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Camera
{
    public class CameraLogic : MonoBehaviour
    {
        [SerializeField] private GameObject player = null;

        private Transform startingTrans = null;

        private void Awake()
        {
            startingTrans = transform;
        }

        private void OnEnable()
        {
            player.GetComponent<PlayerController>().OnPlayerMoved += MoveCamera;
        }

        private void OnDisable()
        {
            player.GetComponent<PlayerController>().OnPlayerMoved -= MoveCamera;
        }

        private void MoveCamera()
        {
            Vector3 newPos = new Vector3(
                startingTrans.position.x,
                startingTrans.position.y,
                player.transform.position.z + startingTrans.position.z);
            transform.position = newPos;
        }
    }

}