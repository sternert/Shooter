using System.Collections.Generic;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Destroys
{
    public class DestroyOnExit : MonoBehaviour
    {
        public ObjectsController objectsController;
        public List<string> tagsToBeDestroyed;

        private int _removed;

        void OnTriggerExit2D(Collider2D other)
        {
            if(tagsToBeDestroyed.Contains(other.tag))
            {
                if (objectsController)
                {
                    objectsController.DestroyedByBoundary(other.tag);
                }
                _removed++;
                Destroy(other.gameObject);
            }
        }

        public int GetRemoved() {
            return _removed;
        }
    }
}