using HarmonyLib;
using Multiplayer.API;
using Verse;

namespace MultiplayerPocketSandPatch.Source.Mods;

/// <summary>
///     Registers Pocket Sand methods that change game state and must be synced.
///     Covers both single-pawn gizmo (Gizmo_WeaponSelector) and multi-pawn gizmo
///     (Gizmo_WeaponSelectorMulti), as both funnel through PawnExtensions.
/// </summary>
internal static class PocketSandSyncMethods
{
    private const string LogPrefix = "[Multiplayer Pocket Sand Patch]";
    private const string PawnExtensionsTypeName = "PocketSand.PawnExtensions";
    private const string EquipFromInventoryMethodName = "EquipFromInventory";
    private const string DropFromInventoryMethodName = "DropFromInventory";

    public static bool RegisterAll()
    {
        var pawnExtensionsType = AccessTools.TypeByName(PawnExtensionsTypeName);
        if (pawnExtensionsType == null)
        {
            Log.Error($"{LogPrefix} Could not find type {PawnExtensionsTypeName}, patch failed.");
            return false;
        }

        MP.RegisterSyncMethod(pawnExtensionsType, EquipFromInventoryMethodName);
        MP.RegisterSyncMethod(pawnExtensionsType, DropFromInventoryMethodName);

        return true;
    }
}