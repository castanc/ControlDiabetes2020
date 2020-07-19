using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Minutes
    {
        public int Hour { set; get; }
        public int Min { set; get; }
        public int Mins
        {
            get
            {
                return Hour * 60 + Min;
            }
        }

        public Minutes()
        {

        }

        public Minutes(string hour)
        {
            var hr = hour.Split(':');
            Hour = Convert.ToInt32(hr[0]);
            Min = Convert.ToInt32(hr[1]);

        }
        public Minutes(string[] hr)
        {
            Hour = Convert.ToInt32(hr[0]);
            Min = Convert.ToInt32(hr[1]);
        }
    }
}
