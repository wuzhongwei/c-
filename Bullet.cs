using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using win_form.Properties;

namespace win_form
{
    enum Tag
    {
        MyTank,
        EnemyTank
    }
    class Bullet:Movething
    {
        public Tag Tag { get; set; }
        public Bullet(int x, int y, int speed, Direction dir, Tag tag)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            BitmapDown = Resources.BulletDown;
            BitmapUp = Resources.BulletUp;
            BitmapRight = Resources.BulletRight;
            BitmapLeft = Resources.BulletLeft;
            this.Dir = dir;
            this.Tag = tag;
            this.X = X - Width / 2;
            this.Y = Y - Height / 2;
        }
        public override void DrawSelf()
        {
            base.DrawSelf();
        }
    }
}
