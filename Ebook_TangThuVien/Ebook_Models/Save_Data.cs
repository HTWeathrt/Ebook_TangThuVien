using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using EpubSharp;

namespace Ebook_TangThuVien.Ebook_Models
{
    internal class Save_Data
    {
        public const string EPU = "epub";

        public const string TXT = "txt";

        public async Task SaveData(string Mode_Save, List<(int Index, string Result)> data)
        {
            switch(Mode_Save)
            {
                case EPU:
                    {
                       await Save_EPU(data);


                }
                    break;
                 case TXT:
                {

                        await Save_Txt(data);
                }break;
            }
        }
        private async Task Save_EPU(List<(int Index, string Result)> data)
        {
           
            try
            {
                await Task.Run(() =>
                {
                    string Date_R = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string Path = $@"Export\{Date_R}_Docs.epub";

                    EpubWriter epu = new EpubWriter();
                    foreach (var item in data)
                    {
                        string Chap = $"\n *** Chap : {item.Index} \n";
                        epu.AddAuthor(Chap);
                        epu.AddAuthor(item.Result);
                        //.Write(item.Result);
                    }
                    epu.Write(Path);
                    Process.Start("Export");
                });
            }
            catch
            {

            }

        }
        private async Task Save_Txt(List<(int Index, string Result)> data)
        {
            try
            {
                await Task.Run(() =>
                {
                    string Date_R = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string Path = $@"Export\{Date_R}_Docs.txt";
                    StreamWriter writer = new StreamWriter(Path);
                    foreach (var item in data)
                    {
                        string Chap = $"\n *** Chap : {item.Index} \n";
                        writer.Write(Chap);
                        writer.Write(item.Result);
                    }
                    Process.Start("Export");
                });
            }
            catch
            {

            }
           
            
        }
    }
}
