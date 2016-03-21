using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class PlayerGunController : MonoBehaviour
    {
        public List<GunControl> gunControls;

        private PlayerController _playerController;
        private DataController _dataController;

        public void SetPlayerController(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void SetDataController(DataController dataController)
        {
            _dataController = dataController;
        }

        void Update ()
        {
            if (_dataController.PlayerState == PlayerState.Active && Input.GetButton ("Fire1")) {
                var shotsFired = 0;
                foreach (var gunControl in gunControls) {
                    if (gunControl.CanShoot ()) {
                        gunControl.Shoot ();
                        shotsFired++;
                    }
                }
                if (shotsFired > 0) {
                    _playerController.ShotsFired (shotsFired);
                }
            }
        }
    }
}