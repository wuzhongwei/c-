using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace win_form
{
    //abstract定义抽象类，子才能修改父
    abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        protected abstract Image GetImage(); // 抽象方法，需要子类去实现

        public virtual void DrawSelf()
        {
            Graphics g = GameFramework.g;
            g.DrawImage(GetImage(), X, Y);
        }
        public virtual void Update()
        {
            DrawSelf();
        }

        public Rectangle GetRectangle() // 获取当前元素位置
        {
            Rectangle rectangle = new Rectangle(X, Y, Width, Height);
            return rectangle;
        }

    }
}
