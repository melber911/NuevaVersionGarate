using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class HelperLog
    {
        private string RutaLog = "";
        private string flaglog = "";
        private DateTime fechaHoy;
        public string PathLog="";
        public HelperLog()
        {
            this.RutaLog = ConfigurationManager.AppSettings["rutalog"] + (object)System.IO.Path.DirectorySeparatorChar;
            this.flaglog = ConfigurationManager.AppSettings["flaglog"];
            
        }

        public void generarLog(string mensaje)
        {
            try
            {
                StackFrame callingframe = new StackTrace(0, true).GetFrames().ElementAt(1);
                MethodBase methodBase = callingframe.GetMethod();
                fechaHoy = DateTime.Now;
                PathLog = this.RutaLog + "Log_" + fechaHoy.ToString("ddMMyy");
                string formato = "[" + fechaHoy + "][Class: " + methodBase.DeclaringType.FullName.ToString() + "][Method: " + methodBase.Name.ToString() + "]";
                if (this.flaglog.Equals("1"))
                {
                    System.IO.File.AppendAllText(PathLog, formato + " - " + mensaje + Environment.NewLine);
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
