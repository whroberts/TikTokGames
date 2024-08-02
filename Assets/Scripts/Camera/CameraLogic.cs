using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Camera
{
    public class CameraLogic : MonoBehaviour
    {
        [SerializeField] private GameObject player = null;

        [Header("Movement")]
        [SerializeField] private float duration = 0.1f;

        private bool canCallMove = true;

        private Transform startingTrans = null;

        private void Awake()
        {
            startingTrans = transform;
        }

        private void OnEnable()
        {
            if (player != null)
                player.GetComponent<PlayerController>().OnPlayerMoved += CallLerp;
        }

        private void OnDisable()
        {
            if (player != null)
                player.GetComponent<PlayerController>().OnPlayerMoved -= CallLerp;
        }

        private void MoveCamera()
        {
            if (player != null)
            {
                Vector3 newPos = new Vector3(
                    startingTrans.position.x,
                    startingTrans.position.y,
                    player.transform.position.z + startingTrans.position.z);
                transform.position = newPos;
            }

        }

        private void CallLerp()
        {
            if (canCallMove)
                StartCoroutine(LerpToPosition());
        }

        private IEnumerator LerpToPosition()
        {
            canCallMove = false;
            float toLerp = transform.position.z;
            float goalCameraZ = player.transform.position.z + startingTrans.position.z;

            float t = 0;

            while (t < duration)
            {
                toLerp = Mathf.Lerp(transform.position.z, goalCameraZ, t / duration);
                t += Time.deltaTime;

                yield return null;
            }

            Vector3 newPos = new Vector3(
                startingTrans.position.x,
                startingTrans.position.y,
                toLerp);
            transform.position = newPos;

            canCallMove = true;
        }
    }

}