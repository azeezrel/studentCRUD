﻿namespace studentCRUD.Api.Interface
{
    public interface IModule
    {
        IServiceCollection RegisterModule (IServiceCollection services);

        IEndpointRouteBuilder MapEndpoints (IEndpointRouteBuilder endpoints);
    }
}
