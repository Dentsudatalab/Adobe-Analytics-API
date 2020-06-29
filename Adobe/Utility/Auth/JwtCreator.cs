namespace Adobe.Utility.Auth
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography;

    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.Security;

    public static class JwtCreator
    {
        /// <summary>
        /// Creates a JWT from a private key.
        /// </summary>
        /// <param name="authValues">The auth values to use.</param>
        /// <returns>A JWT.</returns>
        public static string CreateJwt(AuthValues authValues, DateTime? exp = null)
        {
            exp = exp ?? DateTime.Now;

            // Convert to UTC
            var expUnspecified = DateTime.SpecifyKind(exp.Value, DateTimeKind.Unspecified);
            exp = TimeZoneInfo.ConvertTimeToUtc(expUnspecified, TimeZoneInfo.Utc);

            var expUnix = new DateTimeOffset(exp.Value.AddMinutes(10)).ToUnixTimeSeconds();

            var payload = new Dictionary<string, object>
            {
                {"exp", expUnix},
                {"iss", authValues.OrganizationId},
                {"sub", authValues.TechnicalAccountId},
                {"https://ims-na1.adobelogin.com/s/ent_analytics_bulk_ingest_sdk", true},
                {"aud", $"https://ims-na1.adobelogin.com/c/{authValues.ClientId}"}
            };

            RSAParameters rsaParams;

            using (var tr = new StringReader(authValues.PrivateKey))
            {
                var pemReader = new PemReader(tr);

                if (!(pemReader.ReadObject() is RsaPrivateCrtKeyParameters keyPair))
                    throw new Exception("Could not read RSA private key");

                rsaParams = DotNetUtilities.ToRSAParameters(keyPair);
            }


            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaParams);

                return Jose.JWT.Encode(payload, rsa, Jose.JwsAlgorithm.RS256);
            }
        }
    }
}
