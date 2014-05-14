using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RtgVsZmbs.Data
{
    public class Guides
    {
        private List<Guide> GuideList;
        public Boolean LoadGuides()
        {
            GuideList = new List<Guide>();
            using (SqlConnection connection = new SqlConnection("Data Source=85.183.21.62,1433;" + "Initial Catalog=RoutingVsZombie;" + "User id=RVZLogin;" + "Password=ZombieNation21!;"))
            {
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("Select guiid,guiigsid,guiModul,guiSummary,guiTitle,guiText from Guides", connection);
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count < 1) return false;

              foreach(DataRow guide in dataTable.Rows)
              {
                  GuideList.Add(new Guide((int)guide["guiid"], (int)guide["guiModul"], (String)guide["guiSummary"], (String)guide["guiTitle"], (String)guide["guiText"]));
              }              
            }
            return true;
        }
    }
}
