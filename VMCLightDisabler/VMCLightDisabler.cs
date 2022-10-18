using BS_Utils.Utilities;
using IPA;
using UnityEngine;

namespace VMCLightDisabler
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class VMCLightDisabler
    {
        public static IPA.Logging.Logger Logger { get; private set; }

        [Init]
        public VMCLightDisabler(IPA.Logging.Logger logger)
        {
            VMCLightDisabler.Logger = logger;
        }

        [OnStart]
        public void Start()
        {
            BSEvents.gameSceneLoaded += this.OnGameSceneLoaded;
            BSEvents.menuSceneLoaded += this.OnMenuSceneLoaded;
        }

        private void OnMenuSceneLoaded()
        {
            foreach (var light in GameObject.FindObjectsOfType<Light>())
            {
                if (light.name == "VMCLight")
                {
                    Logger.Info("Disabling VMCLight on Layer 1");
                    light.cullingMask &= ~(1 << 0);
                }
            }
        }

        private void OnGameSceneLoaded()
        {
            foreach (var light in GameObject.FindObjectsOfType<Light>())
            {
                if (light.name == "VMCLight")
                {
                    Logger.Info("Disabling VMCLight on Layer 1");
                    light.cullingMask &= ~(1 << 0);
                }
            }
        }
    }
}
