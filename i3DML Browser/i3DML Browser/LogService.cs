/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace i3DML_Browser
{
    /// <summary>
    /// A simple tool for logging.
    /// </summary>
    static class LogService
    {
        static LogService()
        {
            Console.WriteLine("i3DML Engine 1.0 BETA");
            Separator();
        }
        static public void Separator()
        {
            Console.Write(new String('-', Console.WindowWidth));
        }
        static public void WriteLine(string str,params object[] args)
        {
            Console.WriteLine("[{0}] >>> {1}", DateTime.Now.ToShortTimeString(), string.Format(str, args));
        }
    }
}




