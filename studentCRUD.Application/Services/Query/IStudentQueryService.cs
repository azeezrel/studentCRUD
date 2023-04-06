using studentCRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentCRUD.Application.Services.Query;

public interface IStudentQueryService
{
    Task<MainResponse> GetAll();
    Task<MainResponse> GetById(long studentId);
}
