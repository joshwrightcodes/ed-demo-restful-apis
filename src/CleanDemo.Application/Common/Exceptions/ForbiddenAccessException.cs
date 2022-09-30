// --------------------------------------------------------------------------------
// <copyright file="ForbiddenAccessException.cs" company="Josh Wright">
// Copyright 2021 Josh Wright.
// Use of this source code is governed by an MIT-style, license that can be found
// in the LICENSE file or at https://opensource.org/licenses/MIT.
// </copyright>
// --------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace WrightCodes.CleanDemo.Application.Common.Exceptions;

/// <summary>
/// Throw when user attempts to access an unauthorized area.
/// </summary>
[Serializable]
public sealed class ForbiddenAccessException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ForbiddenAccessException" /> class.
    /// </summary>
    public ForbiddenAccessException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ForbiddenAccessException" /> class with serialized data.
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
    private ForbiddenAccessException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}