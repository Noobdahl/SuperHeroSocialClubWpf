using SuperHeroSocialClubWpf.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SuperHeroSocialClubWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadHeroes();
        }

        public void LoadHeroes()
        {
            lvHeroList.Items.Clear();
            using (SuperHeroSocialClubDbContext context = new())
            {
                //R i crud - Read
                List<SuperHero> heroList = context.SuperHeroes.ToList();
                foreach (SuperHero hero in heroList)
                {
                    ListViewItem newItem = new();
                    newItem.Content = $"{hero.Name} ({hero.SecretIdentity}) - Superpower: {hero.SuperPower}";
                    newItem.Tag = hero;
                    lvHeroList.Items.Add(newItem);
                }
            }
        }

        private void btnAddHero_Click(object sender, RoutedEventArgs e)
        {
            AddHeroWindow addHeroWindow = new();
            addHeroWindow.Owner = this;
            addHeroWindow.Show();
            this.Hide();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem sItem = lvHeroList.SelectedItem as ListViewItem;
            SuperHero sHero = sItem.Tag as SuperHero;

            DetailsWindow detailsWindow = new(sHero);
            detailsWindow.Owner = this;
            detailsWindow.Show();
            this.Hide();
        }

        private void btnRemoveHero_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem sItem = lvHeroList.SelectedItem as ListViewItem;
            SuperHero heroToRemove = sItem.Tag as SuperHero;

            using (SuperHeroSocialClubDbContext context = new())
            {
                context.SuperHeroes.Remove(heroToRemove);
                context.SaveChanges();
            }
            LoadHeroes();
        }
    }
}
