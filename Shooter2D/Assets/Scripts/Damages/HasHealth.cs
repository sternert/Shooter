using Assets.Scripts.Util;
using UnityEngine;

namespace Assets.Scripts.Damages
{
    public class HasHealth : MonoBehaviour
    {
        public float health;
        public OnDeath onDeath;

        public float Damage(float damage)
        {
            health -= damage;
            if (health <= 0.0)
            {
                if(onDeath != null)
                {
                    onDeath.Kill();
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            return health;
        }

        public void SetHealth(float newHealth) {
            health = newHealth;
        }
    }
}