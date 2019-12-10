using UnityEngine;

namespace HFramework
{
    public enum EnvironmentMode
    {
        Developing,
        Test,
        Production
    }

    public abstract class MainManager : MonoBehaviour
    {
        public EnvironmentMode enviromentMode;

        private static EnvironmentMode _shareMode;
        private static bool _modeSetted = false;

        // Start is called before the first frame update
        void Start()
        {
            if (!_modeSetted)
            {
                _shareMode = enviromentMode;
                _modeSetted = true;
            }

            switch (_shareMode)
            {
                case EnvironmentMode.Developing:
                    LaunchInDevelopingMode();
                    break;
                case EnvironmentMode.Production:
                    LaunchInProductionMode();
                    break;
                case EnvironmentMode.Test:
                    LaunchInTestMode();
                    break;
            }
        }

        protected abstract void LaunchInDevelopingMode();
        protected abstract void LaunchInProductionMode();
        protected abstract void LaunchInTestMode();
    }
}
