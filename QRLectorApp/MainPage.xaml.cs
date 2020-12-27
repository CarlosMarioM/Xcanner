using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace QRLectorApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
   
    public partial class MainPage : ContentPage
    {
        Services.Services _services = new Services.Services();
  
        public MainPage()
        {
            InitializeComponent();         
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Scanner();
        }

        private void Scanner()
        {
            var scannerPage = new ZXingScannerPage();
            scannerPage.Title = "Escaner QR";
            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsScanning = false;
                _services.SelectAsync(result.Text);
                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopAsync();
                    string Color = Xamarin.Forms.Application.Current.Properties["color"].ToString();
                    string Status = Xamarin.Forms.Application.Current.Properties["status"].ToString();
                    if (Status == "2")
                    {

                        var color = Xamarin.Forms.Application.Current.Properties["color"];

                        DisplayAlert("Notificación", "El número de registro " + result.Text + " ya se encuentra registrado", "Aceptar");

                    }
                    else if (Status == "1")
                    {

                        var color = Xamarin.Forms.Application.Current.Properties["color"];
                        DisplayAlert("Notificación", "El número de registro es " + result.Text + " " + color.ToString() + "", "Entendido");

                    }
                    else
                    {
                        DisplayAlert("Notificación", "Ningún registro encontrado", "Entendido");
                    }

              

                });
            };
            Navigation.PushAsync(scannerPage);
        }

        }

        
    }

