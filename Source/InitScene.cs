using Godot;

public partial class InitScene : Node
{
    public override void _Ready()
    {
        GetTree().ChangeSceneToFile("Scenes/GameScene.tscn");
    }
}
