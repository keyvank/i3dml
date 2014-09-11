/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

using System;
using i3DML.ObjectModel.Components;

namespace i3DML.ObjectModel
{
    public class HeightMap : HeightMapBase
    {
        #region Fields
        private string _HeightMapSource;
        #endregion
        public string HeightMapSource { get { return _HeightMapSource; } set { _HeightMapSource = value; HeightMapResource.Url = _HeightMapSource; } }

        [i3DMLReaderIgnore]
        public Resource HeightMapResource { get; private set; }

        public HeightMap()
        {
            HeightMapResource = new Resource();
            HeightMapResource.ResourceType = ResourceType.HeightMap;
            HeightMapResource.Downloaded += new EventHandler((o, e) => { Build(); });
        }
        public override void Build()
        {
            double[,] dat = HeightMapResource.Data as double[,];
            if (dat != null)
            {
                HeightMapData = new double[Density, Density];
                double stepx = (double)dat.GetLength(0) / (double)Density;
                double stepy = (double)dat.GetLength(1) / (double)Density;
                for (int y = 0; y < Density; y++)
                    for (int x = 0; x < Density; x++)
                    {
                        HeightMapData[x, y] = dat[(int)(x * stepx), (int)(y * stepy)];
                    }
            }
            else
                HeightMapData = null;
            base.Build();
        }
    }
}




