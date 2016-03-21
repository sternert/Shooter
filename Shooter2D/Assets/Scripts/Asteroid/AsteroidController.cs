using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Damages;
using Assets.Scripts.Game;
using Assets.Scripts.Models;
using Assets.Scripts.Util;
using UnityEngine;

namespace Assets.Scripts.Asteroid
{
    public class AsteroidController : MonoBehaviour
    {
        public List<GameObject> brownBigAsteroids;
        public List<GameObject> brownMedAsteroids;
        public List<GameObject> brownSmallAsteroids;
        public List<GameObject> brownTinyAsteroids;
        public Limits limits;

        private LevelController _levelController;
        private IRegisterDeath _registerDeath;

        public void StartLevel (Level level)
        {
            StartCoroutine (SpawnMultipleAsteroids (level));
        }

        public void SetLevelController (LevelController levelController)
        {
            _levelController = levelController;
        }

        public void SetRegisterDeath(IRegisterDeath registerDeath)
        {
            _registerDeath = registerDeath;
        }

        private IEnumerator SpawnMultipleAsteroids (Level level)
        {
            _levelController.SpawnAsteroidsStarted();
            foreach (var wave in level.Waves) {
                for (int i = 0; i < wave.NumberOfAsteroids; i++)
                {
                    yield return new WaitForSeconds(wave.AsteroidDelay);
                    var asteroidType = Random.Range (0, wave.WaveAsteroids.Count); // TODO this should be a weighted random
                    SpawnSingleAsteroid (wave.WaveAsteroids [asteroidType].Asteroid, wave.SpeedMultiplier);
                    _levelController.SpawnedAsteroid();
                }
            }
            _levelController.SpawnAsteroidsFinished();
        }

        private void SpawnSingleAsteroid (Models.Asteroid asteroid, float speedMultiplier)
        {
            var currentLimits = limits.GetLimits ();
            Vector3 spawnPosition = new Vector3 (Random.Range (currentLimits.XMin, currentLimits.XMax), Random.Range (currentLimits.YMin, currentLimits.YMax), 0);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject asteroidGameObject = GetAsteroidGameObject (asteroid.Type);

            var instantiatedAsteroid = Instantiate (asteroidGameObject, spawnPosition, spawnRotation) as GameObject;

            var onDeathComponent = instantiatedAsteroid.GetComponent<OnDeath> ();
            var destroyOnImpactComponent = instantiatedAsteroid.GetComponent<DestroyOnImpact> ();
            var hasHealthComponent = instantiatedAsteroid.GetComponent<HasHealth> ();
            var asteroidControlComponent = instantiatedAsteroid.GetComponent<AsteroidControl> ();
            var hasPointsComponent = instantiatedAsteroid.GetComponent<HasPoints>();

            hasPointsComponent.SetPointsController(_levelController); // So that levelcontroller gets points from asteroid
            asteroidControlComponent.SetSpeed (asteroid.Speed * speedMultiplier);
            hasHealthComponent.SetHealth (asteroid.Health);
            onDeathComponent.RegisterDeathController(_registerDeath);
            destroyOnImpactComponent.RegisterDeathController(_registerDeath);
        }

        private GameObject GetAsteroidGameObject (string type)
        {
            switch (type) {
                case "big":
                    return brownBigAsteroids [Random.Range (0, brownBigAsteroids.Count - 1)];
                case "med":
                    return brownMedAsteroids [Random.Range (0, brownMedAsteroids.Count - 1)];
                case "small":
                    return brownSmallAsteroids [Random.Range (0, brownSmallAsteroids.Count - 1)];
                case "tiny":
                    return brownTinyAsteroids [Random.Range (0, brownTinyAsteroids.Count - 1)];
            }
            return null;
        }
    }
}