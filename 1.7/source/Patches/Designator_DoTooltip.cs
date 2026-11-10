using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Linkable_Descriptions.Patches
{
    [HarmonyPatch(typeof(Designator), "DoTooltip", MethodType.Getter)]
    public static class Designator_DoTooltip
    {
        [HarmonyPostfix]
        public static void Postfix(Designator __instance, ref bool __result)
        {
            if (__result)
            {
                return;
            }

            if (!(__instance is Designator_Build designator))
            {
                return;
            }

            MainButtonDef openTab = Find.MainTabsRoot.OpenTab;
            if (openTab != null && openTab != MainButtonDefOf.Inspect)
            {
                return;
            }

            if (!(Find.Selector.SingleSelectedObject is Building building))
            {
                return;
            }

            CompProperties_AffectedByFacilities props = building.def.GetCompProperties<CompProperties_AffectedByFacilities>();
            List<ThingDef> facilities = props?.linkableFacilities;
            if (facilities == null)
            {
                return;
            }

            BuildableDef placingDef = designator.PlacingDef;
            for (int i = 0; i < facilities.Count; i++)
            {
                if (facilities[i] == placingDef)
                {
                    __result = true;
                    return;
                }
            }
        }
    }
}
