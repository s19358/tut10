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

        public string addDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public string deleteDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public Doctor getDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> getDoctors()
        {
            throw new NotImplementedException();
        }

        public string modifyDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
