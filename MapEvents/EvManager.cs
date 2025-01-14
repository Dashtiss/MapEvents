using UnityEngine;
using Exiled.API.Enums;
using Exiled.API.Features;
using GameCore;
using PlayerRoles;
using Log = Exiled.API.Features.Log;
using PlayerArgs = Exiled.Events.EventArgs.Player;
using PlayerHandler = Exiled.Events.Handlers.Player;
using ServerHandler = Exiled.Events.Handlers.Server;
using Random = System.Random;

namespace MapEvents;
public class EvManager(MapEventsConfig config)
{
    private readonly Random _random = new();
    private MapEventsConfig Config { get; } = config;

    public void EnableEvents()
    {
        Log.Error("Events system isn't ready yet.");
        PlayerHandler.Died += Died;
        ServerHandler.RoundStarted += OnRoundStart;
    }

    private static void OnRoundStart()
    {
        
    }

    private void Died(PlayerArgs.DiedEventArgs ev)
    {
        if (Config.PeanutExplodes) return;
        if (ev.TargetOldRole != RoleTypeId.Scp173) return;
        
        
        var playerPosition = ev.Player.Position;
        
        ev.Player.Explode(ProjectileType.FragGrenade, ev.Player);
        var message = Config.PeanutMessage.Replace("{{Player}}", ev.Player.DisplayNickname);
        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
        foreach (Player player in PluginAPI.Core.Player.GetPlayers())
        {
            var dist = Vector3.Distance(playerPosition, player.Position);
            if (dist <= Config.DistanceOfExplosion)
            {
                player.Kill(message);
            }
        }
    }
}