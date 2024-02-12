using Godep.DI;
using Godot;

public partial class GameScene : Node
{
    [Inject] public Player injectedPlayer;

    public override void _Ready()
    {
        GD.Print(injectedPlayer + " was injected.");
        
    }
}
