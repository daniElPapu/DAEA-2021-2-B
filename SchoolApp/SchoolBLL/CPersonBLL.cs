using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolDAL;
using SchoolEntities;

namespace SchoolBLL
{
    public class CPersonBLL
    {
        CPersonDAL personDal = new CPersonDAL();

        public List<CPerson> ListarBLL() {
            return personDal.listar();
        }
    }
}
