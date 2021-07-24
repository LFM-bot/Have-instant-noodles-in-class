using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace XlonRun
{
    public enum dir
    {
        down = 0, up = 1, left = 2, right = 3, none = 4
    };
    class Player
    {
        private string _words = "呵，啰嗦";

        public string Words
        {
            get { return _words; }
            set { _words = value; }
        }
        private Bitmap _Dialog;

        public Bitmap Dialog
        {
            get { return _Dialog; }
            set { _Dialog = value; }
        }
        private Point _location;
        private Bitmap _pic;
        private int _speed;
        private dir _direction;
        public Point Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public Bitmap Pic
        {
            get { return _pic; }
            set { _pic = value; }
        }
        public dir Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        //构造函数
        public Player()
        {
            _speed = 3;
        }

        //移动              PUpRight(542,660)
        //            -------
        //           |       |
        //           |       |
        //           |       |
        //            -------
        //PDownLeft(57,1046)
        public void Move(Map map)
        {
            //在矩形区上方,只能大幅上下移动，小幅左右移动
            if (_location.Y < map._RightUpPoint.Y)//660
            {
                if (_direction == dir.down)
                {
                    _location.Y += _speed;
                }
                else if (_direction == dir.up)
                {
                    if (_location.Y - _speed >= map._PassY)
                        _location.Y -= _speed;
                }
                else if (_direction == dir.left)
                {
                    //通道左端边界
                    if (_location.X - _speed >= map._PassXl)
                        _location.X -= _speed;
                }
                else if (_direction == dir.right)
                {
                    //通道右端边界
                    if (_location.X + _speed <= map._PassXr)
                        _location.X += _speed;
                }
            }
            //矩形区内
            else
            {
                //上下左右边界
                if (_direction == dir.down)
                {
                    int Ynew=_location.Y + _speed;
                    //如果不发生碰撞
                    if(!collisionJudgeAll(new Point(_location.X,Ynew),map._ListBlocks))
                        if (Ynew <= map._LeftDownPoint.Y)
                            _location.Y += _speed;
                }
                else if (_direction == dir.up)
                {
                    //如果在中央通道,可以向上移动
                    if(_location.X>=map._PassXl &&_location.X<=map._PassXr){
                        int Ynew = _location.Y - _speed;
                        //如果不发生碰撞
                        if (!collisionJudgeAll(new Point(_location.X, Ynew), map._ListBlocks))
                            _location.Y -= _speed;
                    }
                    else 
                    {
                        int Ynew = _location.Y - _speed;
                        //如果不发生碰撞
                        if (!collisionJudgeAll(new Point(_location.X, Ynew), map._ListBlocks))
                            if (Ynew >= map._RightUpPoint.Y)
                                _location.Y -= _speed;
                    }
                }
                else if (_direction == dir.left)
                {
                     int Xnew=_location.X - _speed;
                     //如果不发生碰撞
                     if (!collisionJudgeAll(new Point(Xnew, _location.Y), map._ListBlocks))
                        if (Xnew >= map._LeftDownPoint.X)
                            _location.X -= _speed;
                }
                else if (_direction == dir.right)
                {
                    int Xnew = _location.X + _speed;
                    //如果不发生碰撞
                    if (!collisionJudgeAll(new Point(Xnew, _location.Y), map._ListBlocks))
                        if (Xnew <= map._RightUpPoint.X)
                            _location.X += _speed;
                }
            }
        }

        //判断是否进入矩形区，单个检测
        private bool collisionJudge(Point p, Block block)
        {
            //发生碰撞
            if (block.LeftD.X <= p.X && p.X <= block.RightU.X)
                if (block.RightU.Y <= p.Y && p.Y <= block.LeftD.Y)
                    return true;
            //未发生碰撞
            return false;

        }
        //多个检测
        public bool collisionJudgeAll(Point p,List<Block> listBlock)
        {
            foreach(Block b in listBlock)
                if(collisionJudge(p,b))
                    return true;
            return false;

        }
        //绘图与讲话
        public void Draw(Graphics g,bool speak)
        {
                g.DrawImage(_pic, _location.X - 27, _location.Y - 55);
                if (speak)
                {
                    float width = 130 / (Words.Length + 1);
                    Point speakLoc = new Point(Location.X - 10, Location.Y - 55 - 75);
                    g.DrawImage(Dialog, speakLoc.X, speakLoc.Y);
                    Font font = new Font("黑体", width, FontStyle.Regular, GraphicsUnit.Pixel);
                    SolidBrush bru = new SolidBrush(Color.Black);
                    g.DrawString(Words, font, bru, (float)(speakLoc.X + width / 2), (float)(speakLoc.Y + 30 - width / 2));
                    //在下方绘制语句
                    Font font1 = new Font("黑体", 20, FontStyle.Regular, GraphicsUnit.Pixel);
                    g.DrawString(Words, font1, bru, (599 - Words.Length * 20) / 2, 1056);
                }
        }
    }
}
