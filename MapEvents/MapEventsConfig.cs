using System.ComponentModel;
using Exiled.API.Interfaces;

namespace MapEvents;

public class MapEventsConfig : IConfig
{
    [Description("Is Plugin Enabled and is Debug enabled?")]
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; } = false;
    
    [Description("Lights Events Enabled?")]
    public bool Lights { get; set; } = true;
    [Description("Light Crash round chance")]
    public int LightsChance { get; set; } = 40;
    
    [Description("Peanut Explodes when dies")]
    public bool PeanutExplodes { get; set; } = true;
    [Description("The range the explosion is")]
    public int DistanceOfExplosion { get; set; } = 5;
    [Description("The message people will get if they die, use `{{Player}}` for the username of the peanut")]
    public string PeanutMessage { get; set; } = "Died to Peanut Explosion {{Player}}";

    [Description("Will the round start with MTF and D-Class spawning instead of SCP's")]
    public bool NoScpStart { get; set; } = true;
    [Description("Chance that no SCP will spawn and only MTF and D-Class will spawn")]
    public int NoScpChance { get; set; } = 20;
    [Description("Minimom number of Players required to do this event")]
    public int MinimumPlayers { get; set; } = 8;
}