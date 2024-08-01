using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IDamageable
    {
        void TakeDamage(float damage);
        void DealDamage(float damage);
    }

}
