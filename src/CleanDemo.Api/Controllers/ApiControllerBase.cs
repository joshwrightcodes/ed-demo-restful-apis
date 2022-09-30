// --------------------------------------------------------------------------------
// <copyright file="ApiControllerBase.cs" company="Josh Wright">
// Copyright 2021 Josh Wright.
// Use of this source code is governed by an MIT-style, license that can be found
// in the LICENSE file or at https://opensource.org/licenses/MIT.
// </copyright>
// --------------------------------------------------------------------------------

using System.Net.Mime;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WrightCodes.CleanDemo.Api.Controllers;

/// <summary>
/// Base Api Controller.
/// <para>
/// Handle shared dependencies such as Mediator.
/// </para>
/// </summary>
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[Route("[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private IMapper mapper;
    private ISender mediator;

    /// <summary>
    /// Gets the Mediator Service.
    /// </summary>
    protected ISender Mediator
        => mediator ??= HttpContext.RequestServices.GetService<ISender>();

    /// <summary>
    /// Gets the Mapper Service.
    /// </summary>
    protected IMapper Mapper
        => mapper ??= HttpContext.RequestServices.GetService<IMapper>();
}