using System.Windows;

namespace TanulokJegyei
{
    public partial class EditStudentWindow : Window
    {
        public Student EditedStudent { get; set; }

        public EditStudentWindow(Student original)
        {
            InitializeComponent();

            EditedStudent = new Student
            {
                Name = original.Name,
                Class = original.Class,
                Math = original.Math,
                Physics = original.Physics
            };

            nameBox.Text = EditedStudent.Name;
            classBox.Text = EditedStudent.Class;
            mathBox.Text = EditedStudent.Math.ToString();
            physicsBox.Text = EditedStudent.Physics.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            EditedStudent.Name = nameBox.Text;
            EditedStudent.Class = classBox.Text;
            EditedStudent.Math = int.Parse(mathBox.Text);
            EditedStudent.Physics = int.Parse(physicsBox.Text);

            DialogResult = true;
            Close();
        }
    }
}
