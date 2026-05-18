using System.Collections.ObjectModel;
using System.Windows;

namespace TanulokJegyei
{
    public partial class AddStudentWindow : Window
    {
        private ObservableCollection<Student> list;

        public AddStudentWindow(ObservableCollection<Student> reservations)
        {
            InitializeComponent();
            list = reservations;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            list.Add(new Student
            {
                Name = nameBox.Text,
                Class = classBox.Text,
                Math = int.Parse(mathBox.Text),
                Physics = int.Parse(physicsBox.Text)
            });

            Close();
        }
    }
}
