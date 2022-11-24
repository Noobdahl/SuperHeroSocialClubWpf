using SuperHeroSocialClubWpf.Models;
using System.Windows;

namespace SuperHeroSocialClubWpf
{
    /// <summary>
    /// Interaction logic for AddHeroWindow.xaml
    /// </summary>
    public partial class AddHeroWindow : Window
    {
        public AddHeroWindow()
        {
            InitializeComponent();
        }

        private void btnCreateHero_Click(object sender, RoutedEventArgs e)
        {
            SuperHero newHero = new()
            {
                Name = tbName.Text,
                SecretIdentity = tbSecretIdentity.Text,
                Picture = tbPicture.Text,
                SuperPower = tbSuperpower.Text
            };

            using (SuperHeroSocialClubDbContext context = new())
            {
                context.SuperHeroes.Add(newHero);
                context.SaveChanges();
            }
            ((MainWindow)this.Owner).LoadHeroes();
            Owner.Show();
            this.Close();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
