using Godot;

namespace Godep.DI
{
    [GlobalClass]
    public abstract partial class Installer : Node
    {
        public DIContainer contextContainer;

        public abstract void InstallDependencies();
    }
}