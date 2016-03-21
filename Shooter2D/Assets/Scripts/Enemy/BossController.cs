using System.Collections;
using Assets.Scripts.Game;
using Assets.Scripts.Models;
using Assets.Scripts.Util;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class BossController : MonoBehaviour
    {
        public GameObject enemyShip;
        public float bossWaitTime;

        private LevelController _levelController;
        private IRegisterDeath _registerDeath;

        public void CreateBoss (Boss boss)
        {
            _levelController.SpawnBossStarted();
            StartCoroutine(SpawnBoss(boss));
        }

        public void SetRegisterDeath(IRegisterDeath registerDeath)
        {
            _registerDeath = registerDeath;
        }

        public void SetLevelController(LevelController levelController)
        {
            _levelController = levelController;
        }

        private IEnumerator SpawnBoss(Boss boss)
        {
            yield return new WaitForSeconds(bossWaitTime);
            var bossGameObject = GetBossVisual(boss.Visual);
            var bossInstance = Instantiate(bossGameObject, new Vector3(0, 4), Quaternion.identity) as GameObject;
            var bossMovement = bossInstance.GetComponent<BossMovement>();
            bossMovement.SetMovement(boss.AI.MovementType, boss.AI.MoveSpeed, boss.AI.AimTime);
            var onDeath = bossInstance.GetComponent<OnDeath>();
            onDeath.RegisterDeathController(_registerDeath);
        }

        private GameObject GetBossVisual (string visualType)
        {
            switch (visualType) {
                case "EnemyShip":
                    return enemyShip;
            }
            return null;
        }
    }
}
