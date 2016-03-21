using System.Collections.Generic;
using Assets.Scripts.Models;
using UnityEngine;
using SimpleJSON;

namespace Assets.Scripts.Util
{
    public static class LevelParser
    {
        public static Level GetLevel (TextAsset file)
        {
            return CreateLevel(file);
        }

        private static Level CreateLevel (TextAsset file)
        {
            var text = file.text;

            var parsed = JSON.Parse (text);

            var levelName = parsed ["name"];
            var newLevel = new Level () {
                LevelName = levelName,
                Waves = new List<Wave> ()
            };

            // Parse asteroids to Map
            var asteroids = parsed ["asteroids"];
            var asteroidMap = new Dictionary<string, Models.Asteroid> ();
            for (var i = 0; i < asteroids.Count; i++) {
                var asteroid = asteroids [i];
                asteroidMap.Add (
                    asteroid ["asteroidType"],
                    new Models.Asteroid {
                        Health = asteroid ["asteroidHealth"].AsInt,
                        Type = asteroid ["asteroidType"],
                        Speed = asteroid ["asteroidSpeed"].AsFloat
                    });
            }

            // Parse waves
            var waves = parsed ["waves"];
            for (int i = 0; i < waves.Count; i++) {
                var wave = waves [i];
                newLevel.Waves.Add (
                    new Wave {
                        AsteroidDelay = wave ["waveAsteroidDelay"].AsFloat,
                        NumberOfAsteroids = wave ["waveAsteroidNumber"].AsInt,
                        SpeedMultiplier = wave ["waveSpeedMultiplier"].AsFloat,
                        WaveNumber = wave ["waveNumber"].AsInt,
                        WaveAsteroids = GetWaveAsteroids (wave ["waveAsteroids"], asteroidMap)
                    });
            }
			
            // Parse boss
            var bossJson = parsed ["boss"];
            if (bossJson != null)
            {
                var boss = GetBoss(bossJson);
                newLevel.Boss = boss;
            }
            return newLevel;
        }

        private static Boss GetBoss (JSONNode bossJson)
        {
            var boss = new Boss () {
                Name = bossJson ["bossName"],
                Visual = bossJson ["bossVisualType"],
                AI = GetBossAI (bossJson ["bossAI"])
            };

            return boss;
        }

        private static BossAI GetBossAI (JSONNode bossAI)
        {
            return new BossAI () {
                MovementType = GetMovementType (bossAI ["type"]),
                AimTime = bossAI ["aimTime"].AsFloat,
                MoveSpeed = bossAI ["moveSpeed"].AsFloat
            };
        }

        private static MovementType GetMovementType (JSONNode jSONNode)
        {
            switch (jSONNode) {
                case "MoveTowardsShootWhenAimed":
                    return MovementType.MoveTowardsShootWhenAimed;
                default:
                    return MovementType.NotMoving;
            }
        }

        private static IList<WaveAsteroid> GetWaveAsteroids (JSONNode waveAsteroids, Dictionary<string, Models.Asteroid> asteroidMap)
        {
            var waveAsteroidList = new List<WaveAsteroid> ();

            for (int i = 0; i < waveAsteroids.Count; i++) {
                var waveAsteroid = waveAsteroids [i];
                waveAsteroidList.Add (
                    new WaveAsteroid {
                        Asteroid = asteroidMap [waveAsteroid ["asteroidType"]],
                        ProbabilityWeight = waveAsteroid ["asteroidProbabilityWeight"].AsFloat
                    }
                    );
            }
            return waveAsteroidList;
        }
    }
}
