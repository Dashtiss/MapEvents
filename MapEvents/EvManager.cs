using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using PlayerRoles;
using UnityEngine;
using Utils;
using ServerArgs = Exiled.Events.EventArgs.Server;
using PlayerArgs = Exiled.Events.EventArgs.Player;
using PlayerHandler = Exiled.Events.Handlers.Player;
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
    }

    public static void OnRoundStart()
    {
        
    }

    private void Died(PlayerArgs.DiedEventArgs ev)
    {
        if (Config.PeanutExplodes) return;
        if (ev.TargetOldRole != RoleTypeId.Scp173) return;
        
        
        var playerPosition = ev.Player.Position;
        
        ev.Player.Explode(ProjectileType.FragGrenade, ev.Player);
        var message = Config.PeanutMessage.Replace("{{Player}}", ev.Player.DisplayNickname);
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