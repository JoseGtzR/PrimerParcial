using System.Data.Entity;

namespace Personal.Models
{
    using System.Data.Entity;
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Personal.Models.PersonalData> PersonalDatas { get; set; }
    }
}