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
        private static Stack<Bitmap> UndoStack = new Stack<Bitmap>();
        private static Stack<Bitmap> RedoStack = new Stack<Bitmap>();

        public static void PushActionUndo(Bitmap bmp)
        {
            UndoStack.Push(bmp);
        }
        public static Bitmap Undo()
        {
            if(UndoStack.Count() > 1)
            {
                RedoStack.Push(UndoStack.First());
                return UndoStack.Pop();
                
            }
            return null;
            
        }
        public static Bitmap Redo()
        {
            if (RedoStack.Count() > 1)
            {
                UndoStack.Push(RedoStack.First());
                return RedoStack.Pop();
            }
            return null;

        }
    }
}
