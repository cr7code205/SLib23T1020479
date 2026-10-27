using System.Threading.Tasks;

namespace SLib23T1020479.DesktopApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = await ServiceManager.AuthorService.ListAsync();
        }
    }
}
