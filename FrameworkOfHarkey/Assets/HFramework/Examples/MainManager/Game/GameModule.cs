using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameModule : HFramework.MainManager
    {
        protected void LoadGame()
        {
            SceneManager.LoadScene("Game");
        }

        protected override void LaunchInDevelopingMode()
        {
            Debug.Log("Developing Mode");
        }

        protected override void LaunchInProductionMode()
        {
            Debug.Log("Production Mode");
        }

        protected override void LaunchInTestMode()
        {
            Debug.Log("Test Mode");
        }
    }
}
