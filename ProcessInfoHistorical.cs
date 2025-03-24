using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCSV
{
    [Table("IoTUtility_T_ProcessInfo_Historical")]
    public class ProcessInfoHistorical
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(20)]
        public string MachineCode { get; set; }

        public DateTime? Date { get; set; }

        public TimeSpan? Time { get; set; }

        [MaxLength(50)]
        public string Column01 { get; set; }
        [MaxLength(50)]
        public string Column02 { get; set; }
        [MaxLength(50)]
        public string Column03 { get; set; }
        [MaxLength(50)]
        public string Column04 { get; set; }
        [MaxLength(50)]
        public string Column05 { get; set; }
        [MaxLength(50)]
        public string Column06 { get; set; }
        [MaxLength(50)]
        public string Column07 { get; set; }
        [MaxLength(50)]
        public string Column08 { get; set; }
        [MaxLength(50)]
        public string Column09 { get; set; }
        [MaxLength(50)]
        public string Column10 { get; set; }

        [MaxLength(50)]
        public string Column11 { get; set; }
        [MaxLength(50)]
        public string Column12 { get; set; }
        [MaxLength(50)]
        public string Column13 { get; set; }
        [MaxLength(50)]
        public string Column14 { get; set; }
        [MaxLength(50)]
        public string Column15 { get; set; }
        [MaxLength(50)]
        public string Column16 { get; set; }
        [MaxLength(50)]
        public string Column17 { get; set; }
        [MaxLength(50)]
        public string Column18 { get; set; }
        [MaxLength(50)]
        public string Column19 { get; set; }
        [MaxLength(50)]
        public string Column20 { get; set; }

        [MaxLength(50)]
        public string Column21 { get; set; }
        [MaxLength(50)]
        public string Column22 { get; set; }
        [MaxLength(50)]
        public string Column23 { get; set; }
        [MaxLength(50)]
        public string Column24 { get; set; }
        [MaxLength(50)]
        public string Column25 { get; set; }
        [MaxLength(50)]
        public string Column26 { get; set; }
        [MaxLength(50)]
        public string Column27 { get; set; }
        [MaxLength(50)]
        public string Column28 { get; set; }
        [MaxLength(50)]
        public string Column29 { get; set; }
        [MaxLength(50)]
        public string Column30 { get; set; }

        [MaxLength(50)]
        public string Column31 { get; set; }
        [MaxLength(50)]
        public string Column32 { get; set; }
        [MaxLength(50)]
        public string Column33 { get; set; }
        [MaxLength(50)]
        public string Column34 { get; set; }
        [MaxLength(50)]
        public string Column35 { get; set; }
        [MaxLength(50)]
        public string Column36 { get; set; }
        [MaxLength(50)]
        public string Column37 { get; set; }
        [MaxLength(50)]
        public string Column38 { get; set; }
        [MaxLength(50)]
        public string Column39 { get; set; }
        [MaxLength(50)]
        public string Column40 { get; set; }

        [MaxLength(50)]
        public string Column41 { get; set; }
        [MaxLength(50)]
        public string Column42 { get; set; }
        [MaxLength(50)]
        public string Column43 { get; set; }
        [MaxLength(50)]
        public string Column44 { get; set; }
        [MaxLength(50)]
        public string Column45 { get; set; }
        [MaxLength(50)]
        public string Column46 { get; set; }
        [MaxLength(50)]
        public string Column47 { get; set; }
        [MaxLength(50)]
        public string Column48 { get; set; }
        [MaxLength(50)]
        public string Column49 { get; set; }
        [MaxLength(50)]
        public string Column50 { get; set; }

        [MaxLength(50)]
        public string FormulatedColumn01 { get; set; }
        [MaxLength(50)]
        public string FormulatedColumn02 { get; set; }
        [MaxLength(50)]
        public string FormulatedColumn03 { get; set; }
        [MaxLength(50)]
        public string FormulatedColumn04 { get; set; }
        [MaxLength(50)]
        public string FormulatedColumn05 { get; set; }
        [MaxLength(50)]
        public string FormulatedColumn06 { get; set; }
        [MaxLength(50)]
        public string FormulatedColumn07 { get; set; }
        [MaxLength(50)]
        public string FormulatedColumn08 { get; set; }
        [MaxLength(50)]
        public string FormulatedColumn09 { get; set; }
        [MaxLength(50)]
        public string FormulatedColumn10 { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; }
    }
}
