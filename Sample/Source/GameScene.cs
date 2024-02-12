using Godep.DI;
using Godot;

public partial class GameScene : Node
{
    [Inject] private readonly DIContainer container;
    [Inject] private readonly Player injectedPlayer;

    public override void _Ready()
    {
        GD.Print(injectedPlayer + " was injected.");
        GD.Print(container.GetWithId<Player>("plar") + " was injected.");

    }
}
