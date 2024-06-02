using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace AuthServer
{
    public class Keys
    {
        public RSA RsaKey { get; }
        public RsaSecurityKey RsaSecurityKey => new RsaSecurityKey(RsaKey);
        public Keys(IWebHostEnvironment env)
        {
            RsaKey = RSA.Create();
            var path = Path.Combine(env.ContentRootPath, "crypto_key");
            if (File.Exists(path))
            {
                var rsaKey = RSA.Create();
                rsaKey.ImportRSAPrivateKey(File.ReadAllBytes(path), out _);
            }

            else
            {
                var privatekey = RsaKey.ExportRSAPrivateKey();
                File.WriteAllBytes(path, privatekey);
            }
        }
    }
}
