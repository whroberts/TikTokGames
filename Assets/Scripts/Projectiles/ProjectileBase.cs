using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectiles
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        [Header("Values")]
        [SerializeField] private float initalVelocity = 5f;
        [SerializeField] private float currentVelocity = 0f;
        [SerializeField] private float maxTimeAlive = 5f;

        private Rigidbody rb = null;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            currentVelocity = rb.velocity.magnitude;
        }

        protected virtual void Shoot(Vector3 playerForward)
        {
            rb.AddForce(playerForward * initalVelocity);

            Destroy(gameObject, maxTimeAlive);
        }

        protected virtual void Damage()
        {

        }
    }

}