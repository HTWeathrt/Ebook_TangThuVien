using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Ebook_TangThuVien.Ebook_Models.Log
{
    public class RichTextBoxWriter : TextWriter
    {
        private readonly RichTextBox _richTextBox;
        private readonly int _maxLength;

        public RichTextBoxWriter(RichTextBox richTextBox, int maxLength = 200000)
        {
            _richTextBox = richTextBox;
            _maxLength = maxLength;
        }
        public override void WriteLine(string value)
        {
            _richTextBox.Dispatcher.Invoke(() =>
            {
                _richTextBox.AppendText($"{Call_Clock()} :{value}\n"); // Thêm chuỗi + dòng mới
                EnsureMaxLength();
                _richTextBox.ScrollToEnd();
            });
        }
        string Call_Clock()
        {
            string Timer = DateTime.Now.ToString("[yyyyMMdd_HH:mm:sss]");
            return Timer;
        }
        private void EnsureMaxLength()
        {
            if (_richTextBox.Document.ContentStart.GetOffsetToPosition(_richTextBox.Document.ContentEnd) > _maxLength)
            {
                var range = new TextRange(_richTextBox.Document.ContentStart, _richTextBox.Document.ContentEnd);
                string currentText = range.Text;
                if (currentText.Length > _maxLength)
                {
                    _richTextBox.Document.Blocks.Clear();
                    _richTextBox.AppendText(currentText.Substring(currentText.Length - _maxLength));
                }
            }
        }
        public override Encoding Encoding => Encoding.UTF8;
    }

}
