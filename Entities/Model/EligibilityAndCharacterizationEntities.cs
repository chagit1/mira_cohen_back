using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities 
{
    public class EligibilityAndCharacterizationEntities : StudentEntities
    {
        public byte[] Diagnosis { get; set; }
        public byte[] MedicalDocuments { get; set; }
        public bool SyncWithDiagnosis { get; set; }
        public bool ManagerSignature { get; set; }
        public bool TeacherSignature { get; set; }
        public bool SupervisorSignature { get; set; }
        public bool UploadedToShiluvit { get; set; }
        public ParentReportEntities ParentReport { get; set; }
        public TeacherReportEntities TeacherReport { get; set; }

        public EligibilityAndCharacterizationEntities(TeacherReportEntities teacherReport, ParentReportEntities parentReport,
            bool uploed, bool syncWithDiagnosis, bool managerSignature, bool teacherSignature, bool supervisorSignature)
        {
            this.ParentReport = parentReport;
            this.TeacherReport = teacherReport;
            this.ManagerSignature = managerSignature;
            this.TeacherSignature = teacherSignature;
            this.SupervisorSignature = supervisorSignature;
            this.ManagerSignature = managerSignature;
            this.SyncWithDiagnosis = syncWithDiagnosis;
            this.UploadedToShiluvit = uploed;

        }
    }
}
