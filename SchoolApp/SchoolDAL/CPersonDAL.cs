using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolEntities;
using System.Data;
using System.Data.SqlClient;

namespace SchoolDAL
{
    public class CPersonDAL
    {
        public List<CPerson> listar() {
            using (SchoolEntities context = new SchoolEntities()) {
                var query = context.Person.Select(p => new CPerson
                {
                    PersonId = p.PersonID,
                    LastName = p.LastName,
                    FirstName = p.FirstName
                });
                return query.ToList();
            }
        }
    }
}
