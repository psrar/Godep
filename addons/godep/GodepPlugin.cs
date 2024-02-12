#if TOOLS
using Godot;
using System;

[Tool]
public partial class GodepPlugin : EditorPlugin
{
	public override void _EnterTree()
	{
		// Initialization of the plugin goes here.
        // Add the new type with a name, a parent type, a script and an icon.
        var script = GD.Load<Script>("res://addons/godep/DependencyInjection/SceneContext.cs");
        var texture = GD.Load<Texture2D>("res://icon.png");
        AddCustomType("SceneContext", "Node", script, texture);
		
	}

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here.
		RemoveCustomType("SceneContext");
	}
}
#endif
