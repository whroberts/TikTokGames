using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectiles
{
    public class PlayerProjectile : ProjectileBase
    {
        public void CallShoot(Vector3 playerForward)
        {
            Shoot(playerForward);
        }
    }
}
