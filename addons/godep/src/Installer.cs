using Godot;

namespace Godep.DI
{
    /// <summary>
    /// Determines which dependencies should be installed in the given context.
    /// </summary>
    [GlobalClass]
    public abstract partial class Installer : Node
    {
        public DIContainer contextContainer;

        public abstract void InstallDependencies();
    }
}