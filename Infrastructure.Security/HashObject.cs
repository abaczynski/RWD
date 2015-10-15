using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Security
{
    public class HashObject
    {
        private byte[] _hashedText;

        private byte[] _salt;

        public HashObject(byte[] hashedText, byte[] salt)
        {
            _hashedText = hashedText;
            _salt = salt;
        }

        public HashObject(string hashedText, string salt)
        {
            _hashedText = Convert.FromBase64String(hashedText);
            _salt = Convert.FromBase64String(salt);
        }

        public string HashedText
        {
            get
            {
                return Convert.ToBase64String(_hashedText);
            }
        }

        public byte[] HashedTextByte
        {
            get
            {
                return _hashedText;
            }
        }

        public string Salt
        {
            get
            {
                return Convert.ToBase64String(_salt);
            }
        }

        public byte[] SaltByte
        {
            get
            {
                return _salt;
            }
        }
    }
}
