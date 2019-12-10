using UnityEngine;
using UnityEngine.SceneManagement;

namespace Home
{
    public class HomeModule : HFramework.MainManager
    {
        protected override void LaunchInDevelopingMode()
        {
        }

        protected override void LaunchInProductionMode()
        {
            SceneManager.LoadScene("Game");
        }

        protected override void LaunchInTestMode()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
