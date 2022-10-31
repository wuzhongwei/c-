using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using win_form.Properties;

namespace win_form
{
    class GameObjectManager
    {
        private static List<NotMovethins> wallList = new List<NotMovethins>();
        private static List<NotMovethins> steelList = new List<NotMovethins>();
        private static NotMovethins boss;
        private static MyTank myTank;
        private static List<EnemyTank> tankList = new List<EnemyTank>();


        private static int enemyBornSpeed = 60;
        private static int enemyBornCount = 60;
        private static Point[] points = new Point[3];

        public static void Start()
        {
            points[0].X = 0; points[0].Y = 0;

            points[1].X = 7 * 30; points[1].Y = 0;
            points[2].X = 14 * 30; points[2].Y = 0;

        }
        public static void Update()
        {
            foreach (NotMovethins nm in wallList)
            {
                nm.Update();
            }
            foreach (NotMovethins nm in steelList)
            {
                nm.Update();
            }
            foreach(EnemyTank tank in tankList)
            {
                tank.Update();
            }
            boss.Update();
            myTank.Update();
            EnemyBorn();
        }

        private static void EnemyBorn()
        {
            enemyBornCount++;
            if (enemyBornCount < enemyBornSpeed) return;

            Random rd = new Random();
            int index = rd.Next(0, 3);
            Point position = points[index];
            int enemyType = rd.Next(1, 5);
            switch (enemyType) 
            {
                case 1:
                    CreateEnemyTank1(position.X, position.Y);
                    break;
                case 2:
                    CreateEnemyTank2(position.X, position.Y);
                    break;
                case 3:
                    CreateEnemyTank3(position.X, position.Y);
                    break;
                case 4:
                    CreateEnemyTank4(position.X, position.Y);
                    break;
            }


            enemyBornCount = 0;
        }

        private static void CreateEnemyTank1(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 2, Resources.GrayDown, Resources.GrayUp, Resources.GrayRight,Resources.GrayLeft);
            tankList.Add(tank);
        }
        private static void CreateEnemyTank2(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 2, Resources.GreenDown, Resources.GreenUp, Resources.GreenRight, Resources.GreenLeft);
            tankList.Add(tank);
        }
        private static void CreateEnemyTank3(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 4, Resources.QuickDown, Resources.QuickUp, Resources.QuickRight, Resources.QuickLeft);
            tankList.Add(tank);
        }
        private static void CreateEnemyTank4(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 1, Resources.SlowDown, Resources.SlowUp, Resources.SlowRight, Resources.SlowLeft);
            tankList.Add(tank);
        }

        public static NotMovethins IsCollidedWall(Rectangle rt)
        {
            foreach(NotMovethins wall in wallList)
            {
                if (wall.GetRectangle().IntersectsWith(rt))
                {
                    return wall;
                }
            }
            return null;
        }
        public static NotMovethins IsCollidedSteel(Rectangle rt)
        {
            foreach (NotMovethins wall in steelList)
            {
                if (wall.GetRectangle().IntersectsWith(rt))
                {
                    return wall;
                }
            }
            return null;
        }
        public static bool IsCollidedBoss(Rectangle rt)
        {
            return boss.GetRectangle().IntersectsWith(rt);
        }
        //public static void DrawMap()
        //{
        //    foreach(NotMovethins nm in wallList)
        //    {
        //        nm.DrawSelf();
        //    }
        //    foreach (NotMovethins nm in steelList)
        //    {
        //        nm.DrawSelf();
        //    }
        //    boss.DrawSelf();
        //}
        //public static void DrawMyTank()
        //{
        //    myTank.DrawSelf();
        //}
        public static void CreateMyTank()
        {
            int x = 5 * 30;
            int y = 14 * 30;
            myTank = new MyTank(x, y, 2);
        }
        public static void CreateMap()
        {
            CreateWall(1, 1, 5, Resources.wall, wallList);
            CreateWall(3, 1, 5, Resources.wall, wallList);
            CreateWall(5, 1, 4, Resources.wall, wallList);
            CreateWall(7, 1, 3, Resources.wall, wallList);
            CreateWall(9, 1, 4, Resources.wall, wallList);
            CreateWall(11, 1, 5, Resources.wall, wallList);
            CreateWall(13, 1, 5, Resources.wall, wallList);

            CreateWall(7, 5, 1, Resources.steel, steelList);
            CreateWall(0, 7, 1, Resources.steel, steelList);

            CreateWall(2, 7, 1, Resources.wall, wallList);
            CreateWall(3, 7, 1, Resources.wall, wallList);
            CreateWall(4, 7, 1, Resources.wall, wallList);
            CreateWall(6, 7, 1, Resources.wall, wallList);
            CreateWall(7, 6, 2, Resources.wall, wallList);
            CreateWall(8, 7, 1, Resources.wall, wallList);
            CreateWall(10, 7, 1, Resources.wall, wallList);
            CreateWall(11, 7, 1, Resources.wall, wallList);
            CreateWall(12, 7, 1, Resources.wall, wallList);

            CreateWall(14, 7, 1, Resources.steel, steelList);

            CreateWall(1, 9, 5, Resources.wall, wallList);
            CreateWall(3, 9, 5, Resources.wall, wallList);
            CreateWall(5, 9, 3, Resources.wall, wallList);

            CreateWall(6, 10, 1, Resources.wall, wallList);
            CreateWall(7, 10, 2, Resources.wall, wallList);
            CreateWall(8, 10, 1, Resources.wall, wallList);

            CreateWall(9, 9, 3, Resources.wall, wallList);
            CreateWall(11, 9, 5, Resources.wall, wallList);
            CreateWall(13, 9, 5, Resources.wall, wallList);

            CreateWall(6, 13, 2, Resources.wall, wallList);
            CreateWall(7, 13, 1, Resources.wall, wallList);
            CreateWall(8, 13, 2, Resources.wall, wallList);

            CreateBoss(7, 14, Resources.Boss);
        }

        public static void CreateBoss(int x, int y, Image img)
        {
            int xPosition = x * 30;
            int yPosition = y * 30;
            boss = new NotMovethins(xPosition, yPosition, img);
        }
        public static void CreateWall(int x, int y, int count, Image img, List<NotMovethins> wallList)
        {
            int xPosition = x * 30;
            int yPosition = y * 30;
            for (int i = yPosition; i < yPosition + count * 30; i += 15)
            {
                NotMovethins wall1 = new NotMovethins(xPosition, i, img);
                NotMovethins wall2 = new NotMovethins(xPosition + 15, i, img);
                wallList.Add(wall1);
                wallList.Add(wall2);
            }
            Console.WriteLine(wallList.Count);
        }
        public static void KeyDwon(KeyEventArgs args)
        {
            myTank.KeyDwon(args);
        }
        public static void KeyUp(KeyEventArgs args)
        {
            myTank.KeyUp(args);
        }
    }
}
