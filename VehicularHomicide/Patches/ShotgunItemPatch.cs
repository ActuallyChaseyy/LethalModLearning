using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicularHomicide.Patches
{
    [HarmonyPatch(typeof(ShotgunItem))]
    internal class ShotgunItemPatch
    {

        [HarmonyPatch("ShootGun")]
        [HarmonyPostfix]
        static void infinteShotgunAmmoPatch(ref int ___shellsLoaded)
        {
            ___shellsLoaded = 999;
        }

    }
}
