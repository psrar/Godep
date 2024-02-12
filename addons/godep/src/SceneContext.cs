
using System.Reflection;

namespace Godep.DI
{
    public partial class SceneContext : ContextInstaller
    {
        public override void BeforeInstalling()
        {
            ProjectContext projectContext = ProjectContext.Singleton;
            Container = new(projectContext.Container);
        }

        public override void AfterInstalling()
        {
            var nodes = GetTree().GetNodesInGroup("RequiresInject");
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            foreach (var node in nodes)
            {
                FieldInfo[] fieldsInfo = node.GetType().GetFields(bindingFlags);
                foreach (var field in fieldsInfo)
                {
                    var attributes = field.GetCustomAttributes(false);
                    foreach (var attr in attributes)
                    {
                        if(attr is InjectAttribute)
                        {
                            field.SetValue(node, Container.Get(field.FieldType));
                        }
                    }
                }
            }
        }
    }
}
