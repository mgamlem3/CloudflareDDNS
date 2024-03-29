using System.ComponentModel.DataAnnotations;

namespace CloudflareDDNS.CloudlfareApi.Attributes;

public sealed class DnsRecordType : ValidationAttribute
{
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		if (validationContext is null)
			return new ValidationResult("Error getting validation context");

		var objectInstance = (string) validationContext.ObjectInstance;

		var match = CloudflareDDNS.DnsRecordType.GetAllTypes().Any(x => x == objectInstance.ToUpperInvariant());

		if (match)
			return ValidationResult.Success;

		return new ValidationResult("Not a valid DNS record type");
	}
}
