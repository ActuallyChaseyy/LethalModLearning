using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLib;

namespace VehicularHomicide.Patches
{
    [HarmonyPatch(typeof(Terminal), "Start", MethodType.Normal)]
    internal class TerminalPatch
    {
        internal static void Postfix(Terminal __instance)
        {
            Commands.RegisterCommand("givecred", "Fucjin krill youreseklf\n", "cheatCredMomen", __instance);
        }
    }

    [HarmonyPatch(typeof(Terminal), "RunTerminalEvents", MethodType.Normal)]
    internal class TerminalRunEventPatch
    {
        internal static void Postfix(Terminal __instance, TerminalNode node, ref int __groupCredits)
        {
            if (string.IsNullOrWhiteSpace(node.terminalEvent)) { return; }

            switch (node.terminalEvent)
            {
                case "cheatCredMomen":
                    {
                        __groupCredits += 1000;
                        break;
                    }
            }
        }
    }
}
