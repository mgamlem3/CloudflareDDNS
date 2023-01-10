using Mg3.Utility.StringUtility;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CloudflareDDNS.CloudlfareApi.Attributes;

public sealed class IpAddress : ValidationAttribute
{
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		if (validationContext is null)
			return new ValidationResult("Error getting validation context");

		var objectInstance = (string) validationContext.ObjectInstance;

		if (objectInstance.IsNullOrWhitespace())
			return new ValidationResult("Unable to get object instance");
		if (!Regex.IsMatch(objectInstance, c_ipPattern, RegexOptions.CultureInvariant, new TimeSpan(0, 0, 1)))
			return new ValidationResult("Not a valid IP address");
		if (!IpAddressHasValidSegments(objectInstance))
			return new ValidationResult("IP Address is not valid");

		return ValidationResult.Success;
	}

	private static bool IpAddressHasValidSegments(string ipAddress)
	{
		var ipSegments = ipAddress.Split('.');

		if (ipSegments.Length < 4)
		{
			return false;
		}
		else if (ipSegments.Any(x =>
		{
			var num = int.Parse(x.Trim('.'));
			if (num <= 255)
				return true;

			return false;
		}))
		{
			return false;
		}

		return true;
	}

	private const string c_ipPattern = @"([\d]{1,3}[.]){3}\d";
}
