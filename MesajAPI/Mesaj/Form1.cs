using System.Security.Cryptography.X509Certificates;

namespace Mesaj
{
    public partial class Form1 : Form
    {
        int messageY = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:5267";

            using var HttpClient = new HttpClient();
            try 
            {
                string response = await HttpClient.GetStringAsync($"{apiUrl}/Mesaj");
                Label label = new Label();
                label.Text = response;  
                label.Size = new Size(100, 20);
                label.Location = new Point(10, messageY);
                messageY += 20;
                panel1.AutoScroll = true;
                panel1.Controls.Add(label);
            }
            catch (HttpRequestException ex ) 
            {
                MessageBox.Show($"Hata: {ex}");
                Label label = new Label();
                label.Text = "API AKTÝF DEÐÝL";
                label.Size = new Size(100, 20);
                label.Location = new Point(10, messageY);
                messageY += 20;
                panel1.AutoScroll = true;
                panel1.Controls.Add(label);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
