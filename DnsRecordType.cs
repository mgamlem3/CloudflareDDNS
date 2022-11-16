using System.Collections.ObjectModel;

namespace CloudflareDDNS;

public static class DnsRecordType
{
	public const string A = "A";
	public const string AAAA = "AAAA";
	public const string CNAME = "CNAME";
	public const string HTTPS = "HTTPS";
	public const string TXT = "TXT";
	public const string SRV = "SRV";
	public const string LOC = "LOC";
	public const string MX = "MX";
	public const string NS = "NS";
	public const string CERT = "CERT";
	public const string DNSKEY = "DNSKEY";
	public const string DS = "DS";
	public const string NAPTR = "NAPTR";
	public const string SMIMEA = "SMIMEA";
	public const string SSHFP = "SSHFP";
	public const string SVCB = "SVCB";
	public const string TLSA = "TLSA";
	public const string URI = "URI";

	public static ReadOnlyCollection<string> GetAllTypes() => new(new List<string> { A,
 AAAA, CNAME, HTTPS, TXT, SRV, LOC, MX, NS, CERT, DNSKEY, DS, NAPTR, SMIMEA, SSHFP, TLSA, URI});
}
