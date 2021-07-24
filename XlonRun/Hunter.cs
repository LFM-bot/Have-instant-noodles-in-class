using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace XlonRun
{
    public abstract class Hunter
    {
        private PointF _location;
        //人物图片
        private Bitmap _pic;
        //对话框
        private Bitmap _Dialog;
        private string _words = "小兔崽子你给我回来";
        private float _speed;
        private dir _direction;
        private Difficulty _diffi = Difficulty.easy;
        //上次的位置
        private PointF _lastLocation;



        internal Difficulty Diffi
        {
            get { return _diffi; }
            set { _diffi = value; }
        }

        public PointF Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public Bitmap Pic
        {
            get { return _pic; }
            set { _pic = value; }
        }
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public dir Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        public string Words
        {
            get { return _words; }
            set { _words = value; }
        }

        public Bitmap Dialog
        {
            get { return _Dialog; }
            set { _Dialog = value; }
        }
        public PointF LastLocation
        {
            get { return _lastLocation; }
            set { _lastLocation = value; }
        }
        public abstract void Move(Map map,PointF　playerLocation);
       
        //绘图
        public abstract void Draw(Graphics g, bool speak,bool everyBodySay);
    }

    public class Teacher : Hunter
    {
        //建立当前可选方向序列
        private List<dir> _listDir = new List<dir>();
        //构造函数
        public Teacher(Difficulty diffi,int level)
        {
            Diffi = diffi;
            if (level == 1)
            {
                if (Diffi == Difficulty.easy)
                    Speed = (float)2.5;
                else if (Diffi == Difficulty.normal)
                    Speed = (float)2.9;
                else
                    Speed = (float)3.1;
            }
            else
                Speed = (float)4;

        }

        public override void Move(Map map,PointF playerLocation)
        {
            LastLocation = Location;
            bool flag = true;
            //选择方向
            DirChooceMake(map);
            foreach (dir d in _listDir)
                if (playerLocation.X >= Location.X && d == dir.right)
                {
                    Direction = dir.right;
                    break;
                }
                else if (playerLocation.X <= Location.X && d == dir.left)
                {
                    Direction = dir.left;
                    break;
                }
                else if (playerLocation.Y >= Location.Y && d == dir.down)
                {
                    Direction = dir.down;
                    break;
                }

                else if (playerLocation.Y <= Location.Y && d == dir.up)
                {
                    Direction = dir.up;
                    break;
                }
                else
                    flag = false;
            if (!flag&& Math.Pow(LastLocation.X - Location.X, 2) + Math.Pow(LastLocation.Y - Location.X, 2) < Speed * Speed)
            {
                dir reverseD;//反方向
                if ((int)Direction % 2 == 0) reverseD = (dir)((int)Direction + 1);
                else reverseD = (dir)((int)Direction - 1);
                Direction = reverseD;
            }
            if (Location.Y < map._RightUpPoint.Y)
            {
                if (Direction == dir.down)
                {
                    Location = new PointF(Location.X, Location.Y + Speed);
                }
                else if (Direction == dir.up)
                {
                    if (Location.Y - Speed >= map._PassY)
                    {
                        Location = new PointF(Location.X, Location.Y - Speed);
                    }
                }
                else if (Direction == dir.left)
                {
                    //通道左端边界
                    if (Location.X - Speed >= map._PassXl)
                    {
                        Location = new PointF(Location.X - Speed, Location.Y);
                    }
                }
                else if (Direction == dir.right)
                {
                    //通道右端边界
                    if (Location.X + Speed <= map._PassXr)
                    {
                        Location = new PointF(Location.X + Speed, Location.Y);
                    }
                }
            }
            //矩形区内
            else
            {
                //上下左右边界
                if (Direction == dir.down)
                {
                    float Ynew = Location.Y + Speed;
                    //如果不发生碰撞
                    if (!collisionJudgeAll(new PointF(Location.X, Ynew), map._ListBlocks))
                        if (Ynew <= map._LeftDownPoint.Y)
                        {
                            Location = new PointF(Location.X, Ynew);
                        }
                }
                else if (Direction == dir.up)
                {
                    //如果在中央通道,可以向上移动
                    if (Location.X >= map._PassXl && Location.X <= map._PassXr)
                    {
                        float Ynew = Location.Y - Speed;
                        //如果不发生碰撞
                        if (!collisionJudgeAll(new PointF(Location.X, Ynew), map._ListBlocks))
                        {
                            Location = new PointF(Location.X, Ynew);
                        }
                    }
                    else
                    {
                        float Ynew = Location.Y - Speed;
                        //如果不发生碰撞
                        if (!collisionJudgeAll(new PointF(Location.X, Ynew), map._ListBlocks))
                            if (Ynew >= map._RightUpPoint.Y)
                            {
                                Location = new PointF(Location.X, Ynew);
                            }
                    }
                }
                else if (Direction == dir.left)
                {
                    float Xnew = Location.X - Speed;
                    //如果不发生碰撞
                    if (!collisionJudgeAll(new PointF(Xnew, Location.Y), map._ListBlocks))
                        if (Xnew >= map._LeftDownPoint.X)
                        {
                            Location = new PointF(Xnew, Location.Y);
                        }
                }
                else if (Direction == dir.right)
                {
                    float Xnew = Location.X + Speed;
                    //如果不发生碰撞
                    if (!collisionJudgeAll(new PointF(Xnew, Location.Y), map._ListBlocks))
                        if (Xnew <= map._RightUpPoint.X)
                        {
                            Location = new PointF(Xnew, Location.Y);
                        }
                }

            }
                
        }

        //判断是否进入矩形区，单个检测
        private bool collisionJudge(PointF p, Block block)
        {
            //发生碰撞
            if (block.LeftD.X <= p.X && p.X <= block.RightU.X)
                if (block.RightU.Y <= p.Y && p.Y <= block.LeftD.Y)
                    return true;
            //未发生碰撞
            return false;

        }
        //多个检测
        public bool collisionJudgeAll(PointF p, List<Block> listBlock)
        {
            foreach (Block b in listBlock)
                if (collisionJudge(p, b))
                    return true;
            return false;

        }
        //方向选择
        private void DirChooceMake(Map map)
        {
            //清空方向
            _listDir.Clear();
            for (int i = 0; i <= 3; i++)
            {
                dir DirectionTest = (dir)i;
                //获取与当前方向相反的方向，Hunter不立刻走回头路
                dir reverseD;//反方向
                if ((int)Direction % 2 == 0) reverseD = (dir)((int)Direction + 1);
                else reverseD = (dir)((int)Direction - 1);
                if (reverseD == DirectionTest) continue;

                //在矩形区上方,只能大幅上下移动，小幅左右移动
                if (Location.Y < map._RightUpPoint.Y)
                {
                    if (DirectionTest == dir.down)
                    {
                        _listDir.Add(dir.down);
                    }
                    else if (DirectionTest == dir.up)
                    {
                        if (Location.Y - Speed >= map._PassY)
                        {
                            _listDir.Add(dir.up);
                        }
                    }
                    else if (DirectionTest == dir.left)
                    {
                        //通道左端边界
                        if (Location.X - Speed >= map._PassXl)
                        {
                            _listDir.Add(dir.left);
                        }
                    }
                    else if (DirectionTest == dir.right)
                    {
                        //通道右端边界
                        if (Location.X + Speed <= map._PassXr)
                        {
                            _listDir.Add(dir.right);
                        }
                    }
                }
                //矩形区内,增加10的增量防止随player剧烈上下抖动
                else
                {
                    //上下左右边界
                    if (DirectionTest == dir.down)
                    {
                        //+10防止路上做无意义行动
                        float Ynew = Location.Y + Speed + 10;
                        //如果不发生碰撞
                        if (!collisionJudgeAll(new PointF(Location.X, Ynew), map._ListBlocks))
                            if (Ynew <= map._LeftDownPoint.Y)
                            {
                                _listDir.Add(dir.down);
                            }
                    }
                    else if (DirectionTest == dir.up)
                    {
                        //如果在中央通道,可以向上移动，且不增加增量
                        if (Location.X >= map._PassXl && Location.X <= map._PassXr)
                        {
                            float Ynew = Location.Y - Speed;
                            //如果不发生碰撞
                            if (!collisionJudgeAll(new PointF(Location.X, Ynew), map._ListBlocks))
                            {
                                _listDir.Add(dir.up);
                            }
                        }
                        else
                        {
                            float Ynew = Location.Y - Speed - 10;
                            //如果不发生碰撞
                            if (!collisionJudgeAll(new PointF(Location.X, Ynew), map._ListBlocks))
                                if (Ynew >= map._RightUpPoint.Y)
                                {
                                    _listDir.Add(dir.up);
                                }
                        }
                    }
                    else if (DirectionTest == dir.left)
                    {
                        float Xnew = Location.X - Speed - 10;
                        //如果不发生碰撞
                        if (!collisionJudgeAll(new PointF(Xnew, Location.Y), map._ListBlocks))
                            if (Xnew >= map._LeftDownPoint.X)
                            {
                                _listDir.Add(dir.left);
                            }
                    }
                    else if (DirectionTest == dir.right)
                    {
                        float Xnew = Location.X + Speed + 10;
                        //如果不发生碰撞
                        if (!collisionJudgeAll(new PointF(Xnew, Location.Y), map._ListBlocks))
                            if (Xnew <= map._RightUpPoint.X)
                            {
                                _listDir.Add(dir.right);
                            }
                    }

                }
            }
        }

        //绘图
        public override void Draw(Graphics g, bool speak,bool everyBodySay)
        {
            g.DrawImage(Pic, Location.X - 23, Location.Y - 55);
            if (speak)
            {
                float width = 130 / (Words.Length+1);
                PointF speakLoc=new PointF(Location.X - 10,Location.Y - 55 - 75);
                g.DrawImage(Dialog, speakLoc.X ,speakLoc.Y );
                Font font = new Font("黑体",width, FontStyle.Regular, GraphicsUnit.Pixel);
                SolidBrush bru = new SolidBrush(Color.Black);
                g.DrawString(Words, font,bru,(float)(speakLoc.X + width/2), (float)(speakLoc.Y+(60-width)/2));
                //在下方绘制语句
                Font font1=new Font("黑体",20,FontStyle.Regular,GraphicsUnit.Pixel);
                if (!everyBodySay)
                    g.DrawString(Words, font1, bru, (599 - Words.Length * 20) / 2, 1056);
                else
                    g.DrawString("一阵乱喊", font1, bru, (599 - 4 * 20) / 2, 1056);
            }
        }

 
    }

}
