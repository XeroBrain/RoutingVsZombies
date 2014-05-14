using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtgVsZmbs.Data
{
    public class Guide
    {
        public int Id;
        public int Modul;
        public String Summary;
        public String Title;
        public String Text;

        public Guide(int id,int modul,String summary,String title,String text)
        {
            Id = id;
            Modul = modul;
            Summary = summary;
            Title = title;
            Text = text;
        }
    }
}
