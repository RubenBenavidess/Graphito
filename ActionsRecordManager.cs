using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphito
{
    internal static class ActionsRecordManager
    {
        public static Stack<Bitmap> UndoStack { set; get; } = new Stack<Bitmap>();
        public static Stack<Bitmap> RedoStack = new Stack<Bitmap>();

        public static void PushActionUndo(Bitmap bmp)
        {
            UndoStack.Push(bmp);
        }

        public static void PushActionRedo(Bitmap bmp)
        {
            RedoStack.Push(bmp);
        }
        public static Bitmap Undo()
        {
            Bitmap returningBmp = null;

            if (UndoStack.Count > 0)
            {
                Bitmap aux = UndoStack.Pop();
                RedoStack.Push(aux);
                if(UndoStack.Count > 0)
                {
                    returningBmp = UndoStack.Peek();
                }
                else
                {
                    returningBmp = null;
                }
                
                
            }

            return returningBmp;
            
        }

        public static Bitmap Redo()
        {
            Bitmap returningBmp = null;

            if (RedoStack.Count > 0)
            {
                Bitmap aux = RedoStack.Pop();
                UndoStack.Push(aux);
                returningBmp = aux;
            }
            return returningBmp;

        }
    }
}
