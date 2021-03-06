﻿using IdentityManager.Domain;
using IdentityManager.Models;

namespace IdentityManager.Extensions
{
    public static class ApiResourceModelExtensions
    {
        /// <summary>
        /// Create a ApiResourceEntity from a ApiResourceModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ApiResourceEntity FromModel(this ApiResourceModel model)
        {
            return new ApiResourceEntity
            {
                Description = model.Description,
                DisplayName = model.DisplayName,
                Enabled = model.Enabled,
                Name = model.Name,
                ShowInDiscoveryDocument = model.ShowInDiscoveryDocument,
                Properties = model.Properties,
                Scopes = model.Scopes,
                UserClaims = model.UserClaims
            };
        }

        /// <summary>
        /// Convert a ApiResourceEntity to a ApiResourceModel
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ApiResourceModel ToModel(this ApiResourceEntity entity)
        {
            return new ApiResourceModel
            {
                Description = entity.Description,
                DisplayName = entity.DisplayName,
                Enabled = entity.Enabled,
                Name = entity.Name,
                ShowInDiscoveryDocument = entity.ShowInDiscoveryDocument,
                Properties = entity.Properties,
                Scopes = entity.Scopes,
                UserClaims = entity.UserClaims
            };
        }
    }
}
