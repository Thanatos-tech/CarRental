using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kursach_1._2
{
    /// <summary>
    /// Логика взаимодействия для AddReview.xaml
    /// </summary>
    public partial class AddReview : Window
    {
        public AddReview()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {


            var rent = (CarRental_User)this.Owner;
            TextRange textRange = new TextRange(reviewRichtextbox.Document.ContentStart, reviewRichtextbox.Document.ContentEnd);
            Review r = new Review { Text = textRange.Text};
            using(UserContext db = new UserContext())
            {
                foreach(User u in db.Users)
                {
                    if(u.Login == rent.us.Login)
                    {
                        u.Review = r;
                    }
                }


                List<FullReviewer> reviews = new List<FullReviewer>();
                foreach (User u in db.Users.Include("UserProfile").Include("Review"))
                {
                    if (u.Review.Id != 1)
                    {
                        reviews.Add(new FullReviewer
                        {
                            FirstName = u.UserProfile.FirstName,
                            SecondName = u.UserProfile.SecondName,
                            Text = u.Review.Text
                        });
                    }
                }
                rent.reviewGrid.ItemsSource = reviews;


                rent.reviewGrid.ItemsSource = db.Reviews.ToList();
                rent.reviewGrid.Items.Refresh();
                db.SaveChanges();
            }
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
