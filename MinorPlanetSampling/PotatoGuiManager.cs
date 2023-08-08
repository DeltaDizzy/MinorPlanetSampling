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
                //Debug.Log($"SampleEVAEvent is {comet.Events["TakeSampleEVAEvent"].externalToEVAOnly}");
                comet.Events["TakeSampleEVAEvent"].guiActive = true;
                //Debug.Log($"SampleEVAEvent is {comet.Events["TakeSampleEVAEvent"].guiActive}");
                comet.Events["TakeSampleEVAEvent"].guiActiveUnfocused = true;
                //Debug.Log($"SampleEVAEvent is {comet.Events["TakeSampleEVAEvent"].guiActiveUnfocused}");
                comet.Events["TakeSampleEVAEvent"].active = true;
            }
        }

        void OnDestroy()
        {
            GameEvents.onVesselGoOffRails.Remove(OnVesselUnpacked);
        }
    }
}
