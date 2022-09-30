using MediatR;

namespace WrightCodes.CleanDemo.Application.Courses.Queries.GetCourse;

/// <summary>
/// Request for retrieving a particular course by id.
/// </summary>
public class GetCourseQuery : IRequest<Course>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetCourseQuery"/> class.
    /// </summary>
    public GetCourseQuery()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetCourseQuery"/> class with a particular id.
    /// </summary>
    /// <param name="id">
    /// Id of the course to retrieve.
    /// </param>
    public GetCourseQuery(Guid id)
        : this()
        => Id = id;

    /// <summary>
    /// Gets or sets the identifier of the course to be retrieved.
    /// </summary>
    public Guid Id { get; set; }
}