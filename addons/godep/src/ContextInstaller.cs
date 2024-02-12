using Godot;

namespace Godep.DI
{
    public abstract partial class ContextInstaller : Node
    {
        [Export]
        protected Installer[] installers = { };

        public DIContainer Container { get; protected set; }

        public override void _EnterTree()
        {
            BeforeInstalling();

            foreach (var installer in installers)
            {
                installer.container = Container;
                installer.InstallDependencies();
            }

            AfterInstalling();
        }

        public virtual void BeforeInstalling() { }
        public virtual void AfterInstalling() { }
    }
}