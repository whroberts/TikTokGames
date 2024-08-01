using System.Collections;
using System.Collections.Generic;
using Projectiles;
using UnityEngine;

namespace Behavior
{
    public class DuplicateBehavior : BehaviorBase
    {
        protected override void ShootProjectile()
        {
            if (automaticFire && canFire)
            {
                if (projectile != null)
                {
                    var instProjectile = Instantiate(projectile, transform.parent.transform.parent, true);
                    instProjectile.transform.localPosition = shootPosition.transform.position;
                    instProjectile.transform.rotation = shootPosition.transform.rotation;

                    instProjectile.GetComponent<PlayerProjectile>().CallShoot(transform.forward);
                    StartCoroutine(FireRateDelay());
                }
            }
        }
    }

}
