using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ebook_TangThuVien.Ebook_Models
{
    internal class Check_URL
    {
        public static async Task<bool> Check_WEB(string URL)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36");
                    var response = await client.GetAsync(URL);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        if (data.Length > 1000)
                        {
                            return true;
                        }
                        return false;

                    }
                    else
                    {
                        MessageBox.Show($"HTTP Error: {response.StatusCode}");
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
           
        }
    }
}
