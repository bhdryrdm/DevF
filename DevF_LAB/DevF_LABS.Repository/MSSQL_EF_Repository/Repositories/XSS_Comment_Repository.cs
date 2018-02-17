using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst;
using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.XSS;
using DevF_LABS.Repository.MSSQL_EF_Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.Repository.MSSQL_EF_Repository.Repositories
{
    public class XSS_Comment_Repository : MSSQL_BaseRepository<XSS_Comment>, IXSS_Comment_Repository
    {
        public XSS_Comment_Repository(MSSQL_EF_CF_Context context) : base(context)
        {
        }
    }
}
