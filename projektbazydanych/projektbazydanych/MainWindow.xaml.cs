using projektbazydanych.Data;
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

        using var db = new WypozyczalniaContext();

        if (CheckKlient.IsChecked == true)
        {
            var konto = db.KontaKlientow.FirstOrDefault(k => k.Login == login && k.Haslo == haslo);
            if (konto != null)
            {
                new KlientWindow().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nieprawidłowy login lub hasło klienta.");
            }
        }
        else if (CheckPracownik.IsChecked == true)
        {
            var konto = db.KontaPracownikow.FirstOrDefault(k => k.Login == login && k.Haslo == haslo);
            if (konto != null)
            {
                new PracownikWindow().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nieprawidłowy login lub hasło pracownika.");
            }
        }
        else
        {
            MessageBox.Show("Wybierz typ użytkownika!", "Błąd");
        }
    }
}