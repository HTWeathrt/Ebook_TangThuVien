using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            /*_richTextBox.Dispatcher.Invoke(() =>
            {
               *//* EnsureMaxLength();
                _richTextBox.ScrollToEnd();*//*
            });*/
            TrimLog(_richTextBox, value);
        }
/*        private void EnsureMaxLength()
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

        }*/
        private const int MaxLogLength = 100000;
        private void TrimLog(RichTextBox richTextBox, string value)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                // Get the total length of the RichTextBox content
                TextRange fullTextRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                int totalLength = fullTextRange.Text.Length;

                if (totalLength > MaxLogLength)
                {
                    // Trim the text efficiently
                    TextPointer startPointer = richTextBox.Document.ContentStart.GetPositionAtOffset(totalLength - MaxLogLength);
                    if (startPointer != null)
                    {
                        TextRange trimRange = new TextRange(richTextBox.Document.ContentStart, startPointer);
                        trimRange.Text = string.Empty;
                    }
                }

                // Append new log entry
                string logEntry = $"{DateTime.Now:yyyyMMdd_HH:mm:sss}: {value}\n";
                richTextBox.AppendText(logEntry);

                // Scroll to the end
                richTextBox.ScrollToEnd();
            });
        }

        public override Encoding Encoding => Encoding.UTF8;
    }

}
