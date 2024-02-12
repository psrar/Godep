using Godep.DI;

public partial class ProjectInstaller : Installer
{
    public override void InstallDependencies()
    {
        var player = new Player() { Age = 23 };
        contextContainer.InjectTo(player);
        contextContainer.BindWithId("teammate", player);

        contextContainer.BindWithId("teammate", new Player() { Age = 40 }, overwrite: true);
    }
}