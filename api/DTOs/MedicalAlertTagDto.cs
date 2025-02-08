namespace api.DTOs
{
    public record MedicalAlertTagDto(
        Guid Id,
        string FullName,
        DateTime DateOfBirth,
        string MedicalConditions,
        string Allergies, 
        string Medications,
        string EmergencyContactName,
        string EmergencyContactPhone
        );

}
