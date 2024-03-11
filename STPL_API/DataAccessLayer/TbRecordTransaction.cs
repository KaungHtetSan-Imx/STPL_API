using System.ComponentModel.DataAnnotations;

namespace STPL_API.DataAccessLayer
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tb_recordtransaction")]
    public class TbRecordTransaction : BaseModel
    {
        public int trans_id { get; set; }
        [StringLength(20)]
        public string requestor_ip { get; set; }
        public int deviceid { get; set; }
        public DateTime request_timestramp { get; set; }
        public DateTime created_datetime { get; set; }
    }
}
