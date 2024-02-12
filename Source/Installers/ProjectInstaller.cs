using Godep.DI;
using Godot;

public partial class ProjectInstaller : Installer
{
    [Export]
    Player player;

    public override void InstallDependencies()
    {
        player = new() { Age = 21 };
        container.Bind(player);
    }
}