using Godot;

public partial class InitScene : Node
{
    public override void _Process(double delta)
    {
        GetTree().ChangeSceneToFile("Sample/Scenes/GameScene.tscn");
    }
}
