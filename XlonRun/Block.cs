using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace XlonRun
{
    public class Block
    {
        //四个点坐标
        private Point _rightU;
        private Point _leftD;

        public Point RightU
        {
            get { return _rightU; }
            set { _rightU = value; }
        }
        public Point LeftD
        {
            get { return _leftD; }
            set { _leftD = value; }
        }
        //构造函数
        public Block(Point leftD, Point rightU)
        {
            _leftD = leftD;
            _rightU = rightU;
        }

    }
}
