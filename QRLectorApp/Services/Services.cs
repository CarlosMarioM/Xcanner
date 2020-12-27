using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using QRLectorApp.Model;


namespace QRLectorApp.Services
{
    class Services
    {

        public void SelectAsync(string result)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://masterqr.azurewebsites.net/API/qr/Select?result=" + result;

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = client.SendAsync(request).Result;

                using (HttpContent content = response.Content)
                { 
                var json = content.ReadAsStringAsync();
                    try
                    {
                        var qrList = JsonConvert.DeserializeObject<List<QrColorApp>>(json.Result);

                        foreach (QrColorApp qr in qrList)
                        {
                            Xamarin.Forms.Application.Current.Properties["color"] = qr.color;
                            Xamarin.Forms.Application.Current.Properties["status"] = qr.status;
                        }

                    }
                    catch(Exception er)
                    {

                    }
                  

                }

            }

        }
    }
}
