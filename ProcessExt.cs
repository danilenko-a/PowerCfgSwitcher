using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCfgSwitcher
{
    internal class ProcessExt
    {
        private readonly Process process = new Process();

        public ProcessStartInfo StartInfo
        {
            set
            {
                this.process.StartInfo = value;
            }
        }

        public ProcessExt()
        {
        }

        public ProcessExt Start()
        {
            this.process.Start();
            return this;
        }

        public ProcessExt WaitForExit()
        {
            this.process.WaitForExit();
            return this;
        }

        public ProcessExt Close()
        {
            this.process.Close();
            return this;
        }

        public string GetOutputString()
        {
            return GetEcho(this.process);
        }

        private string GetEcho(Process process)
        {
            string output = process.StandardOutput.ReadToEnd();

            Encoding win1251 = Encoding.GetEncoding(1251);
            Encoding utf8 = Encoding.GetEncoding(866);
            byte[] originalByteString = win1251.GetBytes(output);
            byte[] convertedByteString = Encoding.Convert(utf8,
            win1251, originalByteString);
            return win1251.GetString(convertedByteString);
        }
    }
}
