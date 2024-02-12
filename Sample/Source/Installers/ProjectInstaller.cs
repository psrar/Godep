using Godep.DI;

public partial class ProjectInstaller : Installer
{
    public Player player;

    public override void InstallDependencies()
    {
        player = new() { Age = 21 };
        contextContainer.Bind(player);

        contextContainer.BindWithId("lol", 2);
        contextContainer.BindWithId("plar", new Player() { Age = 40 });
    }
}