using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRS.Models;

namespace SRS.Repositories
{
    public interface IStudentRepository
    {
        bool InsertStudent(tblStudent student);
        List<tblStudent> FetchAllStudents();
        tblStudent FetchStudentDetails(int c_studentid);
        bool UpdateExistingStudent(tblStudent student);
        bool DeleteStudentDetails(int c_studentid);
        List<SelectListItem> GetAllCourse();
    }
}