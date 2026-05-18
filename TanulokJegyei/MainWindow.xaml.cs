using System.Collections.ObjectModel;
using System.Windows;

namespace TanulokJegyei
{
    public class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Math { get; set; }
        public int Physics { get; set; }
        public double Average => (Math + Physics) / 2.0;
    }

    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Reservations { get; set; }
        public Student SelectedReservation { get; set; }
        public int SelectedReservationIndex { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Reservations = new ObservableCollection<Student>
            {
                new Student { Name = "Kiss Anna", Class = "10.A", Math = 4, Physics = 5 },
                new Student { Name = "Nagy Péter", Class = "9.B", Math = 3, Physics = 4 }
            };

            DataContext = this;
        }

        private void EditCommand(object sender, RoutedEventArgs e)
        {
            EditStudentWindow editWindow = new EditStudentWindow(SelectedReservation);
            Student updated;

            if (editWindow.ShowDialog() == true)
            {
                updated = editWindow.EditedStudent;
                int index = Reservations.IndexOf(SelectedReservation);
                if (index != -1)
                    Reservations[index] = updated;
            }
            else
            {
                updated = editWindow.EditedStudent;
                int index = Reservations.IndexOf(SelectedReservation);
                if (index != -1)
                    Reservations[index] = updated;
            }
        }

        private void DeleteCommand(object sender, RoutedEventArgs e)
        {
            Reservations.RemoveAt(SelectedReservationIndex);
        }

        private void AddReservationCommand(object sender, RoutedEventArgs e)
        {
            AddStudentWindow addWindow = new AddStudentWindow(Reservations);
            addWindow.Show();
        }
    }
}
