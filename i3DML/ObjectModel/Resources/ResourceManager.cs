/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using i3DML.ObjectModel.Components;

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Provides a delegate for converting the resource stream to the resource object.
    /// </summary>
    /// <param name="resourceStream">The stream</param>
    /// <returns>Converted object</returns>
    public delegate object ResourceConverter(Stream resourceStream);

    /// <summary>
    /// Static class for downloading and managing resources.
    /// </summary>
    [i3DMLReaderIgnore]
    public static class ResourceManager
    {
        const int Timeout = 2000;
        static Dictionary<ResourceType, Dictionary<string, object>> Resources;
        static Dictionary<ResourceType, ResourceConverter> ResourceConverters;
        static ICollection<Resource> NotDownloaded;
        static Ii3DMLUrlManager UrlManager;
        static ResourceManager()
        {
            Resources = new Dictionary<ResourceType, Dictionary<string, object>>();
            ResourceConverters = new Dictionary<ResourceType, ResourceConverter>();
            NotDownloaded = new List<Resource>();
            foreach (ResourceType r in Enum.GetValues(typeof(ResourceType)))
                Resources.Add(r, new Dictionary<string, object>());
        }

        /// <summary>
        /// Sets the a resource's converter.
        /// </summary>
        /// <param name="t">Resource type</param>
        /// <param name="c">The converter</param>
        public static void SetResourceConverter(ResourceType t, ResourceConverter c)
        {
            if (!ResourceConverters.ContainsKey(t))
                ResourceConverters.Add(t, c);
            else
                ResourceConverters[t] = c;
        }

        public static void SetUrlManager(Ii3DMLUrlManager manager)
        {
            UrlManager = manager;
        }

        private static void Downloaded(Resource r)
        {
            r.AlertDownloaded();
            List<Resource> rc=NotDownloaded.Where(res => res.Url == r.Url&&res.ResourceType==r.ResourceType).ToList();
            foreach(Resource re in rc)
            {
                re.Data=r.Data;
                re.AlertDownloaded();
                NotDownloaded.Remove(re);
            }
        }

        /// <summary>
        /// Downloads the resource.
        /// </summary>
        /// <param name="res">The resource</param>
        public static void Download(Resource res)
        {
            if (Resources[res.ResourceType].ContainsKey(res.Url))
            {
                if (Resources[res.ResourceType][res.Url] != null)
                {
                    res.Data = Resources[res.ResourceType][res.Url];
                    Downloaded(res);
                }
                else
                {
                    NotDownloaded.Add(res);
                }
                return;
            }
            Resources[res.ResourceType].Add(res.Url, null);
            ResourceConverter conv =ResourceConverters[res.ResourceType];
            Task download = new Task((obj) =>
                {
                    i3DML.ObjectModel.Resource resource = obj as i3DML.ObjectModel.Resource;
                    while (true)
                    {
                        try
                        {
                            Stream dat = UrlManager.GetStream(resource.Url);
                            object converted = conv(dat);
                            Resources[res.ResourceType][resource.Url] = converted;
                            resource.Data = converted;
                            Downloaded(resource);
                            break;
                        }
                        catch { System.Threading.Thread.Sleep(Timeout); }
                    }
                }, res);
            download.Start();
        }
    }
}




