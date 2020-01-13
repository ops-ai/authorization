﻿using JsonSubTypes;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using NJsonSchema.Converters;
using PolicyServer.Core.Entities.Requirements;

namespace PolicyServer.Core.Entities
{
    /// <summary>
    /// Authorization requirements base class
    /// </summary>
    [JsonConverter(typeof(JsonInheritanceConverter), "name")]
    [JsonSubtypes.KnownSubType(typeof(AuthenticatedRequirement), "authenticated")]
    public abstract class AuthorizationRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// Unique name of requirement
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Returns the requirement name and class type
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Name}-{GetType()}";
    }
}