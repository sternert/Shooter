using UnityEngine;

namespace Assets.Scripts.Util
{
    public class HasPoints : MonoBehaviour 
    {
        public int points;
        private IAddPoints _addPointsController;

        public void SetPointsController(IAddPoints addPointsController)
        {
            _addPointsController = addPointsController;
        }

        public void CollectPoints()
        {
            _addPointsController.AddPoints(points);
        }
    }
}