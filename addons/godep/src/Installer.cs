using Godot;

namespace Godep.DI
{
    public abstract partial class Installer : Node
    {
        public DIContainer container;

        public abstract void InstallDependencies();
    }
}