// --------------------------------------------------------------------------------
// <copyright file="CourseStatus.cs" company="Josh Wright">
// Copyright 2021 Josh Wright.
// Use of this source code is governed by an MIT-style, license that can be found
// in the LICENSE file or at https://opensource.org/licenses/MIT.
// </copyright>
// --------------------------------------------------------------------------------

namespace WrightCodes.CleanDemo.Domain.Courses;

/// <summary>
/// Statuses for a <see cref="Course"/> entity.
/// </summary>
public enum CourseStatus
{
    /// <summary>
    /// Indicates the course is in a draft state and is only available to users with access to the CMS.
    /// </summary>
    Draft = 0,

    /// <summary>
    /// Indicates the course is in a published state and is available to all users of the platform.
    /// </summary>
    Published = 1,

    /// <summary>
    /// Indicates the course has been deleted in the platform and is only available to administrators.
    /// </summary>
    Archived = 2,
}