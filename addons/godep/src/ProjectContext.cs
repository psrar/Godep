namespace Godep.DI
{
    public partial class ProjectContext : ContextInstaller
    {
        public static ProjectContext Singleton = null;
        public ProjectContext()
        {
            Singleton = this;
        }

        public override void BeforeInstalling()
        {
            Container = new();
        }
    }
}