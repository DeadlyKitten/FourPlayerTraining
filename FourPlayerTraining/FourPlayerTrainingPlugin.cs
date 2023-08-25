using BepInEx;
using HarmonyLib;

namespace FourPlayerTraining
{
    [BepInPlugin("com.steven.nasb.4ptraining", "Four Player Training", "1.1.0")]
    public class FourPlayerTrainingPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            var harmony = new Harmony("com.steven.nasb.4ptraining");
            harmony.PatchAll();
        }
    }
}
