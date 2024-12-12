using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphito
{
    internal static class ActionsRecordManager
    {
        public static Stack<Bitmap> UndoStack { set; get; } = new Stack<Bitmap>();
        public static Stack<Bitmap> RedoStack { set; get; } = new Stack<Bitmap>();

        public static void PushActionUndo(Bitmap bmp)
        {
            UndoStack.Push(bmp);
        }

        public static void PushActionRedo(Bitmap bmp)
        {
            RedoStack.Push(bmp);
        }
        public static Bitmap Undo(Bitmap actualBmp)
        {
            Bitmap returningBmp = null;

            if (UndoStack.Count > 0)
            {
                RedoStack.Push(actualBmp);
                returningBmp = UndoStack.Pop();
            }

            return returningBmp;
            
        }

        public static Bitmap Redo(Bitmap actualBmp)
        {
            Bitmap returningBmp = null;

            if (RedoStack.Count > 0)
            {
                UndoStack.Push(actualBmp);
                returningBmp = RedoStack.Pop();
            }
            return returningBmp;

        }
    }
}
