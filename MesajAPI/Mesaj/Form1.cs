using System.Security.Cryptography.X509Certificates;
using System.Text;

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
            string apiUrl = "http://192.168.8.11:5267";

            using var HttpClient = new HttpClient();

            try 
            {
                var contentText = textBox1.Text.Trim();

                if(contentText == string.Empty) 
                {
                    Label label = new Label();
                    label.Text = "Kontrol Ýçin Mesaj Girmelisin.";
                    label.Location = new Point(0, messageY);
                    label.Size = new Size(300, 20);
                    panel1.AutoScroll = true;
                    messageY += 20;
                    panel1.Controls.Add(label);
                }
                else
                {
                    var content = new StringContent(contentText, Encoding.UTF8, "text/plain");
                    var response = await HttpClient.PostAsync($"{apiUrl}/Mesaj", content);
                    var result = await response.Content.ReadAsStringAsync();
                    Label label = new Label();
                    label.Text = result;
                    label.Location = new Point(0, messageY);
                    label.Size = new Size(300, 20);
                    messageY += 20;
                    panel1.AutoScroll = true;
                    panel1.Controls.Add(label);
                }
               
            }
            catch (HttpRequestException ex) 
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
          

        }
           
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
