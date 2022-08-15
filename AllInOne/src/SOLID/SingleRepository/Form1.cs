using System.Data.SqlClient;

namespace SingleRepository
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Her nesne, tek bir işten sorumlu olmalıdır.
         * Eğer; bir sınıfta değişiklik yapmak için birden fazla sebebiniz oluyorsa bu prensibine uymuyorsunuz demektir!
         * 
         * Form1 sınıfının, birincil sorumluluğu nedir?
         *    Kullanıcıdan veri alırım.
         *    Kullanıcıya sonuç gösterebilirim.
         *    Kullanıcının eylemi sonucunda işlem yapabilirim.
         */

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            var name = textBoxProductName.Text;
            var price = Convert.ToDecimal(textBoxPrice.Text);
            var affectedRowsCount = new ProductService().AddProduct(name,price);
            var message = affectedRowsCount > 0 ? "Kayıt Başarılı" : "Hatalı İşlem...";

            MessageBox.Show(message);
        }

      
    }
}