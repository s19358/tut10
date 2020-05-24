using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial10.Models;

namespace tutorial10.Services
{
    public class SqlServerDoctorDbService : IDoctorDbService
    {

        private readonly DoctorDbContext _context;
        public SqlServerDoctorDbService(DoctorDbContext context)
        {
            _context = context;
        }

    }
}
