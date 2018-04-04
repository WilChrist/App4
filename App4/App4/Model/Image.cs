using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App4.Model
{
    class Image
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public byte[] Content { get; set; }

        public Image() { }
    }
}
