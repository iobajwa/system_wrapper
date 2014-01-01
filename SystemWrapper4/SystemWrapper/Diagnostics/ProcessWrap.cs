using System.IO;
using System;
using System.Diagnostics;

using SystemWrapper.IO;

using SystemInterface.Diagnostics;
using SystemInterface.IO;

namespace SystemWrapper.Diagnostics
{
    ///<summary>
    /// Wrapper for <see cref="T:System.Diagnostics.Process"/> class.
    ///</summary>
    public class ProcessWrap : IProcess
    {
        private IProcessStartInfo startInfo;

        #region Constructors and Initializers

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemWrapper.Diagnostics.ProcessWrap"/> class.
        /// </summary>
        public ProcessWrap()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemWrapper.Diagnostics.ProcessWrap"/> class.
        /// </summary>
        public void Initialize()
        {
            ProcessInstance = new Process();
        }

        #endregion

        /// <inheritdoc />
        public int ExitCode
        {
            get { return ProcessInstance.ExitCode; }
        }

        /// <inheritdoc />
        public void Close()
        {
            ProcessInstance.Close();
        }

        /// <inheritdoc />
        public Process ProcessInstance { get; private set; }

        /// <inheritdoc />
        public bool Start()
        {
            return ProcessInstance.Start();
        }

        /// <inheritdoc />
        public IProcessStartInfo StartInfo
        {
            get { return startInfo ?? (startInfo = new ProcessStartInfoWrap(ProcessInstance.StartInfo)); }
            set { startInfo = value; }
        }

        /// <inheritdoc />
        public void WaitForExit()
        {
            ProcessInstance.WaitForExit();
        }

        /// <inheritdoc />
        public bool WaitForExit(int milliseconds)
        {
            return ProcessInstance.WaitForExit(milliseconds);
        }

        /// <inheritdoc />
        public bool WaitForInputIdle()
        {
            return ProcessInstance.WaitForInputIdle();
        }

        /// <inheritdoc />
        public IStreamReader StandardOutput
        {
            get { return new StreamReaderWrap (ProcessInstance.StandardOutput); }
        }

        /// <inheritdoc />
        public IStreamReader StandardError
        {
            get { return new StreamReaderWrap(ProcessInstance.StandardError); }
        }

        /// <inheritdoc />
        public IStreamWriter StandardInput
        {
            get { return new StreamWriterWrap(ProcessInstance.StandardInput); }
        }

        /// <inheritdoc />
        public void BeginErrorReadLine()
        {
            ProcessInstance.BeginErrorReadLine();
        }

        /// <inheritdoc />
        public void BeginOutputReadLine()
        {
            ProcessInstance.BeginOutputReadLine();
        }

        /// <inheritdoc />
        public void Kill()
        {
            ProcessInstance.Kill();
        }


        /// <inheritdoc />
        public bool HasExited 
        {
            get { return ProcessInstance.HasExited; }
        }

        /// <inheritdoc />
        public DateTime StartTime 
        {
            get { return ProcessInstance.StartTime; }
        }

        /// <inheritdoc />
        public DateTime ExitTime
        {
            get { return ProcessInstance.ExitTime; }
        }

        /// <inheritdoc />
        public IntPtr ProcessorAffinity 
        {
            get { return ProcessInstance.ProcessorAffinity; }
            set { ProcessInstance.ProcessorAffinity = value; }
        }

        /// <inheritdoc />
        public bool EnableRaisingEvents 
        {
            get { return ProcessInstance.EnableRaisingEvents; }
            set { ProcessInstance.EnableRaisingEvents = value; }
        }

        /// <inheritdoc />
        public event DataReceivedEventHandler ErrorDataReceived
        {
            add { ProcessInstance.ErrorDataReceived += value; }
            remove { ProcessInstance.ErrorDataReceived -= value; }
        }

        /// <inheritdoc />        
        public event DataReceivedEventHandler OutputDataReceived
        {
            add { ProcessInstance.OutputDataReceived += value; }
            remove { ProcessInstance.OutputDataReceived -= value; }
        }
    }
}