using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using win_form.Properties;

namespace win_form
{
    class EnemyTank:Movething
    {
        private Random r = new Random();
        public EnemyTank(int x, int y, int speed, Bitmap bmpDown, Bitmap bmpUp, Bitmap bmpRight, Bitmap bmpLeft)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            BitmapDown = bmpDown;
            BitmapUp = bmpUp;
            BitmapRight = bmpRight;
            BitmapLeft = bmpLeft;
            this.Dir = Direction.Down;
        }
        public override void Update()
        {

            MoveCheck();
            base.Update();
            Move();

        }
        private void MoveCheck()
        {
            if (Dir == Direction.Up)
            {
                if (Y - Speed < 0)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (Y + Speed + Height > 450)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (X - Speed < 0)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (X + Speed + Width > 450)
                {
                    ChangeDirection();
                    return;
                }
            }

            Rectangle rect = GetRectangle();
            switch (Dir)
            {
                case Direction.Up:
                    rect.Y -= Speed;
                    break;
                case Direction.Down:
                    rect.Y += Speed;
                    break;
                case Direction.Left:
                    rect.X -= Speed;
                    break;
                case Direction.Right:
                    rect.X += Speed;
                    break;
            }

            if (GameObjectManager.IsCollidedWall(rect) != null)
            {
                ChangeDirection();
            }
            if (GameObjectManager.IsCollidedSteel(rect) != null)
            {
                ChangeDirection();
            }
            if (GameObjectManager.IsCollidedBoss(rect))
            {
                ChangeDirection();
            }
        }
        private void ChangeDirection()
        {

            while (true)
            {
                Direction dir = (Direction)r.Next(0, 4);
                if (dir == Dir)
                {
                    continue;
                }
                {
                    Dir = dir;
                    break;
                }
            }


            MoveCheck();
        }

        private void Move()
        {
            switch (Dir)
            {
                case Direction.Up:
                    Y -= Speed;
                    break;
                case Direction.Down:
                    Y += Speed;
                    break;
                case Direction.Left:
                    X -= Speed;
                    break;
                case Direction.Right:
                    X += Speed;
                    break;
            }

        }
    }
}
