using System.Collections.Generic;

namespace CS
{
    public class SignatureFile
    {
        public IEnumerable<byte> Signature { get; set; }

        public int SizeSignature { get; set; } = 16;
    }
}
