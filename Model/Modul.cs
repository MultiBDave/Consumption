using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Consumption_Meter.Model
{
    public class Modul
    {
        [Required]
        [StringLength(65, ErrorMessage = "Name length can't be more than 65.")]
        public string Id { get; set; } = string.Empty;
        [Required]
        [StringLength(65, ErrorMessage = "Name length can't be more than 65.")]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(65, ErrorMessage = "Description length can't be more than 65.")]        
        public string Description { get; set; } = string.Empty;
        
        [StringLength(65, ErrorMessage = "Icon length can't be more than 65.")]        
        public string Icon { get; set; } = string.Empty;
        
        [StringLength(100, ErrorMessage = "CustomResPath length can't be more than 65.")]
        public string CustomResPath { get; set; } = string.Empty;
        public bool Hidden { get; set; } = false;
        public List<string> RelatedComponentPaths { get; set; } = new();
        
        [JsonIgnore]
        public string RelatedComponentStr { get; set; } = string.Empty;
        
        public bool DefaultType { get; set; } = false;
       

    }
}
