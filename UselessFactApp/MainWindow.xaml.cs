using Microsoft.UI.Xaml;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UselessFactApp;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    private readonly HttpClient client;
    public MainWindow()
    {
        this.InitializeComponent();
        client = new HttpClient();
        client.BaseAddress = new Uri("https://uselessfacts.jsph.pl/");
    }

    private async void myButton_Click(object sender, RoutedEventArgs e)
    {
        factTbl.Text = await SendRequest("random");
    }

    private async void myButton_Click1(object sender, RoutedEventArgs e)
    {
        factTbl.Text = await SendRequest("today");
    }

    private async Task<string> SendRequest(string url)
    {
        var result = await client.GetAsync($"/api/v2/facts/{url}");
        var text = await result.Content.ReadAsStringAsync();
        var responseModel = JsonSerializer.Deserialize<ResponseModel>(text);
        return responseModel.Text;
    }

 
}
