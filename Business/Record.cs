using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Record
    {
        public int Id { set; get; }
        public string RecType { set; get; }
        public DateTime Date { set; get; }
        public int Value { set; get; }
        public string AdditionalData { set; get; }
        public int Glucose { set; get; }

    }
}
