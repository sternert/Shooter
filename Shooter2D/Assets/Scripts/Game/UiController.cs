using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class UiController : MonoBehaviour
    {
        public DataController dataController;
        public GameObject restartMenu;
        public GameObject startMenu;
        public GameObject nextLevelMenu;
        public GameObject playerWinMenu;
        public Text shotsFiredCounter;
        public Text asteroidsDestroyedCounter;
        public Text asteroidsRemovedCounter;
        public Text shotsRemovedCounter;
        public Text scoreCounter;

        void Update()
        {
            switch (dataController.UiState)
            {
                case UiState.OutOfMenu:
                    restartMenu.SetActive(false);
                    startMenu.SetActive(false);
                    nextLevelMenu.SetActive(false);
                    playerWinMenu.SetActive(false);
                    break;
                case UiState.StartMenu:
                    restartMenu.SetActive(false);
                    startMenu.SetActive(true);
                    nextLevelMenu.SetActive(false);
                    playerWinMenu.SetActive(false);
                    break;
                case UiState.RestartMenu:
                    restartMenu.SetActive(true);
                    startMenu.SetActive(false);
                    nextLevelMenu.SetActive(false);
                    playerWinMenu.SetActive(false);
                    break;
                case UiState.NextLevelMenu:
                    restartMenu.SetActive(false);
                    startMenu.SetActive(false);
                    nextLevelMenu.SetActive(true);
                    playerWinMenu.SetActive(false);
                    break;
                case UiState.PlayerWinMenu:
                    restartMenu.SetActive(false);
                    startMenu.SetActive(false);
                    nextLevelMenu.SetActive(false);
                    playerWinMenu.SetActive(true);
                    break;
            }
            UpdateCounters ();
        }

        private void UpdateCounters ()
        {
            shotsFiredCounter.text = dataController.PlayerShotsFired.ToString();
            asteroidsDestroyedCounter.text = dataController.AsteroidsDestroyed.ToString();
            asteroidsRemovedCounter.text = dataController.AsteroidsSurvived.ToString();
            shotsRemovedCounter.text = dataController.ShotsRemoved.ToString();
            scoreCounter.text = "Score: " + dataController.TotalScore + "pts";
        }
    }
}