#if TOOLS
using Godot;

[Tool]
public partial class GodepPlugin : EditorPlugin
{
	public override void _EnterTree()
	{
		var script = GD.Load<Script>("res://addons/godep/src/contexts/SceneContext.cs");
		var icon = GD.Load<Texture2D>("res://addons/godep/graphics/scene_context.png");
		AddCustomType("SceneContext", "Node", script, icon);

		script = GD.Load<Script>("res://addons/godep/src/contexts/ProjectContext.cs");
		icon = GD.Load<Texture2D>("res://addons/godep/graphics/project_context.png");
		AddCustomType("ProjectContext", "Node", script, icon);
	}

	public override void _ExitTree()
	{
		RemoveCustomType("SceneContext");
		RemoveCustomType("ProjectContext");
	}
}
#endif
