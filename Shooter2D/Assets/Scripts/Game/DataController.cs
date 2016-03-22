using UnityEngine;

namespace Assets.Scripts.Game
{
    public class DataController : MonoBehaviour
    {
        public int AsteroidsDestroyed { get; set; }
        public int AsteroidsDestroyedThisLevel { get; set; }
        public int AsteroidsSurvived { get; set; }
        public int ShotsRemoved { get; set; }
        public int PlayerShotsFired { get; set; }
        public int TotalScore { get; set; }
        public LevelState LevelState { get; set; }
        public UiState UiState { get; set; }
        public PlayerState PlayerState { get; set; }
        
    }

    public enum PlayerState
    {
        InActive,
        Active,
        Dead
    }

    public enum UiState
    {
        OutOfMenu,
        StartMenu,
        RestartMenu,
        NextLevelMenu,
        PlayerWinMenu
    }

    public enum LevelState
    {
        OutOfLevel,
        InLevel,
        AfterAsteroids,
        LevelComplete,
        DuringAsteroids,
        DuringBoss
    }
}