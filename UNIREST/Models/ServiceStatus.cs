// <copyright file="ServiceStatus.cs" company="APIMatic">
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
    /// ServiceStatus.
    /// </summary>
    public class ServiceStatus : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceStatus"/> class.
        /// </summary>
        public ServiceStatus()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceStatus"/> class.
        /// </summary>
        /// <param name="app">app.</param>
        /// <param name="moto">moto.</param>
        /// <param name="notes">notes.</param>
        /// <param name="users">users.</param>
        /// <param name="time">time.</param>
        /// <param name="os">os.</param>
        /// <param name="phpVersion">php_version.</param>
        /// <param name="status">status.</param>
        public ServiceStatus(
            string app,
            string moto,
            int notes,
            int users,
            string time,
            string os,
            string phpVersion,
            string status)
        {
            this.App = app;
            this.Moto = moto;
            this.Notes = notes;
            this.Users = users;
            this.Time = time;
            this.Os = os;
            this.PhpVersion = phpVersion;
            this.Status = status;
        }

        /// <summary>
        /// Gets or sets App.
        /// </summary>
        [JsonProperty("app")]
        public string App { get; set; }

        /// <summary>
        /// Gets or sets Moto.
        /// </summary>
        [JsonProperty("moto")]
        public string Moto { get; set; }

        /// <summary>
        /// Gets or sets Notes.
        /// </summary>
        [JsonProperty("notes")]
        public int Notes { get; set; }

        /// <summary>
        /// Gets or sets Users.
        /// </summary>
        [JsonProperty("users")]
        public int Users { get; set; }

        /// <summary>
        /// Gets or sets Time.
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets Os.
        /// </summary>
        [JsonProperty("os")]
        public string Os { get; set; }

        /// <summary>
        /// Gets or sets PhpVersion.
        /// </summary>
        [JsonProperty("php_version")]
        public string PhpVersion { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ServiceStatus : ({string.Join(", ", toStringOutput)})";
        }

        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"App = {(App == null ? "null" : App == string.Empty ? "" : App)}");
            toStringOutput.Add($"Moto = {(Moto == null ? "null" : Moto == string.Empty ? "" : Moto)}");
            toStringOutput.Add($"Notes = {Notes}");
            toStringOutput.Add($"Users = {Users}");
            toStringOutput.Add($"Time = {(Time == null ? "null" : Time == string.Empty ? "" : Time)}");
            toStringOutput.Add($"Os = {(Os == null ? "null" : Os == string.Empty ? "" : Os)}");
            toStringOutput.Add($"PhpVersion = {(PhpVersion == null ? "null" : PhpVersion == string.Empty ? "" : PhpVersion)}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status == string.Empty ? "" : Status)}");

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

            return obj is ServiceStatus other &&
                ((App == null && other.App == null) || (App?.Equals(other.App) == true)) &&
                ((Moto == null && other.Moto == null) || (Moto?.Equals(other.Moto) == true)) &&
                Notes.Equals(other.Notes) &&
                Users.Equals(other.Users) &&
                ((Time == null && other.Time == null) || (Time?.Equals(other.Time) == true)) &&
                ((Os == null && other.Os == null) || (Os?.Equals(other.Os) == true)) &&
                ((PhpVersion == null && other.PhpVersion == null) || (PhpVersion?.Equals(other.PhpVersion) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1328209612;

            if (App != null)
            {
               hashCode += App.GetHashCode();
            }

            if (Moto != null)
            {
               hashCode += Moto.GetHashCode();
            }
            hashCode += Notes.GetHashCode();
            hashCode += Users.GetHashCode();

            if (Time != null)
            {
               hashCode += Time.GetHashCode();
            }

            if (Os != null)
            {
               hashCode += Os.GetHashCode();
            }

            if (PhpVersion != null)
            {
               hashCode += PhpVersion.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            return hashCode;
        }
    }
}