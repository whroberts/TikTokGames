using System.Collections;
using System.Collections.Generic;
using Player;
using Projectiles;
using UnityEngine;

namespace Behavior
{
    public abstract class BehaviorBase : MonoBehaviour
    {
        [Header("Projectile")]
        [SerializeField] protected GameObject projectile = null;
        [SerializeField] protected Transform shootPosition = null;
        [SerializeField] protected float fireRate = 0.25f;
        [SerializeField] protected bool automaticFire = false;

        protected bool canFire = true;

        protected PlayerController playerController = null;

        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            ShootProjectile();
        }

        protected virtual void ShootProjectile()
        {
            if ((playerController.InputManager.Shoot > 0 || automaticFire) && canFire)
            {
                if (projectile != null)
                {
                    var instProjectile = Instantiate(projectile, transform.parent, true);
                    instProjectile.transform.localPosition = shootPosition.transform.position;
                    instProjectile.transform.rotation = shootPosition.transform.rotation;

                    instProjectile.GetComponent<PlayerProjectile>().CallShoot(transform.forward);
                    StartCoroutine(FireRateDelay());
                }
            }
        }

        protected virtual IEnumerator FireRateDelay()
        {
            canFire = false;
            yield return new WaitForSeconds(fireRate);
            canFire = true;
        }
    }

}
