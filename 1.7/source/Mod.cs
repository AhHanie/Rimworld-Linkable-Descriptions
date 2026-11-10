using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace Linkable_Descriptions
{
    public class Mod : Verse.Mod
    {
        public Mod(ModContentPack content) : base(content)
        {
            LongEventHandler.QueueLongEvent(Init, "LinkableDescriptions.LoadingLabel", doAsynchronously: true, null);
        }

        private void Init()
        {
            new Harmony("sk.linkabledescriptions").PatchAll();
        }
    }
}
