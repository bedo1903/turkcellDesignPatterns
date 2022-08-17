namespace UsingProxy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            ServiceReference1.KPSPublicSoapClient client = new ServiceReference1.KPSPublicSoapClient(ServiceReference1.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

            var result = await client.TCKimlikNoDogrulaAsync(1111111, "ad", "asasa", 1980);
            
        }
    }
}