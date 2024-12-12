using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphito
{
    internal static class ToolFactory
    {
        public static ITool CreateTool(String toolName, Color primary, Color secondary, int width = 1, String shape = "")
        {
            switch (toolName) {
                case "pen":
                    return new PenTool(primary, secondary, width);
                case "eraser":
                    return new PenTool(primary, secondary, width);
                case "fill":
                    return new FillTool(primary, secondary);
                case "shape":
                    //TODO
                default:
                    return null;
            }
        }
    }
}
