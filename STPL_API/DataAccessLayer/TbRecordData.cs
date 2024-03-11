using System.ComponentModel.DataAnnotations;

namespace STPL_API.DataAccessLayer
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tb_recorddata")]
    public class TbRecordData : BaseModel
    {
        [StringLength(20)]
        public string data_type { get; set; }
        public int recordtrans_id { get; set; }

        public bool? IsfullPowerMode { get; set; }
        public bool? IsactivePowerControl { get; set; }
        public int? firmware_Version { get; set; }
        public int? temperature { get; set; }
        public int? humidity { get; set; }
        public int? version { get; set; }        
        [StringLength(45)]
        public string message_type { get; set; }
        public bool? occupancy { get; set; }
        public int? state_changed { get; set; }
       
    }
}
