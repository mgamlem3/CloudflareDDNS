using System.ComponentModel.DataAnnotations;

namespace CloudflareDDNS.CloudlfareApi.Attributes;

public sealed class TTL : ValidationAttribute
{
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		if (validationContext is null)
			return new ValidationResult("Error getting validation context");

		var objectInstance = (uint) validationContext.ObjectInstance;

		if (objectInstance == 1)
			return ValidationResult.Success;
		else if ((60 <= objectInstance) && (objectInstance <= 86400))
			return ValidationResult.Success;
		else
			return new ValidationResult("Must be 1 or between 60 and 86400");
	}
}
