using System.Collections;
using Assets.Scripts.Player;
using Assets.Scripts.Util;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game
{
    public class MainController : MonoBehaviour, IRegisterDeath
    {
        public UiController uiController;
        public PlayerController playerController;
        public LevelController levelController;
        public ObjectsController objectsController;
        public DataController dataController;
        public LevelsList levelList;

        private TextAsset _nextLevel;

        void Start ()
        { 
            InitializeControllers ();
            _nextLevel = levelList.GetNextLevel();

            dataController.UiState = UiState.StartMenu;
        }

        public void StartLevel()
        {
            var parsedLevel = LevelParser.GetLevel(_nextLevel);
            Debug.Log("Level: " + parsedLevel.LevelName);

            levelController.StartLevel(parsedLevel);
            playerController.StartGame();
            dataController.UiState = UiState.OutOfMenu;
        }

        public void RestartScene ()
        {
            Statics.Restarted = true;
            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
        }

        public void Killed(string tag)
        {
            switch (tag)
            {
                case "Player":
                    StartCoroutine (ShowRestartOption ());
                    break;
                case "Boss":
                    StartCoroutine (ShowNextLevelOption());
                    break;
            }
            objectsController.Killed(tag);
        }

        public void DestroyedOnImpact(string tag)
        {
            objectsController.DestroyedOnImpact(tag);
        }

        private IEnumerator ShowRestartOption()
        {
            yield return new WaitForSeconds(2);
            dataController.UiState = UiState.RestartMenu;
        }

        private IEnumerator ShowNextLevelOption()
        {
            yield return new WaitForSeconds(2);
            _nextLevel = levelList.GetNextLevel();
            if (_nextLevel == null)
            {
                dataController.UiState = UiState.PlayerWinMenu;
                yield break;
            }

            dataController.UiState = UiState.NextLevelMenu;
            dataController.PlayerState = PlayerState.InActive;
        }

        private void InitializeControllers()
        {
            if (uiController == null)
            {
                Debug.Log("UI Controller missing from MainController");
                return;
            }
            playerController.SetRegisterDeath(this);
            levelController.SetRegisterDeath(this);
        }
    }
}