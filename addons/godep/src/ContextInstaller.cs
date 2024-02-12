using System.Reflection;
using Godot;

namespace Godep.DI
{
    public abstract partial class ContextInstaller : Node
    {
        private const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        [Export] protected Installer[] installers = { };

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

        public void Inject(object obj)
        {
            FieldInfo[] fieldsInfo = obj.GetType().GetFields(bindingFlags);
            foreach (var field in fieldsInfo)
            {
                var attributes = field.GetCustomAttributes(false);
                foreach (var attr in attributes)
                {
                    if (attr is InjectAttribute)
                    {
                        field.SetValue(obj, Container.Get(field.FieldType));
                    }
                }
            }
        }

        protected virtual void BeforeInstalling() { }
        protected virtual void AfterInstalling() { }
    }
}