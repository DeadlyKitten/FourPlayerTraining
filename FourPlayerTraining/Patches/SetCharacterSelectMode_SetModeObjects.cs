using HarmonyLib;
using Nick;
using System;
using System.Reflection;
using UnityEngine;

namespace FourPlayerTraining.Patches
{
    [HarmonyPatch(typeof(SetCharacterSelectMode), "SetModeObjects")]
    internal class SetCharacterSelectMode_SetModeObjects
    {
        static bool Prefix(CharacterSelectScreen.Mode currentMode, ref GameObject[] ___localBattleObjects)
        {
            if (currentMode == CharacterSelectScreen.Mode.Training)
            {
                for (int i = 0; i < ___localBattleObjects.Length; i++)
                {
                    var type = typeof(SetCharacterSelectMode);
                    InvokeMethod(type, "Activate", ___localBattleObjects[i], true);
                }
                return false;
            }
            return true;
        }

        static MethodInfo method;
        static void InvokeMethod(Type type, string methodName, params object[] args)
        {
            method ??= type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);
            method.Invoke(null, args);
        }
    }
}
