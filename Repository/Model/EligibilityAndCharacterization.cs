using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EligibilityAndCharacterization : Student
    {
        [BsonElement("Diagnosis")]
        [BsonIgnoreIfNull]
        public byte[] Diagnosis { get; set; }

        [BsonElement("MedicalDocuments")]
        [BsonIgnoreIfNull]
        public byte[] MedicalDocuments { get; set; }

        [BsonElement("SyncWithDiagnosis")]
        [BsonIgnoreIfNull]
        public bool SyncWithDiagnosis { get; set; }

        [BsonElement("ManagerSignature")]
        [BsonIgnoreIfNull]
        public bool ManagerSignature { get; set; }

        [BsonElement("TeacherSignature")]
        [BsonIgnoreIfNull]
        public bool TeacherSignature { get; set; }

        [BsonElement("SupervisorSignature")]
        [BsonIgnoreIfNull]
        public bool SupervisorSignature { get; set; }

        [BsonElement("UploadedToShiluvit")]
        [BsonIgnoreIfNull]
        public bool UploadedToShiluvit { get; set; }

        [BsonElement("ParentReport")]
        [BsonIgnoreIfNull]
        public ParentReport ParentReport { get; set; }

        [BsonElement("TeacherReport")]
        [BsonIgnoreIfNull]
        public TeacherReport TeacherReport { get; set; }
        public EligibilityAndCharacterization(TeacherReport teacherReport, ParentReport parentReport,
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
