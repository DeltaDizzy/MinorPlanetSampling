using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ProbeCometScience
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class PotatoPatcher : MonoBehaviour
    {
        void Start()
        {
            Harmony harmony = new Harmony("probecometscience");
            harmony.PatchAll();
        }
    }
    
    [HarmonyPatch(typeof(ScienceUtil), nameof(ScienceUtil.RequiredUsageExternalAvailable))]
    class UsageMaskPatch
    {
        static bool Prefix(ref bool __result)
        {
            __result = true;
            return false;
        }
    }
}
