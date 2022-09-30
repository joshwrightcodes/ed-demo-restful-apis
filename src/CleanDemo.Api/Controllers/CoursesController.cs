// --------------------------------------------------------------------------------
// <copyright file="CoursesController.cs" company="Josh Wright">
// Copyright 2021 Josh Wright.
// Use of this source code is governed by an MIT-style, license that can be found
// in the LICENSE file or at https://opensource.org/licenses/MIT.
// </copyright>
// --------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Courses = WrightCodes.CleanDemo.Application.Courses;

namespace WrightCodes.CleanDemo.Api.Controllers;

public class CoursesController : ApiControllerBase
{
    [HttpGet]
    public async Task<string> GetCourses(CancellationToken cancellationToken = default)
        => await Mediator
            .Send(new Courses.Queries.GetCourses.GetCoursesQuery(), cancellationToken)
            .ConfigureAwait(false);

    [HttpGet("{id:guid}")]
    public async Task<Courses.Queries.GetCourse.Course> GetCourse(Guid id, CancellationToken cancellationToken = default)
        => await Mediator
            .Send(new Courses.Queries.GetCourse.GetCourseQuery(id), cancellationToken)
            .ConfigureAwait(false);
}