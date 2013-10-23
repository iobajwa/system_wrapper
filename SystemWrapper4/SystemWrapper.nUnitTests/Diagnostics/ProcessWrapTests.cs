
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
        ProcessWrap _wrappedProcess;
        IProcess _depInvoker;

        [SetUp]
        public void Setup()
        {
            _mockProcess = new Mock<IProcess>();
            _mockStreamReader = new Mock<IStreamReader>();

            _wrappedProcess = new ProcessWrap();
            _depInvoker = _wrappedProcess;

            _depInvoker.StartInfo.FileName = "cmd";
            _depInvoker.StartInfo.Arguments = "Exit";
            _depInvoker.StartInfo.UseShellExecute = false;
            _depInvoker.StartInfo.CreateNoWindow = false;
        }

        [Test]
        public void _01_should_be_able_to_MOQ_StandardOutput_property()
        {
            _mockStreamReader.Setup(stream => stream.ReadToEnd()).Returns("Hello World!");
            _mockProcess.SetupGet(Process => Process.StandardOutput).Returns(_mockStreamReader.Object);

            IProcess depInvoker = _mockProcess.Object;

            Assert.That(depInvoker.StandardOutput.ReadToEnd(), Is.EqualTo("Hello World!"));
        }

        [Test]
        public void _02_should_be_able_to_MOQ_StandardError_property()
        {
            _mockStreamReader.Setup(stream => stream.ReadToEnd()).Returns("Error!");
            _mockProcess.SetupGet(Process => Process.StandardError).Returns(_mockStreamReader.Object);

            IProcess depInvoker = _mockProcess.Object;

            Assert.That(depInvoker.StandardError.ReadToEnd(), Is.EqualTo("Error!"));
        }

        [Test]
        public void _03_should_be_able_to_WRAP_StandardOutput_property()
        {
            _depInvoker.StartInfo.RedirectStandardOutput = true;

            _depInvoker.Start();
            bool processSafelyExited = _depInvoker.WaitForExit(3000);

            string standardOutput = _depInvoker.StandardOutput.ReadToEnd();

            Assert.That(processSafelyExited, Is.True);
            Assert.That(standardOutput, Is.Not.Empty);
        }

        [Test]
        public void _04_should_be_able_to_WRAP_StandardError_property()
        {            
            _depInvoker.StartInfo.RedirectStandardError = true;
            _depInvoker.StartInfo.Arguments = "#@#";
            _depInvoker.Start();
            bool processSafelyExited = _depInvoker.WaitForExit(3000);

            string standardError = _depInvoker.StandardError.ReadToEnd();

            Assert.That(processSafelyExited, Is.True);
            Assert.That(standardError, Is.Not.Empty);
        }

        [Test]
        public void _05_SHOULD_return_ExitTime_greater_than_StartTime()
        {
            _depInvoker.StartInfo.Arguments = "#@#";
            _depInvoker.Start();
            bool processSafelyExited = _depInvoker.WaitForExit(3000);

            Assert.That(processSafelyExited, Is.True);
            Assert.That(_depInvoker.ExitTime, Is.GreaterThan(_depInvoker.StartTime));
        }

        [Test]
        public void _06_SHOULD_be_able_to_set_correct_WorkingDirectory()
        {
            string expectedDir = Directory.GetCurrentDirectory();
            _depInvoker.StartInfo.WorkingDirectory = expectedDir;
            string encodedDir = _wrappedProcess.ProcessInstance.StartInfo.WorkingDirectory;
            
            Assert.That(encodedDir, Is.EqualTo(expectedDir));
        }
    }
}
