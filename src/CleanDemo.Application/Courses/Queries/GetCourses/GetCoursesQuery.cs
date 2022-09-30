// --------------------------------------------------------------------------------
// <copyright file="GetCoursesQuery.cs" company="Josh Wright">
// Copyright 2021 Josh Wright.
// Use of this source code is governed by an MIT-style, license that can be found
// in the LICENSE file or at https://opensource.org/licenses/MIT.
// </copyright>
// --------------------------------------------------------------------------------

using MediatR;
using WrightCodes.Demo.RestfulDesign.Application.Common.Queries;

namespace WrightCodes.CleanDemo.Application.Courses.Queries.GetCourses;

public class GetCoursesQuery : PaginatedQuery, IRequest<string>
{
}