using Xamarin.Forms;

namespace BcTool.Views
{
    public partial class SigninPage : ContentPage
    {
        public SigninPage()
        {
            InitializeComponent();

            // TODO：バインディングでファイルを指定すること
            image.Source = ImageSource.FromResource("BcTool.Images.title.png");
        }
    }
}
