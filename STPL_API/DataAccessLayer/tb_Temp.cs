using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace STPL_API.DataAccessLayer
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tb_Temp")]
    public class tb_Temp : BaseModel
    {    
        public int Id { get; set; }

        [StringLength(20)]
        public string Temperature { get; set; }

        [StringLength(20)]
        public string Humidity { get; set; }

        [StringLength(20)]
        public string Occupancy { get; set; }
    }
}
