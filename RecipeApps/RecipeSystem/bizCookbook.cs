using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizCookbook : bizObject<bizCookbook>
    {

        public List<bizCookbook> Search(int cookbookid, int all)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "@CookbookId", cookbookid);
            SQLUtility.SetParamValue(cmd, "@All", all);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int CookBookId { get; set; }
        public int? StaffId { get; set; }
        public string CookBookName { get; set; } = "";
        public decimal Price { get; set; }
        public int? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? Author { get; set; }
        public int? NumRecipes { get; set; }
    }
}