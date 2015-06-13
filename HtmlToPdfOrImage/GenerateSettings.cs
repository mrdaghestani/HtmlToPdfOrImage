using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtmlToPdfOrImage
{
    public enum OutputType
    {
        PDF,
        Image
    }
    public class GenerateSettings
    {
        public GenerateSettings()
        {
            GlobalOptions = new GlobalOptions();
        }
        /// <summary>
        /// Html Url, it must accessible from internet without any athentication
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Html content, like: <span>PDF Me</span>
        /// </summary>
        public string HtmlFileContent { get; set; }

        private OutputType _outputType = OutputType.PDF;

        /// <summary>
        /// OutputType
        /// Default: PDF
        /// </summary>
        public OutputType OutputType
        {
            get { return _outputType; }
            set { _outputType = value; }
        }
        public GlobalOptions GlobalOptions { get; set; }
    }
    public class GlobalOptions
    {
        private bool _collate = true;
        /// <summary>
        /// Collate when printing multiple copies.
        /// Default: true
        /// </summary>
        public bool Collate
        {
            get { return _collate; }
            set { _collate = value; }
        }
        private int _copies = 1;
        /// <summary>
        /// Number of copies to print into the pdf file.
        /// Default: 1
        /// </summary>
        public int Copies
        {
            get { return _copies; }
            set { _copies = value; }
        }
        private bool _grayscale = false;
        /// <summary>
        /// PDF will be generated in grayscale.
        /// Default: false
        /// </summary>
        public bool Grayscale
        {
            get { return _grayscale; }
            set { _grayscale = value; }
        }

    }
}