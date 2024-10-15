

using System.Text.Json.Serialization;

namespace InterviewHelper.Business.DTOs { 
    public class UserAuth {
    public string UserName { get; set; }
    public string UserPassword { get; set; }

        [JsonIgnore]

        public bool IsActive { get; set; }
} 
}
