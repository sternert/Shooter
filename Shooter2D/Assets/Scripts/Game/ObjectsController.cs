using UnityEngine;

namespace Assets.Scripts.Game
{
    public class ObjectsController : MonoBehaviour, IRegisterDeath
    {
        public DataController dataController;

        public void DestroyedByBoundary(string tag)
        {
            switch (tag)
            {
                case "Shot":
                    dataController.ShotsRemoved++;
                    break;
                case "Asteroid":
                    dataController.AsteroidsSurvived++;
                    dataController.AsteroidsDestroyedThisLevel++;
                    break;
            }
        }

        public void DestroyedOnImpact(string tag)
        {
            switch (tag)
            {
                case "Asteroid":
                    dataController.AsteroidsDestroyed++;
                    dataController.AsteroidsDestroyedThisLevel++;
                    break;
            }
        }

        public void Killed(string tag)
        {
            switch (tag)
            {
                case "Asteroid":
                    dataController.AsteroidsDestroyed++;
                    dataController.AsteroidsDestroyedThisLevel++;
                    break;
                case "Boss":
                    dataController.AsteroidsDestroyed++;
                    break;
            }
        }
    }
}
