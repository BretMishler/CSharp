using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Whats_New_CSharp_6.Tests
{
    [TestClass]
    class OperationLogger_Tests
    {
        [TestMethod]
        public async Task Can_Log_A_Successful_Operations()
        {
            var stream = new MemoryStream();
            var logger = new OperationLogger(stream);

            await logger.LogOperationAsync(DoWork);

            Assert.AreEqual("DoWork executed", await ReadStream(stream));
        }

        [TestMethod]
        public async Task Can_Log_A_Failed_Operation()
        {
            var stream = new MemoryStream();
            var logger = new OperationLogger(stream);

            await logger.LogOperationAsync(DoException);

            Assert.AreEqual("DoException failed", await ReadStream(stream));
        }

        [TestMethod]
        public async Task Does_Not_Log_Exceptions_With_Inner_Exception()
        {
            using (var stream = new MemoryStream())
            using (var logger = new OperationLogger(stream))
            {
                await logger.LogOperationAsync(DoWithInnerException);
            }
        }

        async Task<string> ReadStream(Stream stream)
        {
            var reader = new StreamReader(stream);
            stream.Position = 0;

            var result = await reader.ReadToEndAsync();
            return result.Trim();
        }

        void DoWork()
        {

        }

        void DoException()
        {
            throw new InvalidOperationException();
        }

        void DoWithInnerException()
        {
            throw new InvalidOperationException("", new Exception());
        }
    }
}
