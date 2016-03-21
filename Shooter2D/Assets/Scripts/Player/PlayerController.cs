using Assets.Scripts.Game;
using Assets.Scripts.Util;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour, IRegisterDeath
    {
        public DataController dataController;
        public GameObject playerBody;
        public PlayerGunController gunController;

        private PlayerMovement _playerMovement;
        private OnDeath _onDeath;
        private IRegisterDeath _registerDeath;

        void Start()
        {
            _playerMovement = playerBody.GetComponent<PlayerMovement>();
            _playerMovement.SetDataController(dataController);
            _onDeath = playerBody.GetComponentInChildren<OnDeath>();
            _onDeath.RegisterDeathController(this);
            gunController.SetDataController(dataController);
            gunController.SetPlayerController(this);
        }

        public void StartGame ()
        {
            dataController.PlayerState = PlayerState.Active;
        }

        public void ShotsFired (int newShots)
        {
            dataController.PlayerShotsFired += newShots;
        }

        public void Killed(string tag)
        {
            dataController.PlayerState = PlayerState.Dead;
            _registerDeath.Killed(tag);
        }

        public void DestroyedOnImpact(string tag)
        {
        }

        public void SetRegisterDeath(IRegisterDeath registerDeath)
        {
            _registerDeath = registerDeath;
        }
    }
}