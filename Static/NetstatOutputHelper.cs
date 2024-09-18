

namespace Chubby
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public static class NetstatOutputHelper
    {
        const string FILE_NAME = "Netstat";

        const string ARGUMENTS = "-ano -p tcp";

        public static List<string> GetNetstatOutput()
        {
            List<string> _netstatOutput = new List<string>();
            Process _process = ConfigureProcess();
            _process.Start();
            string _output = _process.StandardOutput.ReadToEnd();
            if (_output != null)
            {
                string[] _lines = _output.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string _line in _lines)
                {
                    if (_line.Contains("TCP"))
                        _netstatOutput.Add(_line);
                }
            }
            else
            {
                throw new NetstatProcessException(_process);
            }
            return _netstatOutput;
        }

        static Process ConfigureProcess()
        {
            Process _process = new Process();
            _process.StartInfo.FileName = FILE_NAME;
            _process.StartInfo.Arguments = ARGUMENTS;
            _process.StartInfo.UseShellExecute = false;
            _process.StartInfo.RedirectStandardOutput = true;
            return _process;
        }
    }
}
