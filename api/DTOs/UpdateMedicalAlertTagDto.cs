namespace api.DTOs
{
    public record UpdateMedicalAlertTagDto(
        string FullName,
        DateTime DateOfBirth,
        string MedicalConditions,
        string Allergies,
        string Medications,
        string EmergencyContactName,
        string EmergencyContactPhone
        );

}
