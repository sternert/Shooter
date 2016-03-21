using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Damages
{
    public class DamageOnImpact : MonoBehaviour 
    {
        public List<string> tagsToBeDamagedBy;

        void OnTriggerEnter2D(Collider2D other)
        {
            if(tagsToBeDamagedBy.Contains(other.tag))
            {
                var hasDamage = other.gameObject.GetComponent<HasDamage>() as HasDamage;
                var hasHealth = GetComponent<HasHealth>() as HasHealth;
                if (hasDamage != null && hasHealth != null)
                {
                    hasHealth.Damage(hasDamage.damage);
                }
            }
        }
    }
}