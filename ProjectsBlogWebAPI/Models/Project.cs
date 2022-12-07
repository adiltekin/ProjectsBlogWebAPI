using System.ComponentModel.DataAnnotations;

namespace ProjectsBlogWebAPI.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDetail { get; set; }
        public string? ProjectContent { get; set; }
        public string? ImgName { get; set; }
        public string? ImgUrl { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
