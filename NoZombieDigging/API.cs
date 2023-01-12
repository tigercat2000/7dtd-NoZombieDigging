using System.Linq;
using HarmonyLib;
using HarmonyLib.Tools;

namespace NoZombieDigging
{
    public class API : IModApi
    {
        public void InitMod(Mod _modInstance)
        {
            var harmony = new Harmony("dev.tigercat2000.nozombiedigging");
            harmony.PatchAll();
            Log.Out("[NoZombieDigging] Patches applied: {0}", harmony.GetPatchedMethods().Count());
            foreach (var method in harmony.GetPatchedMethods())
            {
                Log.Out("[NoZombieDigging] - {0}", method.Name);        
            }
        }
    }
    
    [HarmonyPatch(typeof(EntityMoveHelper), "DigStart")]
    class DigStartPatch
    {
        static bool Prefix()
        {
            // Log.Out("Stopped zombie from executing DigStart");
            return false;
        } 
    }
    
    [HarmonyPatch(typeof(EAIBreakBlock), "CanExecute")]
    class EAIBreakBlockPatch
    {
        static bool Prefix(ref EAIBreakBlock __instance, ref bool __result)
        {
            var moveHelper = __instance.theEntity.moveHelper;
            if (moveHelper.HitInfo != null)
            {
                var block = __instance.theEntity.world.GetBlock(moveHelper.HitInfo.hit.blockPos).Block;
                if (block.shape.IsTerrain())
                {
                    // Log.Out("Stopped zombie from executing EAIBreakBlock {0}", __instance.theEntity);
                    __result = false;
                    return false;
                }
            }

            return true;
        }
    }
}