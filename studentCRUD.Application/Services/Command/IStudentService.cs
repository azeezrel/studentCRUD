using studentCRUD.Application.DTOS;
using studentCRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentCRUD.Application.Services.Command;

public interface IStudentService
{
    Task<MainResponse> AddStudent(StudentDTO studentDTO);
    Task<MainResponse> EditStudent(StudentDTO studentDTO, long studentId);
    Task<MainResponse> DeleteStudent(long studentId);
}
