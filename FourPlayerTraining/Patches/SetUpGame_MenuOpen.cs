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
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var instruction = instructions.Last((x) => x.opcode == OpCodes.Br_S);

            instruction.opcode = OpCodes.Nop;
            instruction.operand = null;

            return instructions;
        }
    }
}
