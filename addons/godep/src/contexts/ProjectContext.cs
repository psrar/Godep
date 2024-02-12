namespace Godep.DI
{
    /// <summary>
    /// A class whose purpose is to store the highest-level dependencies, such as application configs, authentication settings, and so on<br></br>
    /// For more information see ContextInstaller
    /// </summary>
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