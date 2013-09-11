
using System.IO;

using SystemInterface.IO;
using SystemWrapper.IO;
using SystemInterface.Diagnostics;
using SystemWrapper.Diagnostics;
using NUnit.Framework;
using Moq;


namespace SystemWrapper.nUnitTests.Diagnostics
{
    [TestFixture]
    class ProcessWrapTests
    {
        Mock<IProcess> _mockProcess;
        Mock<IStreamReader> _mockStreamReader;

        [SetUp]
        public void Setup()
        {
            _mockProcess = new Mock<IProcess>();
            _mockStreamReader = new Mock<IStreamReader>();
        }

        [Test]
        public void should_be_able_to_MOQ_StandardOutput_property()
        {
            _mockStreamReader.Setup(stream => stream.ReadToEnd()).Returns("Hello World!");
            _mockProcess.SetupGet(Process => Process.StandardOutput).Returns(_mockStreamReader.Object);

            IProcess depInvoker = _mockProcess.Object;

            Assert.That(depInvoker.StandardOutput.ReadToEnd(), Is.EqualTo("Hello World!"));
        }

        [Test]
        public void should_be_able_to_MOQ_StandardError_property()
        {
            _mockStreamReader.Setup(stream => stream.ReadToEnd()).Returns("Error!");
            _mockProcess.SetupGet(Process => Process.StandardError).Returns(_mockStreamReader.Object);

            IProcess depInvoker = _mockProcess.Object;

            Assert.That(depInvoker.StandardError.ReadToEnd(), Is.EqualTo("Error!"));
        }

        [Test]
        public void should_be_able_to_WRAP_StandardOutput_property()
        {
            IProcess depInvoker = new ProcessWrap();
            depInvoker.StartInfo.FileName = "ruby";
            depInvoker.StartInfo.Arguments = "\"D:\\Softwares\\Programing\\Throw The Switch\\Unity-master\\auto\\generate_test_runner.rb\"" + " " + "\"D:\\Softwares\\Programing\\Throw The Switch\\Unity-master\\auto\\testunit.c\"" + " " + "\"D:\\temp\\generated.c\"";
            depInvoker.StartInfo.RedirectStandardOutput = true;
            depInvoker.StartInfo.UseShellExecute = false;
            depInvoker.StartInfo.CreateNoWindow = true;

            depInvoker.Start();
            bool processSafelyExited = depInvoker.WaitForExit(3000);

            string standardOutput = depInvoker.StandardOutput.ReadToEnd();

            Assert.That(processSafelyExited, Is.True);
            Assert.That(standardOutput, Is.Empty);
        }

        [Test]
        public void should_be_able_to_WRAP_StandardError_property()
        {
            IProcess depInvoker = new ProcessWrap();
            depInvoker.StartInfo.FileName = "ruby";
            depInvoker.StartInfo.Arguments = "\"D:\\Softwares\\Programing\\Throw The Switch\\Unity-master\\auto\\generate_test_runner.rb\"" + " " + "\"D:\\Softwares\\Programing\\Throw The Switch\\Unity-master\\auto\\testunit.c\"" + " " + "\"D:\\temp\\generated.c\"";
            depInvoker.StartInfo.RedirectStandardError = true;
            depInvoker.StartInfo.UseShellExecute = false;
            depInvoker.StartInfo.CreateNoWindow = true;

            depInvoker.Start();

            bool processSafelyExited = depInvoker.WaitForExit(3000);

            string standardError = depInvoker.StandardError.ReadToEnd();

            Assert.That(processSafelyExited, Is.True);
            Assert.That(standardError, Is.Not.Empty);
        }
    }
}
