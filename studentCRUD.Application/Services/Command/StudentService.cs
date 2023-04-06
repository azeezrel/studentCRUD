using studentCRUD.Application.DTOS;
using studentCRUD.Domain.Data;
using studentCRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentCRUD.Application.Services.Command;

public class StudentService : IStudentService
{
    public readonly ApplicationDbContext _context;

    public StudentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MainResponse> AddStudent(StudentDTO studentDTO)
    {
        var response = new MainResponse();

        try
        {
            if (_context.Students.Any(f => f.Email == studentDTO.Email.ToLower()))
            {
                response.ErrorMessage = "The student with the same email already exists";
                response.IsSuccess = false;
            }
            else
            {
                _context.Add(new Student
                {
                    Email = studentDTO.Email,
                    Address = studentDTO.Address,
                    FirstName = studentDTO.FirstName,
                    LastName = studentDTO.LastName,
                    Gender = studentDTO.Gender,
                });

                await _context.SaveChangesAsync();

                response.IsSuccess = true;
                response.Content = "Student Added Successfully";
            }
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
            response.IsSuccess = false;
        }

        return response;
    }

    public async Task<MainResponse> EditStudent(StudentDTO studentDTO, long studentId)
    {
        var response = new MainResponse();

        try
        {
            var student = _context.Students.Where(f => f.Id == studentId).FirstOrDefault();
            if (student != null)
            {
                student.Address = studentDTO.Address;
                student.FirstName = studentDTO.FirstName;
                student.LastName = studentDTO.LastName;
                student.Gender = studentDTO.Gender;
                student.Email = studentDTO.Email;

                await _context.SaveChangesAsync();

                response.IsSuccess = true;
                response.Content = "Student Updated Successfully";
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

    public async Task<MainResponse> DeleteStudent(long studentId)
    {
        var response = new MainResponse();

        try
        {
            var student = _context.Students.Where(f => f.Id == studentId).FirstOrDefault();
            if (student != null)
            {
                _context.Students.Remove(student);

                await _context.SaveChangesAsync();

                response.IsSuccess = true;
                response.Content = "Student Deleted Successfully";
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Student Not Found";
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
