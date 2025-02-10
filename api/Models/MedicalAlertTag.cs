using Microsoft.EntityFrameworkCore.Metadata;
using System.Text;

namespace api.Models
{
    public sealed class MedicalAlertTag : EntityBase
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string MedicalConditions { get; set; } = string.Empty;
        public string Allergies { get; set; } = string.Empty;
        public string Medications { get; set; } = string.Empty;
        public string EmergencyContactName { get; set; } = string.Empty;
        public string EmergencyContactPhone { get; set; } = string.Empty;

        private MedicalAlertTag(string fullName, DateTime dateOfBirth, string medicalConditions, string allergies, string medications, string emergencyContactName, string emergencyContactPhone)
        {
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            MedicalConditions = medicalConditions;
            Allergies = allergies;
            Medications = medications;
            EmergencyContactName = emergencyContactName;
            EmergencyContactPhone = emergencyContactPhone;  
        }

        public static MedicalAlertTag Create(
            string fullName,
            DateTime dateOfBirth,
            string medicalConditions,
            string allergies,
            string medications,
            string emergencyContactName,
            string emergencyContactPhone)
        {
            ValidateInputs(fullName, dateOfBirth, medicalConditions, emergencyContactName, emergencyContactPhone);
            return new MedicalAlertTag(fullName, dateOfBirth, medicalConditions, allergies, medications, emergencyContactName, emergencyContactPhone);
        }

        public void Update(
            string fullName,
            DateTime dateOfBirth,
            string medicalConditions,
            string allergies,
            string medications,
            string emergencyContactName,
            string emergencyContactPhone)
        {
            ValidateInputs(fullName, dateOfBirth, medicalConditions, emergencyContactName, emergencyContactPhone);

            FullName = fullName;
            DateOfBirth = dateOfBirth;
            MedicalConditions = medicalConditions;
            Allergies = allergies;
            Medications = medications;
            EmergencyContactName = emergencyContactName;
            EmergencyContactPhone = emergencyContactPhone;

            UpdateLastModified();
        }

        private static void ValidateInputs(
            string fullName,
            DateTime dateOfBirth,
            string medicalConditions,
            string emergencyContactName,
            string emergencyContactPhone)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Title cannot be null or empty.", nameof(fullName));

            if (string.IsNullOrWhiteSpace(medicalConditions))
                throw new ArgumentException("Medical conditions cannot be null or empty.", nameof(medicalConditions));

            if (dateOfBirth > DateTimeOffset.UtcNow)
                throw new ArgumentException("Date of birth cannot be in the future.", nameof(dateOfBirth));

            if (string.IsNullOrWhiteSpace(emergencyContactName))
                throw new ArgumentException("Title cannot be null or empty.", nameof(emergencyContactName));

            if (string.IsNullOrWhiteSpace(emergencyContactPhone))
                throw new ArgumentException("Title cannot be null or empty.", nameof(emergencyContactPhone));

        }


    }
}
