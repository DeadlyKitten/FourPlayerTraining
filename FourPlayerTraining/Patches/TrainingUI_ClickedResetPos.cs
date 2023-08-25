using HarmonyLib;
using Nick;
using System.Collections.Generic;

namespace FourPlayerTraining.Patches
{
    [HarmonyPatch(typeof(TrainingUI), "ClickedResetPos")]
    internal class TrainingUI_ClickedResetPos
    {
        private static bool Prefix(ref GameInstance ___context)
        {
            var agents = new List<(int index,GameAgent agent)>();

            for (int i = 0; i < 4; i++)
            {
                if (___context.GetAgentFromPlayerIndex(i, out var agent))
                {
                    agents.Add((i,agent));
                }
            }

            foreach (var (index, agent) in agents)
            {
                var spawnPoint = ___context.stage.GetFFASpawnPoint(agents.Count, index);
                if(agent.TryGetMovement(out var movement))
                {
                    movement.TeleportTo(spawnPoint);
                }
            }

            return false;
        }
    }
}
