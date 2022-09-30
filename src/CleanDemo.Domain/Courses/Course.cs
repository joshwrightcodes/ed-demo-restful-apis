// --------------------------------------------------------------------------------
// <copyright file="Course.cs" company="Josh Wright">
// Copyright 2021 Josh Wright.
// Use of this source code is governed by an MIT-style, license that can be found
// in the LICENSE file or at https://opensource.org/licenses/MIT.
// </copyright>
// --------------------------------------------------------------------------------

using WrightCodes.CleanDemo.Domain.Common;

namespace WrightCodes.CleanDemo.Domain.Courses;

/// <summary>
/// Course entity.
/// </summary>
public record Course : AuditableEntity, IHasDomainEvent
{
    /// <summary>
    /// Gets or sets the unique identifier of a <see cref="Course"/> object.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of a <see cref="Course"/> in the platform.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the status of a <see cref="Course"/> within the platform.
    /// </summary>
    public CourseStatus Status { get; set; } = CourseStatus.Draft;

    /// <summary>
    /// Gets a collection of domain events relating to <see cref="Course"/> entity.
    /// </summary>
    public List<DomainEvent> DomainEvents { get; } = new ();
}