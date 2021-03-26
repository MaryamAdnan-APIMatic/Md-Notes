// <copyright file="Note.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace UNIREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using UNIREST;
    using UNIREST.Utilities;

    /// <summary>
    /// Note.
    /// </summary>
    public class Note : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class.
        /// </summary>
        public Note()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="title">title.</param>
        /// <param name="body">body.</param>
        /// <param name="userId">user_id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        public Note(
            long id,
            string title,
            string body,
            long userId,
            string createdAt,
            string updatedAt)
        {
            this.Id = id;
            this.Title = title;
            this.Body = body;
            this.UserId = userId;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Body.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets CreatedAt.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets UpdatedAt.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Note : ({string.Join(", ", toStringOutput)})";
        }

        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {Id}");
            toStringOutput.Add($"Title = {(Title == null ? "null" : Title == string.Empty ? "" : Title)}");
            toStringOutput.Add($"Body = {(Body == null ? "null" : Body == string.Empty ? "" : Body)}");
            toStringOutput.Add($"UserId = {UserId}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"UpdatedAt = {(UpdatedAt == null ? "null" : UpdatedAt == string.Empty ? "" : UpdatedAt)}");

            base.ToString(toStringOutput);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is Note other &&
                Id.Equals(other.Id) &&
                ((Title == null && other.Title == null) || (Title?.Equals(other.Title) == true)) &&
                ((Body == null && other.Body == null) || (Body?.Equals(other.Body) == true)) &&
                UserId.Equals(other.UserId) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((UpdatedAt == null && other.UpdatedAt == null) || (UpdatedAt?.Equals(other.UpdatedAt) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 519070351;
            hashCode += Id.GetHashCode();

            if (Title != null)
            {
               hashCode += Title.GetHashCode();
            }

            if (Body != null)
            {
               hashCode += Body.GetHashCode();
            }
            hashCode += UserId.GetHashCode();

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (UpdatedAt != null)
            {
               hashCode += UpdatedAt.GetHashCode();
            }

            return hashCode;
        }
    }
}