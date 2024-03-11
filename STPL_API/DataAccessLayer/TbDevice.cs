using System.ComponentModel.DataAnnotations;

namespace STPL_API.DataAccessLayer
{
    
    [System.ComponentModel.DataAnnotations.Schema.Table("tb_device")]
    public class TbDevice : BaseModel
    {
        public int id { get; set; }
        [StringLength(20)]
        public string device_id { get; set; }

        [StringLength(45)]
        public string device_type { get; set; }

        [StringLength(45)]
        public string device_name { get; set; }

        [StringLength(45)]
        public string group_id { get; set; }
        [StringLength(45)]
        public string modifiedby { get; set; }
        public DateTime modifiedon { get; set; }
    }
}
