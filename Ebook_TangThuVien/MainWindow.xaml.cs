using Ebook_TangThuVien.Ebook_Models;
using Ebook_TangThuVien.Ebook_Models.Log;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ebook_TangThuVien
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var writer = new RichTextBoxWriter(LOG_CONSOLE);
            Console.SetOut(writer);
            Console.WriteLine(" Tool Get data TangThuVien :......");
            request_HTTP = new HTTP_Request();

        }
        HTTP_Request request_HTTP;
        private async void Start_Download(object sender, RoutedEventArgs e)
        {
           // LoadingProgressbar.Visibility = Visibility.Visible;
            try
            {
                request_HTTP.Flag_Cancel = false;
                string URL_W = ULR_Web.Text;
                string SaveType = Save_TYPE.Text;
                int Chap_ST = Convert.ToInt32(ChapterStart.Text);
                int Chap_EN = Convert.ToInt32(ChapterEND.Text);
                if (!string.IsNullOrEmpty(URL_W) && !string.IsNullOrEmpty(SaveType))
                {
                    bool Open_ =await  request_HTTP.Load_(URL_W,Chap_ST,Chap_EN,SaveType);
                    if (Open_)
                    {
                        Console.WriteLine("Connect -->>>   "+ URL_W);
                        await request_HTTP.Create_Conten();
                    }
                }
                else
                {
                    Console.WriteLine("Null Data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex);
            }
           // LoadingProgressbar.Visibility = Visibility.Collapsed;
        }
        #region AppCOntrol
        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void HideToTaskBar(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_APP(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion

        private void ChapterStart_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]*$");
        }

        private void CancelDownload(object sender, RoutedEventArgs e)
        {

        }

        private void Openfilelocation(object sender, RoutedEventArgs e)
        {
            try
            {
                string exePath = Assembly.GetExecutingAssembly().Location; 
                Process.Start("explorer.exe", $"/select,\"{exePath}\"");
                //Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            catch
            {

            }
        }

        private void Flag_Cancel(object sender, RoutedEventArgs e)
        {
            request_HTTP.Flag_Cancel = true;
        }
    }
}
