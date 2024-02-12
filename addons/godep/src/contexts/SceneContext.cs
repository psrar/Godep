
using System;
using System.Collections.Generic;
using Godot;
using Godot.Collections;

namespace Godep.DI
{
    /// <summary>
    /// A class that defines the dependency context of a scene and inherits ProjectContext dependencies.<br></br>
    /// For more information see ContextInstaller
    /// </summary>
    public partial class SceneContext : ContextInstaller
    {
        [Export] private bool forceInjectEverything = false;

        protected override void BeforeInstalling()
        {
            ProjectContext projectContext = ProjectContext.Singleton;
            Container = new(projectContext.Container);
        }

        protected override void AfterInstalling()
        {
            string currentNode = "";
            try
            {
                Array<Node> nodes;
                if (forceInjectEverything)
                    nodes = new Array<Node>(GetAllTreeNodes(GetTree().CurrentScene));
                else
                    nodes = GetTree().GetNodesInGroup("RequiresInject");

                foreach (var node in nodes)
                {
                    currentNode = node.Name;
                    Container.InjectTo(node);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + $" when injecting in {currentNode} node");
            }

        }

        private List<Node> GetAllTreeNodes(Node root)
        {
            List<Node> nodes = new();
            int childCount = root.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                var node = root.GetChild(i);
                nodes.AddRange(GetAllTreeNodes(node));
            }

            nodes.Add(root);
            return nodes;
        }
    }
}
