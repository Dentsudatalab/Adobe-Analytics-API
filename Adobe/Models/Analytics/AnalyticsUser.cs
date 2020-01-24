namespace Adobe.Models.Analytics
{
    using Newtonsoft.Json;

    public class AnalyticsUser
    {
        [JsonProperty(PropertyName = "companyid")]
        public int? Companyid { get; set; }

        [JsonProperty(PropertyName = "loginId")]
        public int? LoginId { get; set; }

        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }

        [JsonProperty(PropertyName = "changePassword")]
        public bool? ChangePassword { get; set; }

        [JsonProperty(PropertyName = "createDate")]
        public System.DateTime? CreateDate { get; set; }

        [JsonProperty(PropertyName = "disabled")]
        public bool? Disabled { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "fullName")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "imsUserId")]
        public string ImsUserId { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "lastAccess")]
        public System.DateTime? LastAccess { get; set; }

        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "tempLoginEnd")]
        public System.DateTime? TempLoginEnd { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}