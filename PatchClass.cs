using HarmonyLib;
using System.IO;
using BepInEx;
using UnityEngine;
using BepInEx.Logging;
using Logger = BepInEx.Logging.Logger;

namespace caca
{
    [HarmonyPatch(typeof(HoarderBugAI))]
    public class PatchClass
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void hoarderBugPatch(HoarderBugAI __instance ,ref AudioClip[] ___chitterSFX )
        {
            AudioClip[] newChitterSfx = Plugin.newSFX;
            
            if (__instance == null)
            {
                Logger.CreateLogSource("caca").LogError("Instance is null!");
                return;
            }
            
            
            if (newChitterSfx == null || newChitterSfx.Length == 0)
            {
                Logger.CreateLogSource("caca").LogError("Failed to load audio assets! 2");
                return;
            }
            
            
            if (___chitterSFX == null)
            {
                Logger.CreateLogSource("caca").LogError("___chitterSFX is null!");
                return;
            }
            
            ___chitterSFX = newChitterSfx;
        }
    } 
}
