using Microsoft.EntityFrameworkCore;

namespace Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        public static void InitilizationDB()
        {
            using var db = new DBContext();
            db.Database.EnsureCreated();
            db.Database.Migrate();
        }
        public static DBContext DB = new DBContext();
    }
}
