namespace Godep.DI
{
    public partial class ProjectContext : ContextInstaller
    {
        public static ProjectContext Singleton { get; private set; } = null;
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