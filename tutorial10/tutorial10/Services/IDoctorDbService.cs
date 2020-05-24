using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial10.Models;

namespace tutorial10.Services
{
    public interface IDoctorDbService
    {

        IQueryable getDoctors();
        IQueryable getDoctor(int id);
        string addDoctor(Doctor doctor);
        string modifyDoctor(Doctor doctor);
        string deleteDoctor(int id);



    }
}
