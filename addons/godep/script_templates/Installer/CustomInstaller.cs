// meta-name: Custom dependencies installer
// meta-description: Example of installing dependencies of the project or scene context
// meta-default: true
// meta-space-indent: 4

using Godot;
using Godep.DI;

public partial class _CLASS_ : Installer
{
    // Declaration of bindable fields to be set in the editor
    // [Export] private AppConfig appConfig;

    // A function called by the context to install dependencies in a container
    public override void InstallDependencies()
    {
        // Player player = new() { Age = 21 };
        // contextContainer.Bind<Player>(player);

        // contextContainer.Bind(appConfig);
    }
}