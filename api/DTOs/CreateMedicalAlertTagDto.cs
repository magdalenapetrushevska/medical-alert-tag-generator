namespace api.DTOs
{

    public record CreateMedicalAlertTagDto(
        string FullName,
        DateTime DateOfBirth,
        string MedicalConditions,
        string Allergies,
        string Medications,
        string EmergencyContactName,
        string EmergencyContactPhone
        );

}
