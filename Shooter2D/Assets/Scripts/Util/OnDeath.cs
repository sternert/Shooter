using UnityEngine;

namespace Assets.Scripts.Util
{
    public class OnDeath: MonoBehaviour
    {
        public GameObject explosion;

        private IRegisterDeath _registerDeath;

        public void Kill()
        {
            var hasPoints = GetComponent<HasPoints>();
            if(hasPoints != null)
            {
                hasPoints.CollectPoints();
            }
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            if (_registerDeath != null) 
            {
                _registerDeath.Killed(gameObject.tag);
            }

            Destroy(gameObject);
        }

        public void RegisterDeathController(IRegisterDeath registerDeath)
        {
            _registerDeath = registerDeath;
        }
    }
}