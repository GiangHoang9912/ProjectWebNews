using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class NewsTypes
    {

        public int TypeID { get; set; }
        public string TypeName { get; set; }

        public NewsTypes(int typeID, string typeName)
        {
            this.TypeID = typeID;
            this.TypeName = typeName;
        }
    }
    public class TypeList
    {
        public static List<NewsTypes> GetAllType()
        {
            List<NewsTypes> TypeList = new List<NewsTypes>();
            DataTable dt = Project.Data.TypeNewsDAO.GetAllType();
            foreach (DataRow dr in dt.Rows)
            {
                NewsTypes type = new NewsTypes(
                        Convert.ToInt32(dr["TypeID"]),
                        dr["TypeName"].ToString()
                    );
                TypeList.Add(type);
            }
            return TypeList;
        }
    }
}
