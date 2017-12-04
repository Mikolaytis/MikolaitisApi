using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mikolaitis.Api.Core.Utils;

namespace Mikolaitis.Api.Core.Tests
{
    [TestClass]
    public class KeyDerivationFunctionTests
    {
        private const string Pass = "aA1234";

        [TestMethod]
        public void HashVerify_SamePassword_True()
        {
            var kdf = new KeyDerivationFunction();

            var hash = kdf.HashPassword(Pass);
            var result = kdf.VerifyHashedPassword(hash, Pass);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HashVerify_DifferentPassword_False()
        {
            var kdf = new KeyDerivationFunction();

            var hash = kdf.HashPassword(Pass);
            var result = kdf.VerifyHashedPassword(hash, Pass + "1");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HashPassword_Twice_DifferentResult()
        {
            var kdf = new KeyDerivationFunction();

            var hash1 = kdf.HashPassword(Pass);
            var hash2 = kdf.HashPassword(Pass);

            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void HashPassword_Twice_BothVerified()
        {
            var kdf = new KeyDerivationFunction();

            var hash1 = kdf.HashPassword(Pass);
            var hash2 = kdf.HashPassword(Pass);
            var result1 = kdf.VerifyHashedPassword(hash1, Pass);
            var result2 = kdf.VerifyHashedPassword(hash2, Pass);

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }
    }
}
