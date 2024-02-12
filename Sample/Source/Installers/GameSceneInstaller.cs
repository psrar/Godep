using Godep.DI;

public partial class GameSceneInstaller : Installer
{
	public override void InstallDependencies()
	{
		Player player = new() { Age = 36 };
		contextContainer.Bind<Player>(player);
	}
}
