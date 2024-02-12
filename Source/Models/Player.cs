using Godot;

public partial class Player : GodotObject
{
    public int Age;

    public override string ToString()
    {
        return $"Player({Age})";
    }
}
