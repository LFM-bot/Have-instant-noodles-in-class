using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace XlonRun
{
    public class Map
    {
        #region 私有字段
        //玩家出生点
        private Point _playBirthLoc;
        //老师出生点 
        private List<Point> _huntBirthLoc = new List<Point>();
        //中央通道左下角x坐标
        private int _passXl = 0;
        //中央通道右下角x坐标
        private int _passXr = 0;
        //中央通道顶端y坐标
        private int _passY = 0;
        //右上角，左上角坐标
        private Point _rightUpPoint;
        private Point _leftDownPoint;
        //阻挡块
        private List<Block> _listBlocks = new List<Block>();
        //定义逃生点序列,0到29的点坐标
        private Point[] _saver = new Point[30];
        //闯关级别
        private int _level = 1;
        //困难程度
        private Difficulty _difficulty = Difficulty.easy;
        //可逃离时间
        private int _outTime = 800;
        //游戏状态
        private GameState _gameState = GameState.ready;
        //出口是否打开
        private bool _ifYouCanGo = false;
        //记录游戏时间
        private int _playTime = 0;
        //记录分数
        private int _grade = 0;
        //逃生点
        private Point _savePoint = new Point(0, 0);
        //记录讲话时间
        private int _speakTime = 0;
        //讲话是否进行
        private List<bool> _ifSpeak = new List<bool>();
        //是否都说话
        private bool _everyBodySay = false;
        //你是否说话
        private bool _iSpeak = false;
        #endregion 

        #region 公有字段

        public Point _RightUpPoint
        {
          get { return _rightUpPoint; }
          set { _rightUpPoint = value; }
        }
        public Point _LeftDownPoint
        {
          get { return _leftDownPoint; }
          set { _leftDownPoint = value; }
        }
        public List<Block> _ListBlocks
        {
            get { return _listBlocks; }
            set { _listBlocks = value; }
        }
        public int _PassXl
        {
            get { return _passXl; }
            set { _passXl = value; }
        }
        public int _PassXr
        {
            get { return _passXr; }
            set { _passXr = value; }
        }
        public int _PassY
        {
            get { return _passY; }
            set { _passY = value; }
        }
        public Point[] _Saver
        {
            get { return _saver; }
            set { _saver = value; }
        }
        public Point _PlayBirthLoc
        {
            get { return _playBirthLoc; }
            set { _playBirthLoc = value; }
        }
        public List<Point> _HuntBirthLoc
        {
            get { return _huntBirthLoc; }
            set { _huntBirthLoc = value; }
        }
        public int _Level
        {
            get { return _level; }
            set { _level = value; }
        }
        public Difficulty _Difficulty
        {
            get { return _difficulty; }
            set { _difficulty = value; }
        }
        public int _OutTime
        {
            get { return _outTime; }
            set { _outTime = value; }
        }
        public GameState _GameState
        {
            get { return _gameState; }
            set { _gameState = value; }
        }
        public bool _IfYouCanGo
        {
            get { return _ifYouCanGo; }
            set { _ifYouCanGo = value; }
        }
        public int _PlayTime
        {
            get { return _playTime; }
            set { _playTime = value; }
        }
        public int _Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }
        public Point _SavePoint
        {
            get { return _savePoint; }
            set { _savePoint = value; }
        }
        public int _SpeakTime
        {
            get { return _speakTime; }
            set { _speakTime = value; }
        }
        public List<bool> _IfSpeak
        {
            get { return _ifSpeak; }
            set { _ifSpeak = value; }
        }
        public bool _EveryBodySay
        {
            get { return _everyBodySay; }
            set { _everyBodySay = value; }
        }
        public bool _ISpeak
        {
            get { return _iSpeak; }
            set { _iSpeak = value; }
        }
        #endregion 

        public Map(int level)
        {
            _level = level;
            if (level == 1)
            {
                _playBirthLoc = new Point(297, 631);
                _huntBirthLoc.Add(new Point(297, 631));
                _passXl = 291;
                _passXr = 305;
                _passY = 631;
                _rightUpPoint = new Point(542, 660);
                _leftDownPoint = new Point(57, 1046);
             
                //生成阻挡块
                _listBlocks.Add(new Block(new Point(73, 777), new Point(379, 688)));
                _listBlocks.Add(new Block(new Point(404, 898), new Point(528, 688)));
                _listBlocks.Add(new Block(new Point(73, 1019), new Point(199, 803)));
                _listBlocks.Add(new Block(new Point(224, 898), new Point(379, 803)));
                _listBlocks.Add(new Block(new Point(224, 1019), new Point(528, 922)));
                //加载救命点坐标序列
                _saver[0] = new Point(110, 667); _saver[1] = new Point(180, 667); _saver[2] = new Point(297, 667); _saver[3] = new Point(391, 667); _saver[4] = new Point(536, 667);
                _saver[5] = new Point(59, 718); _saver[6] = new Point(59, 789); _saver[7] = new Point(59, 891); _saver[8] = new Point(59, 1004);
                _saver[9] = new Point(116, 1032); _saver[10] = new Point(210, 1032); _saver[11] = new Point(304, 1032); _saver[12] = new Point(447, 1032); _saver[13] = new Point(536, 1032);
                _saver[14] = new Point(536, 740); _saver[15] = new Point(536, 826); _saver[16] = new Point(536, 906); _saver[17] = new Point(536, 991);
                _saver[18] = new Point(123, 791); _saver[19] = new Point(212, 791); _saver[20] = new Point(342, 791);
                _saver[21] = new Point(207, 837); _saver[22] = new Point(207, 914); _saver[23] = new Point(207, 988);
                _saver[24] = new Point(276, 906); _saver[25] = new Point(375, 906); _saver[26] = new Point(507, 906);
                _saver[27] = new Point(392, 719); _saver[28] = new Point(392, 791); _saver[29] = new Point(392, 869);
            }
            else if (level == 2)
            {
                _passXl = 420;
                _passXr = 448;
                _passY = 129;
                _rightUpPoint = new Point(787,160);
                _leftDownPoint = new Point(65,739);
                //出生点
                _playBirthLoc = new Point(428, 159);
                _huntBirthLoc.Add(new Point(75, 456));
                _huntBirthLoc.Add(new Point(428, 734));
                _huntBirthLoc.Add(new Point(782, 485));
                _huntBirthLoc.Add(new Point(428, 159));
                //生成阻挡块
                _listBlocks.Add(new Block(new Point(107, 245), new Point(539, 200))); _listBlocks.Add(new Block(new Point(590, 243), new Point(746, 200)));
                _listBlocks.Add(new Block(new Point(110, 350), new Point(225, 300))); _listBlocks.Add(new Block(new Point(271, 350), new Point(436, 300))); _listBlocks.Add(new Block(new Point(484, 350), new Point(746, 300)));
                _listBlocks.Add(new Block(new Point(113, 519), new Point(161, 392))); _listBlocks.Add(new Block(new Point(271, 568), new Point(308, 350))); _listBlocks.Add(new Block(new Point(582, 576), new Point(630, 350))); _listBlocks.Add(new Block(new Point(691, 527), new Point(743, 396)));
                _listBlocks.Add(new Block(new Point(115, 609), new Point(309, 568))); _listBlocks.Add(new Block(new Point(356, 609), new Point(420, 568))); _listBlocks.Add(new Block(new Point(467, 609), new Point(648, 567))); _listBlocks.Add(new Block(new Point(689, 609), new Point(743, 564)));
                _listBlocks.Add(new Block(new Point(115, 699), new Point(203, 656))); _listBlocks.Add(new Block(new Point(311, 697), new Point(743, 657)));
                //加载逃生点坐标序列
                _saver[0] = new Point(147, 272); _saver[1] = new Point(682, 268); _saver[2] = new Point(447, 465); _saver[3] = new Point(251, 666); _saver[4] = new Point(599, 636);

            }
        }
        //生成逃生时间
        public void CreateOutTime()
        {
            if (_level == 1)
            {
                //生成逃生点
                if (_difficulty == Difficulty.easy)
                    _outTime = 800;
                else if (_difficulty == Difficulty.normal)
                    _outTime = 90;
                else
                    _outTime = 1100;
            }
            else if (_level == 2)
                _outTime = 600;
        }
        //生成逃生点
        public void CreateOutDoor()
        {
            int j=0;
            Random ran = new Random(DateTime.Now.Second);
            if(_level==1)
             j= ran.Next(0, 30);
            else
             j = ran.Next(0, 5);   
            _savePoint = _saver[j];
            _ifYouCanGo = true;
        }
        //输了
        public void GameOver()
        {
            //游戏时间清零
            _Grade = _PlayTime;
            _PlayTime = 0;
            //修改状态
            _GameState = GameState.lose;
            //关闭出口
            _IfYouCanGo = false;
            //讲话时间清零
            _SpeakTime = 0;
            _IfSpeak.Clear();
            _iSpeak=false;
            _everyBodySay = false;
        }
        //赢了
        public void YouWin()
        {
            //你赢了
            _GameState = GameState.win;
            //关闭出口
            _IfYouCanGo = false;
            //游戏时间清零
            _Grade = _PlayTime;
            _PlayTime = 0;
            //讲话时间清零
            _SpeakTime = 0;
            _IfSpeak.Clear();
            _iSpeak = false;
            _everyBodySay = false;
        }
        //说话
        public bool SpeakTurn()
        {
            bool stop = true;
            _SpeakTime++;
            //优先你说话
            if (_ISpeak)
            {
                if (_SpeakTime == 80)
                {
                    _ISpeak = false;
                    _SpeakTime = 0;
                    return stop;

                }
            }
            //一个老师说话
            else if (!_EveryBodySay)
            {
                //最后一个老师说话
                _IfSpeak[_IfSpeak.Count - 1] = true;

                if (_SpeakTime == 80)
                {
                    _SpeakTime = 0;
                    _IfSpeak[_IfSpeak.Count - 1] = false;
                    return stop;
                }
            }
            //所有老师都说话
            else if (_EveryBodySay)
            {
                for (int i = 0; i < _IfSpeak.Count; i++)
                    _IfSpeak[i] = true;
                if (_SpeakTime == 80)
                {
                    _SpeakTime = 0;
                    for (int i = 0; i < _IfSpeak.Count; i++)
                        _IfSpeak[i] = false;
                    _EveryBodySay = false;
                    return stop;

                }

            }
            return false;
        }
    }
}
