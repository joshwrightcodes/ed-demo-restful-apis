// --------------------------------------------------------------------------------
// <copyright file="ValidationException.cs" company="Josh Wright">
// Copyright 2021 Josh Wright.
// Use of this source code is governed by an MIT-style, license that can be found
// in the LICENSE file or at https://opensource.org/licenses/MIT.
// </copyright>
// --------------------------------------------------------------------------------

using System.Runtime.Serialization;
using FluentValidation.Results;

namespace WrightCodes.CleanDemo.Application.Common.Exceptions;

/// <summary>
/// Throw when user attempts to send a invalid request.
/// </summary>
[Serializable]
public class ValidationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException" /> class.
    /// </summary>
    public ValidationException()
        : base("One or more validation failures have occurred.")
        => Errors = new Dictionary<string, string[]>();

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException" /> class with a collection of validation
    /// failures that caused the exception..
    /// </summary>
    /// <param name="failures">Validation errors that caused the exception.</param>
    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
        => Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(
                failureGroup => failureGroup.Key,
                failureGroup => failureGroup.ToArray());

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException" /> class with serialized data.
    /// </summary>
    /// <param name="info">
    /// The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.
    /// </param>
    /// <param name="context">
    /// The <see cref="SerializationInfo" /> that contains contextual information about the source or destination.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="info" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="SerializationException">
    /// Thrown when the class name is <c>null</c> or <see cref="Exception.HResult" /> is zero (0).
    /// </exception>
    protected ValidationException(SerializationInfo info, StreamingContext context)
        : base(info, context) =>
        Errors = (IDictionary<string, string[]>)info.GetValue(nameof(Errors), typeof(IDictionary<string, string[]>));

    /// <summary>
    /// Gets a collection of validation errors associated with the Exception.
    /// </summary>
    public IDictionary<string, string[]> Errors { get; }

    /// <summary>
    /// Sets the  <see cref="SerializationInfo"/> with information about the exception.
    /// </summary>
    /// <param name="info">
    /// The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.
    /// </param>
    /// <param name="context">
    /// The <see cref="StreamingContext"/> that contains contextual information about the source or destination.
    /// </param>
    /// <exception cref="">
    /// Thrown when <paramref name="info" /> is <c>null</c>.
    /// </exception>
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        ArgumentNullException.ThrowIfNull(info);

        info.AddValue(nameof(Errors), this.Errors, typeof(IDictionary<string, string[]>));

        base.GetObjectData(info, context);
    }
}