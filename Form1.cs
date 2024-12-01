using System.Threading;


namespace Painel_Anjo_Stroe
{
    public partial class Login : Form
    {
        Thread nt;
        public Login()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "Anjo" && guna2TextBox2.Text == "1850")
            {
                this.Close();
                nt = new Thread(novoForm);
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();
            }
            else
            {
                MessageBox.Show("Usuario ou Senha invalido");
            }
        }

        private void novoForm(object? obj)
        {
            Application.Run(new Form2());
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
