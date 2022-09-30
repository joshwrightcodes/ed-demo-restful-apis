// --------------------------------------------------------------------------------
// <copyright file="NotFoundException.cs" company="Josh Wright">
// Copyright 2021 Josh Wright.
// Use of this source code is governed by an MIT-style, license that can be found
// in the LICENSE file or at https://opensource.org/licenses/MIT.
// </copyright>
// --------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace WrightCodes.CleanDemo.Application.Common.Exceptions;

/// <summary>
/// Thrown when Entity cannot be located.
/// </summary>
[Serializable]
public sealed class NotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException" /> class with the name and id of the entity that
    /// could not be found..
    /// </summary>
    /// <param name="name">
    /// Name of the entity type that could not be found.
    /// </param>
    /// <param name="key">
    /// Identifier for the entity that could not be found.
    /// </param>
    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException" /> class with serialized data.
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
    private NotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}