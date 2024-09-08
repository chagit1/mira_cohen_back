using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EligibilityAndCharacterization : Student
    {
        public virtual ParentReport ParentReport { get; set; } // Navigation property

        public virtual TeacherReport TeacherReport { get; set; } // Navigation property

        public byte[] Diagnosis { get; set; }

        public byte[] MedicalDocuments { get; set; }

        public bool SyncWithDiagnosis { get; set; }

        public bool ManagerSignature { get; set; }

        public bool TeacherSignature { get; set; }

        public bool SupervisorSignature { get; set; }

        public bool UploadedToShiluvit { get; set; }
    }
}
