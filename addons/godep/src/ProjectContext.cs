namespace Godep.DI
{
    public partial class ProjectContext : ContextInstaller
    {
        public static ProjectContext Singleton = null;
        public ProjectContext()
        {
            Singleton = this;
        }

        protected override void BeforeInstalling()
        {
            Container = new();
        }
    }
}