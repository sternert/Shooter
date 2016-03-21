using UnityEngine;
using System.Collections.Generic;

public class DestroyOnImpact: MonoBehaviour 
{
    public List<string> tagsToBeDestroyedBy;
    public GameObject explosion;

    private IRegisterDeath _registerDeath;

    void OnTriggerEnter2D (Collider2D other)
    {
        if(tagsToBeDestroyedBy.Contains(other.tag))
        {
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            if (_registerDeath != null)
            {
                _registerDeath.DestroyedOnImpact(gameObject.tag);
            }
            Destroy(gameObject);
        }
    }

    public void RegisterDeathController(IRegisterDeath registerDeath)
    {
        _registerDeath = registerDeath;
    }
}