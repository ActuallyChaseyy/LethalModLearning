using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VehicularHomicide.Patches;

namespace VehicularHomicide
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class ModBaseReal : BaseUnityPlugin
    {
        private const string modGUID = "net.chaseyy.vehicularhomicide";
        private const string modName = "Vehicular Homicide";
        private const string modVersion = "0.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static ModBaseReal Instance;

        internal ManualLogSource mls;

        private static Terminal terminalInstance;

        public static void RefreshAll()
        {
            if (terminalInstance == null)
            {
                return;
            }
        }
        void Awake()
        {
            if (Instance == null) { Instance = this; }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("Vehicular Homicide Loaded");

            harmony.PatchAll(typeof(ModBaseReal));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
            harmony.PatchAll(typeof(TerminalPatch));
            harmony.PatchAll(typeof(ShotgunItemPatch));



        }

        void FixedUpdate()
        {

        }

    }
}
