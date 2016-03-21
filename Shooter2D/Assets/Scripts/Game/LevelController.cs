using Assets.Scripts.Asteroid;
using Assets.Scripts.Models;
using Assets.Scripts.Util;
using UnityEngine;
using Assets.Scripts.Enemy;

namespace Assets.Scripts.Game
{
    public class LevelController : MonoBehaviour, IAddPoints, IRegisterDeath
    {
        public DataController dataController;
        public AsteroidController asteroidController;
        public BossController bossController;

        private Level _currentLevel;
        private int _numberOfAsteroidsSpawnedThisLevel;
        private IRegisterDeath _registerDeath;

        void Start()
        {
            InitializeControllers();
        }

        void Update()
        {
            if (dataController.LevelState == LevelState.AfterAsteroids)
            {
                if (_numberOfAsteroidsSpawnedThisLevel == dataController.AsteroidsDestroyedThisLevel)
                {
                    if (_currentLevel.Boss != null)
                    {
                        bossController.CreateBoss(_currentLevel.Boss);
                    }
                    else
                    {
                        Killed("Boss");
                    }
                }
            }
        }

        public void SetRegisterDeath(IRegisterDeath registerDeath)
        {
            _registerDeath = registerDeath;
            asteroidController.SetRegisterDeath(this);
            bossController.SetRegisterDeath(this);
        }

        public void AddPoints(int points)
        {
            dataController.TotalScore += points;
        }

        public void StartLevel(Level nextLevel)
        {
            _currentLevel = nextLevel;
            dataController.AsteroidsDestroyedThisLevel = 0;
            _numberOfAsteroidsSpawnedThisLevel = 0;
            asteroidController.StartLevel(nextLevel);
        }

        private void InitializeControllers()
        {
            asteroidController.SetLevelController(this);
            bossController.SetLevelController(this);
        }

        public void SpawnAsteroidsStarted()
        {
            dataController.LevelState = LevelState.DuringAsteroids;
        }

        public void SpawnAsteroidsFinished()
        {
            dataController.LevelState = LevelState.AfterAsteroids;
        }

        public void SpawnedAsteroid()
        {
            _numberOfAsteroidsSpawnedThisLevel++;
        }

        public void SpawnBossStarted()
        {
            dataController.LevelState = LevelState.DuringBoss;
        }

        public void Killed(string tag)
        {
            switch (tag)
            {
                case "Asteroid":
                    _registerDeath.Killed(tag);
                    break;
                case "Boss":
                    dataController.LevelState = LevelState.LevelComplete;
                    _registerDeath.Killed(tag);
                    break;
            }
        }

        public void DestroyedOnImpact(string tag)
        {
            _registerDeath.DestroyedOnImpact(tag);
        }
    }
}
