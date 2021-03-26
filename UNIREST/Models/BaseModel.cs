// <copyright file="BaseModel.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace UNIREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using UNIREST.Utilities;
    using Newtonsoft.Json;

    /// <summary>
    /// BaseModel.
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Gets or sets a dictionary holding all the additional properties.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties { get; set; }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Additional Properties: {ApiHelper.JsonSerialize(AdditionalProperties)}");
        }
    }
}