using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projektbazydanych;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        // tylko jeden może być zaznaczony
        if (sender == CheckPracownik)
            CheckKlient.IsChecked = false;
        else if (sender == CheckKlient)
            CheckPracownik.IsChecked = false;

        LoginPanel.Visibility = Visibility.Visible;
    }

    private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
        // Jeśli odznaczone oba — ukryj panel logowania
        if (CheckPracownik.IsChecked == false && CheckKlient.IsChecked == false)
            LoginPanel.Visibility = Visibility.Collapsed;
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        string login = LoginTextBox.Text;
        string haslo = PasswordBox.Password;

        if (CheckKlient.IsChecked == true)
        {
            // tu można dodać weryfikację loginu i hasła
            KlientWindow klientWindow = new KlientWindow();
            klientWindow.Show();
            this.Close(); // zamknij okno logowania
        }
        else if (CheckPracownik.IsChecked == true)
        {
            try
            {
                PracownikWindow pracownikWindow = new PracownikWindow();
                pracownikWindow.Show();
                this.Close(); // lub this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad przy otwieraniu panelu pracownika:\n" + ex.Message);
            }
        }
        else
        {
            MessageBox.Show("Wybierz typ użytkownika!", "Błąd");
        }
    }
}