using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Messenger_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            bool loggedIn = await API.loginAsync(textBox1.Text, textBox2.Text);
            if (loggedIn)
            {
                MessageBox.Show("Logged in.");
                Program.user = textBox1.Text;
                Program.pass = textBox2.Text;
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Fail login");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Create create = new Create();
            create.Show();
        }
    }
}