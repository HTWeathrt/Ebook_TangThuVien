using HtmlAgilityPack;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Ebook_TangThuVien.Ebook_Models
{
    internal class HTTP_Request
    {
        private string URL_WEB_DOWNLOAD;
        private int PAGE_ST;
        private int PAGE_EN;
        private string SaveType;
        private const string page_ter = "chuong-";
        public HTTP_Request() 
        {

        }
        public async Task<bool> Load_(string URL_WEB, int PAGESTART, int PAGEEND, string Save_TYPE)
        {
            //https://truyen.tangthuvien.vn/doc-truyen/cuu-vuc-pham-tien
            //https://truyen.tangthuvien.vn/doc-truyen/cuu-vuc-pham-tien/chuong-1
            URL_WEB_DOWNLOAD = URL_WEB;
            PAGE_ST = PAGESTART;
            PAGE_EN = PAGEEND;
            SaveType = Save_TYPE;
            var task = await Check_URL.Check_WEB(URL_WEB);;
            return task; 
        }
        public async Task Create_Conten()
        {
            try
            {
                Dictionary<int, string> FullDownload = new Dictionary<int, string>();
                await Task.Run(() =>
                {
                    for (int i = PAGE_ST; i <= PAGE_EN; i++)
                    {
                        string URL_DOWNLOAD_ENT = $"{URL_WEB_DOWNLOAD}/{page_ter}{i}";
                        //
                        FullDownload.Add(i, URL_DOWNLOAD_ENT);
                    }

                });
                if (FullDownload.Count > 0)
                {
                    Console.WriteLine($"Download total :{FullDownload.Count} Chappter ");
                    await LoadingPageFrame(FullDownload);
                }
                else
                {
                    Console.WriteLine("No chappter download");
                }
            }
            catch
            {
                Console.WriteLine("Error : Create Conten error ");
            }
        }

        private const string _RequestInerConten = "";
        public bool Flag_Cancel = false;
        async Task LoadingPageFrame(Dictionary<int, string> fulload)
        {
            try
            {
                List<string> Docs_data = new List<string>();
                HttpClient http_rquest = new HttpClient();
                Save_Data save = new Save_Data();
                var results = new ConcurrentBag<(int Index, string Result)>();

                /*int Total = fulload.Count;
                int Count = 0;*/
                foreach (var item in fulload)
                {
                    if (Flag_Cancel) break;
                    var DataWeb = await CopyFullDatainCache(http_rquest, item.Value);
                    if (DataWeb != null)
                    {
                        var data_cot = Get_dataconten(DataWeb);
                        string Data = Result_Scan(data_cot);
                        results.Add((item.Key, Data));
                        Console.WriteLine("Complete :" + item.Value);
                    }
                    /* Count++;
                     double YRT_Rate = Math.Round((double)Count / Total * 100, 2);
                    *//* CountModel.Progress_Value = (int)YRT_Rate;
                     CountModel.Progressbar_ = $"Loading Progressing :{YRT_Rate}%";*/

                }
                if (!Flag_Cancel)
                {

                    var sortedResults = results.OrderBy(r => r.Index).ToList();
                    await save.SaveData(SaveType, sortedResults);
                }
                else
                {
                    Console.WriteLine("Cancel ");
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
       string  Get_dataconten(string docs)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(docs);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'box-chap')]");
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    return node.InnerText.Trim();
                }
            }
            return string.Empty;

        }
        string Result_Scan(string RQ)
        {
            // Xóa tất cả các ký tự khoảng trắng (space, tab, xuống dòng)
            //string result = Regex.Replace(RQ, @"\s+", "");
            string result = Regex.Replace(RQ, @"[\t\r\n]+", "");
            return result;
        }
        async Task<string> CopyFullDatainCache(HttpClient client, string HTTP_REQUEST)
        {
           
            var response = await client.GetAsync(HTTP_REQUEST);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
               // string DataWEB = await ElumentSplitWeb(data);
                return data;
            }
            else
            {
               Console.WriteLine($"HTTP Error: {response.StatusCode}");
                return null;
            }
        }
        async Task<string> ElumentSplitWeb(string Data)
        {
            return await Task.Run(async () =>
            {
                List<string> emnu = new List<string>();
                var ENTRY_SPLIT = await ElumentSplit(Data);
                var trimmedEntrySplit = ENTRY_SPLIT.Skip(1).Take(ENTRY_SPLIT.Count - 3);
                foreach (var SPLEX in trimmedEntrySplit)
                {
                    string WEBPLANK = RemoveAfterBr(SPLEX);
                    string remux = Regex.Replace(WEBPLANK, @"\s*<\s*br\s*/?>\s*", " .");
                    emnu.Add(remux);
                }
                string result = string.Join(Environment.NewLine, emnu);
                return result;
            });
        }
        static async Task<List<string>> ElumentSplit(string data)
        {
            return await Task.Run(() =>
            {
                return data
                    .Split(new[] { "<p>" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => e.Replace("</p>", "").Trim())
                    .Where(e => !string.IsNullOrEmpty(e))
                    .ToList();
            });
        }
        static string RemoveAfterBr(string input)
        {
            int index = input.IndexOf("</br>");
            if (index >= 0)
            {
                return input.Substring(0, index);
            }
            return input; 
        }
        async Task Call(string Path_Web)
        {
            // https://ntruyen.top/truyen/cuu-vuc-pham-tien-58461/20493661.html
            using (HttpClient client = new HttpClient())
            {
                StreamWriter streamWriter = new StreamWriter("FULLCONTEN.txt");
                try
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36");

                    string LinkWeb = @"https://truyen.tangthuvien.vn/doc-truyen/cuu-vuc-pham-tien/chuong-1";
                    int Double_Web = 1;
                    for (int i = 0; i < 2888; i++)
                    {
                        double YRT = Math.Round(((double)i / 2888 * 100), 2);
                       /* Dispatcher.Invoke(() =>
                        {

                            LoadingConten.Content = $"{i + 1}/{2888} =>{YRT}%";
                        });*/
                        string URL_REquest = $"{LinkWeb}{Double_Web}.html";

                        string REPPLY = await CopyFullDatainCache(client, URL_REquest);
                        string CHAP = $"\n\rChap-{i + 1}\n";
                        streamWriter.Write(CHAP);
                        streamWriter.Write(REPPLY);
                        Double_Web++;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi kết nối
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                MessageBox.Show("Complete");
            }

        }

    }
}
