using Godot;

namespace Godep.DI
{
    /// <summary>
    /// Defines the context to which the DIContainer corresponds. On entering the tree, traverses the specified installers, calling their InstallDependencies method and passing them the context container.<br></br>
    /// </summary>
    public abstract partial class ContextInstaller : Node
    {
        [Export] protected Installer[] installers = { };

        public DIContainer Container { get; protected set; }

        public override void _EnterTree()
        {
            BeforeInstalling();

            foreach (var installer in installers)
            {
                installer.contextContainer = Container;
                installer.InstallDependencies();
            }

            AfterInstalling();
        }

        /// <summary>
        /// Method to call before executing all the installers
        /// </summary>
        protected virtual void BeforeInstalling() { }
        protected virtual void AfterInstalling() { }
    }
}