using BepInEx;
using HarmonyLib;
using UnityEngine;
using Object = UnityEngine.Object;



namespace caca
{
    [BepInPlugin("com.sau6son.cacaPlugin", "caca hehe", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private Harmony _harmony;
        
        private static Plugin Instance;
        
        internal static AudioClip[] newSFX;

        void Awake()
        {
            if ((Object)(object)Instance == (Object)null)
            {
                Instance = this;
            }
            
            // Initialiser Harmony et patcher les méthodes
            _harmony = new Harmony("com.sau6son.cacaPlugin");
            _harmony.PatchAll();
            
            Logger.LogInfo("sau6son.caca is loading.");
            
            string location = ((BaseUnityPlugin)Instance).Info.Location;
            string text = "caca.dll";
            string text2 = location.TrimEnd(text.ToCharArray());
            string text3 = text2 + "caca-bundle";
            AssetBundle val = AssetBundle.LoadFromFile(text3);
            if ((Object)(object)val == (Object)null)
            { 
                Logger.LogError((object)"Failed to load audio assets!"); 
                return;
            }
            
            newSFX = val.LoadAssetWithSubAssets<AudioClip>("assets/caca.mp3");
            if (newSFX == null || newSFX.Length == 0)
            {
                Logger.LogError((object)"Failed to load audio assets! 1");
                return;
            }
            else
            {
                Logger.LogInfo((object)"Loaded audio assets " + newSFX[0].name);
            }
            _harmony.PatchAll(typeof(PatchClass));
            Logger.LogInfo((object) "caca plugin loaded !");

        }
    }
}