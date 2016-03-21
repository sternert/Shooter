using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private MoveBody _moveBody;
        private DataController _dataController;

        void Start()
        {
            _moveBody = GetComponent<MoveBody>();
        }

        public void SetDataController(DataController dataController)
        {
            _dataController = dataController;
        }

        void FixedUpdate()
        {
            if (_dataController.PlayerState == PlayerState.Active)
            {
                var moveHorizontal = Input.GetAxis("Horizontal");
                var moveVertical = Input.GetAxis("Vertical");

                var direction = new Vector2(moveHorizontal, moveVertical);

                if (_moveBody != null)
                {
                    _moveBody.Move(direction);
                }
                else
                {
                    Debug.Log("No MoveBody script defined");
                }
            }
            else
            {
                _moveBody.Move(Vector2.zero);
            }
        }
    }
}
