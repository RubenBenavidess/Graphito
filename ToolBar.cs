using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphito
{
    public partial class ToolBar : UserControl
    {
        int ColorSelected = 0;
        Color PrimaryColor = Color.Black;
        Color SecondaryColor = Color.White;
        int ToolWidth = 1;
        String toolName = "pen";

        public ToolBar()
        {
            InitializeComponent();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            Main.CurrentTool = ToolFactory.CreateTool("fill", PrimaryColor, SecondaryColor);
            toolName = "fill";
            resetButtonsBg();
            btnFill.BackColor = Color.FromArgb(100, 184, 189);

        }

        private void btnEraser_Click(object sender, EventArgs e)
        {
            Main.CurrentTool = ToolFactory.CreateTool("eraser", Color.White, Color.White, ToolWidth);
            toolName = "eraser";
            resetButtonsBg();
            btnEraser.BackColor = Color.FromArgb(100, 184, 189);

        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            Main.CurrentTool = ToolFactory.CreateTool("pen", PrimaryColor, SecondaryColor, ToolWidth);
            toolName = "pen";
            resetButtonsBg();
            btnPen.BackColor = Color.FromArgb(100, 184, 189); 
        }



        public void resetButtonsBg()
        {
            Color bg = Color.FromArgb(60, 110, 113);
            btnFill.BackColor = bg;
            btnEraser.BackColor = bg;
            btnPen.BackColor = bg;
            btnRectangleTool.BackColor = bg;
            btnEllipseTool.BackColor = bg;
            btnCircleTool.BackColor = bg;
        }

        private void btnPrimaryColor_Click(object sender, EventArgs e)
        {
            ColorSelected = 0;
        }

        private void btnSecondaryColor_Click(object sender, EventArgs e)
        {
            ColorSelected = 1;
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = (ColorSelected == 0) ? PrimaryColor : SecondaryColor;
                colorDialog.AllowFullOpen = true;
                colorDialog.FullOpen = true;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    if (ColorSelected == 0)
                    {
                        PrimaryColor = colorDialog.Color;
                        btnPrimaryColor.BackColor = PrimaryColor;
                    }
                    else if (ColorSelected == 1)
                    {
                        SecondaryColor = colorDialog.Color;
                        btnSecondaryColor.BackColor = SecondaryColor;
                    }
                    Main.CurrentTool = ToolFactory.CreateTool(toolName, PrimaryColor, SecondaryColor, ToolWidth);
                }
            }
        }

        private void trackWidth_Scroll(object sender, EventArgs e)
        {
            ToolWidth = trackWidth.Value;
            Main.CurrentTool = ToolFactory.CreateTool(toolName, PrimaryColor, SecondaryColor, ToolWidth);
        }

        private void trackWidth_Leave(object sender, EventArgs e)
        {
            Main.CurrentTool = ToolFactory.CreateTool(toolName, PrimaryColor, SecondaryColor, ToolWidth);
        }
    }
}
