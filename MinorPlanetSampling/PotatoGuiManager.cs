using UnityEngine;

namespace ProbeCometScience
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class PotatoGuiManager : MonoBehaviour
    {
        void Start()
        {
            GameEvents.onVesselGoOffRails.Add(OnVesselUnpacked);
        }

        void OnVesselUnpacked(Vessel vessel)
        {
            //Debug.Log("handler fired!");
            ModuleComet comet = vessel.parts[0].FindModuleImplementing<ModuleComet>();
            if (comet != null)
            {
                comet.Events["TakeSampleEVAEvent"].externalToEVAOnly = false;
                comet.Events["TakeSampleEVAEvent"].guiActive = true;
                comet.Events["TakeSampleEVAEvent"].guiActiveUnfocused = true;
                comet.Events["TakeSampleEVAEvent"].active = true;
            }
            ModuleAsteroid asteroid = vessel.parts[0].FindModuleImplementing<ModuleAsteroid>();
            if (asteroid != null)
            {
                //Debug.Log("asteroid found!");
                asteroid.Events["TakeSampleEVAEvent"].externalToEVAOnly = false;
                asteroid.Events["TakeSampleEVAEvent"].guiActive = true;
                asteroid.Events["TakeSampleEVAEvent"].guiActiveUnfocused = true;
                asteroid.Events["TakeSampleEVAEvent"].active = true;
            }
        }

        void OnDestroy()
        {
            GameEvents.onVesselGoOffRails.Remove(OnVesselUnpacked);
        }
    }
}
