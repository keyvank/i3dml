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
using System.IO;
using System.Net;
using i3DML.ObjectModel;

namespace i3DML.Xna
{
    public class i3DMLUrlManager : Ii3DMLUrlManager
    {
        public System.IO.Stream GetStream(string url)
        {
            if (File.Exists(url))
            {
                Stream dat = new StreamReader(url).BaseStream;
                return dat;
            }
            else
            {
                HttpWebRequest req = HttpWebRequest.Create(url) as HttpWebRequest;
                MemoryStream ms = new MemoryStream();
                req.GetResponse().GetResponseStream().CopyTo(ms);
                ms.Position = 0;
                return ms;
            }
        }
    }
}
