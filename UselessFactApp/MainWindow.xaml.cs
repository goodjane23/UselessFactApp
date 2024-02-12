using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;

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
    //GET /api/v2/facts/today
    //GET /api/v2/facts/random
    private async void myButton_Click(object sender, RoutedEventArgs e)
    {
        FactTbl.Text = await SendRequest("random");
    }

    private async void myButton_Click1(object sender, RoutedEventArgs e)
    {
        FactTbl.Text = await SendRequest("today");
    }

    private async Task<string> SendRequest(string url)
    {
        var result = await client.GetAsync($"/api/v2/facts/{url}");
        var text = await result.Content.ReadAsStringAsync();
        var responseModel = JsonSerializer.Deserialize<ResponseModel>(text);
        return responseModel.Text;
    }

}
