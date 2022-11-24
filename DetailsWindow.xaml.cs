using SuperHeroSocialClubWpf.Models;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SuperHeroSocialClubWpf
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        SuperHero currentHero;
        public DetailsWindow(SuperHero sHero)
        {
            InitializeComponent();
            currentHero = sHero;
            LoadDetails();
        }

        private void LoadDetails()
        {
            tbName.Text = currentHero.Name;
            tbSecretIdentity.Text = currentHero.SecretIdentity;
            tbSuperpower.Text = currentHero.SuperPower;
            tbPicture.Text = currentHero.Picture;

            var uri = new Uri(currentHero.Picture);
            var bitmap = new BitmapImage(uri);
            image.Source = bitmap;
        }

        private void btnEditHero_Click(object sender, RoutedEventArgs e)
        {
            currentHero.Name = tbName.Text;
            currentHero.SecretIdentity = tbSecretIdentity.Text;
            currentHero.SuperPower = tbSuperpower.Text;
            currentHero.Picture = tbPicture.Text;

            using (SuperHeroSocialClubDbContext context = new())
            {
                context.SuperHeroes.Update(currentHero);
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
