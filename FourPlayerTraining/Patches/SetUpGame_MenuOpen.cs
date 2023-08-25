using HarmonyLib;
using Nick;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace FourPlayerTraining.Patches
{
    [HarmonyPatch(typeof(SetUpGame), "MenuOpen")]
    internal class SetUpGame_MenuOpen
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var instruction = instructions.LastOrDefault((x) => x.opcode == OpCodes.Br);

            if (instruction != null)
            {
                instruction.opcode = OpCodes.Nop;
                instruction.operand = null;
            }

            return instructions;
        }
    }
}
