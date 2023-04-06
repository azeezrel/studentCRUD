using Microsoft.EntityFrameworkCore;
using studentCRUD.Domain.Data;
using studentCRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentCRUD.Application.Services.Query;

public class StudentQueryService : IStudentQueryService
{
    public readonly ApplicationDbContext _context;

    public StudentQueryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MainResponse> GetAll()
    {
        var response = new MainResponse();

        try
        {
            response.Content = await _context.Students.ToListAsync();
            response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.IsSuccess = false;
        }

        return response;
    }

    public async Task<MainResponse> GetById(long studentId)
    {
        var response = new MainResponse();

        try
        {
            var student = _context.Students.Where(f => f.Id == studentId).FirstOrDefault();

            if (student != null)
            {
                response.Content = student;
                response.IsSuccess = true;
            }
            else
            {
                response.ErrorMessage = "Student Not Found";
                response.IsSuccess = false;
            }    
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.IsSuccess = false;
        }

        return response;
    }
}
