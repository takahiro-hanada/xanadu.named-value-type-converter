using System.Windows.Forms;

namespace Demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            _propertyGrid.SelectedObject = new MyClass();
        }
    }
}
