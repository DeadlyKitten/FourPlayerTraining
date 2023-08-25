using HarmonyLib;
using Nick;

namespace FourPlayerTraining.Patches
{
    [HarmonyPatch(typeof(SetUpGame), "ValidStatesForMode")]
    internal class SetUpGame_ValidStatesForMode
    {
        private static void Postfix(CharacterSelectScreen.Mode mode, ref PlayerSlotContainer.State[] __result)
        {
            if (mode == CharacterSelectScreen.Mode.Training)
            {
                __result = new PlayerSlotContainer.State[3]
                {
                    PlayerSlotContainer.State.NoneSlot,
                    PlayerSlotContainer.State.PlayerSlot,
                    PlayerSlotContainer.State.CPUSlot
                };
            }
        }
    }
}
