using Exiled.API.Features;

namespace MapEvents;

public class MapEvents : Plugin<MapEventsConfig>
{
    
    
    public override string Author => "Dashtiss";
    public override string Name => "Map Events";
    public override string Prefix => "MapEvents";
    public override Version Version { get; } = new Version(1, 0, 0);
    public override Version RequiredExiledVersion { get; } = new Version(9, 3, 0);
    // ReSharper disable once MemberCanBePrivate.Global
    public static MapEvents Instance { get; set; } = null!;
    public override void OnEnabled()
    {
        Instance = this;
        EvManager eh = new EvManager(Instance.Config);
        eh.EnableEvents();
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        Instance = null!;
        base.OnDisabled();
    }

    public override void OnReloaded()
    {
        Instance = null!;
        Instance = this;
        base.OnReloaded();
    }
}