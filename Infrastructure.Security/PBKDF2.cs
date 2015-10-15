using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Infrastructure.Security
{
    public class Pbkdf2 : ISecurityService
    {
        private int _hashIterations;
        private int _saltLength;
        private int _hashLength;

        public Pbkdf2()
        {
            _hashIterations = 50000;
            _saltLength = 16;
            _hashLength = 64;
        }

        public HashObject Compute(string plainText)
        {
            return Compute(plainText, Utility.GenerateSalt(_saltLength));
        }

        private HashObject Compute(string plainText, byte[] salt)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentException("plainText cannot be empty!");

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(plainText, salt, _hashIterations);
            byte[] hashedText = pbkdf2.GetBytes(_hashLength);

            return new HashObject(hashedText, salt);
        }

        public bool ValidateHash(string plainText, HashObject hObject)
        {
            HashObject hashObject = Compute(plainText, hObject.SaltByte);

            return Utility.SlowEquals(hashObject.HashedTextByte, hObject.HashedTextByte);
        }
    }
}
