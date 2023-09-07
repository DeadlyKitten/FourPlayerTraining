using HarmonyLib;
using Nick;
using System.Reflection;
using UnityEngine;

namespace FourPlayerTraining.Patches
{
    [HarmonyPatch(typeof(SetCharacterSelectMode), "SetModeObjects")]
    internal class SetCharacterSelectMode_SetModeObjects
    {
        private const string ACTIVATE_METHOD_NAME = "Activate";
        private const BindingFlags BINDING_FLAGS = BindingFlags.NonPublic | BindingFlags.Instance;
        private static readonly MethodInfo method = typeof(SetCharacterSelectMode).GetMethod(ACTIVATE_METHOD_NAME, BINDING_FLAGS);

        private static bool Prefix(CharacterSelectScreen.Mode currentMode, ref GameObject[] ___localBattleObjects)
        {
            if (currentMode == CharacterSelectScreen.Mode.Training)
            {
                for (int i = 0; i < ___localBattleObjects.Length; i++)
                {
                    var type = typeof(SetCharacterSelectMode);
                    InvokeMethod(___localBattleObjects[i], true);
                }
                return false;
            }
            return true;
        }
        
        private static void InvokeMethod(params object[] args) => method.Invoke(null, args);
    }
}
