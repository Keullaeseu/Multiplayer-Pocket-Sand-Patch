using Multiplayer.Compat;
using Verse;

namespace MultiplayerPocketSandPatch.Source.Mods;

/// <summary>
///     Multiplayer Patch for Pocket Sand by Usagirei,
///     Last Update: 22 Jul, 2025 @ 12:34am
///     <see href="https://steamcommunity.com/sharedfiles/filedetails/?id=2226330302" />
/// </summary>
[MpCompatFor("usagirei.pocketsand")]
public class PocketSand
{
    private const string LogPrefix = "[Multiplayer Pocket Sand Patch]";

    public PocketSand(ModContentPack content)
    {
        LongEventHandler.ExecuteWhenFinished(LatePatch);
    }

    private static void LatePatch()
    {
        Log.Message($"{LogPrefix} Initializing...");

        try
        {
            if (!PocketSandSyncMethods.RegisterAll()) return;

            Log.Message($"{LogPrefix} Initialized.");
        }
        catch (Exception exception)
        {
            Log.Error($"{LogPrefix} Failed to initialize: {exception}");
        }
    }
}