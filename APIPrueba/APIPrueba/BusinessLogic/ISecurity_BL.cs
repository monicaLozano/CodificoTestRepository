using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ISecurity_BL
    {
        public (string PublicKey, string PrivateKey) GenerateKeys();
        public string EncryptLongData(string plainText);
        public string DecryptLongData(string cipher);
    }
}
