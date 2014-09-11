/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

namespace i3DML.ObjectModel
{
    public class Plot : HeightMapBase
    {
        #region Properties
        public string Function { get; set; }
        #endregion
        public Plot()
        {
            Function = "";
        }
        private bool HasPlotFunction()
        {
            ScriptManager.Run(Function);
            return ScriptManager.Run("F(0,0);");
        }
        public override void Build()
        {
            if (HasPlotFunction())
            {
                HeightMapData = new double[Density, Density];
                for (int y = 0; y < Density; y++)
                    for (int x = 0; x < Density; x++)
                    {
                        double b = (double)ScriptManager.RunFunction(string.Format("F({0},{1});", x, y));
                        HeightMapData[x, y] = b;
                    }
            }
            else
                HeightMapData = null;
            base.Build();
        }
    }
}




