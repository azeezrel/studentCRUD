using studentCRUD.Api.Interface;
using studentCRUD.Application.DTOS;
using studentCRUD.Application.Services.Command;
using studentCRUD.Application.Services.Query;

namespace studentCRUD.Api.ModuleEndpoints
{
    public class Endpoints : IModule
    {
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            #region Add new Student
            endpoints
                .MapPost
                (
                    "api/v1/user/add", async (IStudentService _student, StudentDTO model) =>
                    {
                        var result = await _student.AddStudent(model);
                        return Results.Ok(result);
                    }
                );
            #endregion

            endpoints
                .MapPut
                (
                    "api/v1/user/edit", async (IStudentService _student, StudentDTO model, long id) =>
                    {
                        var result = await _student.EditStudent(model, id);
                        return Results.Ok(result);
                    }
                );

            endpoints
                .MapDelete
                (
                    "api/v1/user/delete", async (IStudentService _student, long id) =>
                    {
                        var result = await _student.DeleteStudent(id);
                        return Results.Ok(result);
                    }
                );

            endpoints
                .MapGet
                (
                    "api/v1/users", async (IStudentQueryService _students) =>
                    {
                        var result = await _students.GetAll();
                        return Results.Ok(result);
                    }
                );

            endpoints
                .MapGet
                (
                    "api/v1/user/view", async (IStudentQueryService _student, long id) =>
                    {
                        var result = await _student.GetById(id);
                        return Results.Ok(result);
                    }
                );

            return endpoints;
        }

        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentQueryService, StudentQueryService>();

            return services;
        }
    }
}
