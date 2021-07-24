using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace XlonRun
{

    public enum Difficulty
    {
        easy, normal, hard
    }
    public enum GameState
    {
        ready, start, lose, win
    }
    public partial class FormMain : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetAsyncKeyState(int keycode);
        #region 私有字段
        //游戏胜利图片
        private Bitmap _gameWin = null;
        //游戏开始前背景
        private Bitmap _startBack = null;
        //游戏说明背景
        private Bitmap _howToPlayBack = null;
        //开始按键图片1、2
        private Bitmap _startBmp1 = null, _startBmp2 = null;
        //方法按键图片1、2
        private Bitmap _howBmp1 = null, _howBmp2 = null;
        //返回按键图片1、2
        private Bitmap _returnBmp1 = null, _returnBmp2 = null;
        //人物正反图片
        private Bitmap _playerFront = null;
        private Bitmap _playerSide = null;
        private Bitmap _playerLeft = null;
        private Bitmap _playerRight = null;
        //思考图片
        private Bitmap _thinking = null;
        private Bitmap _speak = null;
        //UFO图片
        private Bitmap _ufo = null;

        //图片滑动次数
        private int _count = 0, _countStop = 0;
        
        //地图
        public Map map = new Map(1);
        //玩家对象
        private Player _player = new Player();
        //定义hunter序列
        private List<Hunter> _listHunters = new List<Hunter>();
        //定义Hunter语句库
        private List<string> _listSentence = new List<string>();
        //定义你的语句库
        private List<string> _listYourSen = new List<string>();
        //视频实例
        private bool _video = false;
        //歌曲播放的位置
        private double _location = 0;
        #endregion
        public FormMain()
        {
            InitializeComponent();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //加载图片
            _gameWin = new Bitmap("images//你赢了.png");

            _startBack = new Bitmap("images//背景图.png");
            _howToPlayBack = new Bitmap("images//游戏方法.png");
            //按键图片
            _startBmp1 = new Bitmap("images//开始1.png");
            _startBmp2 = new Bitmap("images//开始2.png");

            _howBmp1 = new Bitmap("images//方法1.png");
            _howBmp2 = new Bitmap("images//方法2.png");

            _returnBmp1 = new Bitmap("images//返回1.png");
            _returnBmp2 = new Bitmap("images//返回2.png");

            _playerFront = new Bitmap("images//人物正面.png");
            _playerSide = new Bitmap("images//人物背面.png");
            _playerLeft = new Bitmap("images//人物左面.png");
            _playerRight = new Bitmap("images//人物右面.png");

            _thinking = new Bitmap("images//思考.png");
            _speak = new Bitmap("images//对话框空白.png");
            _ufo = new Bitmap("images//大UFO.png");

            //加载语句库
            _listSentence.Add("小兔崽子你给我回来");
            _listSentence.Add("我的课都敢逃？！");
            _listSentence.Add("你这是自取灭亡!");
            _listSentence.Add("玩物丧志，可悲!");
            _listSentence.Add("我抽你丫的");
            _listSentence.Add("恨铁不成钢呐");
            _listSentence.Add("本科也叫上过学？？");
            _listSentence.Add("让我的粉笔头感化你");
            _listSentence.Add("为人师表，玉树临风，");
            _listSentence.Add("我吃你个大头鬼啊");
            _listSentence.Add("讲话吸引你注意！");
            _listSentence.Add("小东西束手就擒吧");
            _listSentence.Add("有本事挑战困难呀");
            _listSentence.Add("啊，天下怎会有我这等美男子");

            _listYourSen.Add("吃到面就算我赢哦");
            _listYourSen.Add("哼，糟老头子坏的很");
            _listYourSen.Add("呵，真啰嗦");
            _listYourSen.Add("小爷我吃面去喽");
            _listYourSen.Add("逃课旷课，我滴日常");
            _listYourSen.Add("生活快乐似神仙呐");
            _listYourSen.Add("看我蛇皮走位");
            _listYourSen.Add("胃口好，吃嘛嘛香");
            _listYourSen.Add("面还在煮哦");
            _listYourSen.Add("困难模式通关有彩蛋哦");

            BGM.settings.volume = 100;
            BGM.Ctlcontrols.play();
             _player.Dialog = _speak;
            //显示游戏界面
            pictureBox1.Image = _startBack;
            //隐藏按键
            buttonReturn.Visible = false;

            //音乐播放
            Thread thread = new Thread(new ThreadStart(PlayThread));
            thread.Start();

            
        }

        private void buttonHowToPlay_Click(object sender, EventArgs e)
        {
            //切换背景
            pictureBox1.Image = _howToPlayBack;
            //隐藏开始、说明按键
            buttonStart.Visible = false;
            buttonHowToPlay.Visible = false;
            //显示说明界面开始按键
            buttonReturn.Visible = true;
            buttonT.Visible = true;
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            //切换背景
            pictureBox1.Image = _startBack;
            //隐藏开始、说明按键
            buttonStart.Visible = true ;
            buttonHowToPlay.Visible = true;
            //显示说明界面开始按键
            buttonReturn.Visible = false;
            buttonT.Visible = false;
        }

        private void buttonStart_MouseMove(object sender, MouseEventArgs e)
        {
            buttonStart.Image = _startBmp2;
        }

        private void buttonStart_MouseLeave(object sender, EventArgs e)
        {
            buttonStart.Image = _startBmp1;
        }

        private void buttonHowToPlay_MouseMove(object sender, MouseEventArgs e)
        {
            buttonHowToPlay.Image = _howBmp2;
        }

        private void buttonHowToPlay_MouseLeave(object sender, EventArgs e)
        {
            buttonHowToPlay.Image = _howBmp1;
        }

        private void buttonReturn_MouseMove(object sender, MouseEventArgs e)
        {
            buttonReturn.Image = _returnBmp2;
        }

        private void buttonReturn_MouseLeave(object sender, EventArgs e)
        {
            buttonReturn.Image = _returnBmp1;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //隐藏开始、说明按键
            buttonStart.Visible = false;
            buttonHowToPlay.Visible = false;
            //打开定时器，移动pictureBox1
            timerPicMove.Enabled = true;
            //影藏菜单栏
            menuStrip1.Visible = false;
            //生成逃生时间
            map.CreateOutTime();
        }

        



        //失败绘制
        private void GradeDraw(Graphics g){
            string ack;
            if (map._Level == 1)
            {
                if (map._Grade <= 300)
                    ack = " 一败涂地 " + (map._Grade / 10).ToString() + "分";
                else if (map._Grade <= 600)
                    ack = " 小有所成 " + (map._Grade / 10).ToString() + "分";
                else if (map._Grade < 850)
                    ack = " 功力深厚 " + (map._Grade / 10).ToString() + "分";
                else
                    ack = " 大师风范呐 " + (map._Grade / 10).ToString() + "分";
                SolidBrush bru = new SolidBrush(Color.Yellow);
                //显示分数
                Font font = new Font("宋体", 70, FontStyle.Regular, GraphicsUnit.Pixel);
                g.DrawString(ack, font, bru, 0, 70);
                
            }
            else
            {
                if (map._Grade <= 200)
                    ack = " 身败名裂 " + (map._Grade / 10).ToString() + "分";
                else if (map._Grade <= 600)
                    ack = " 夜郎自大 " + (map._Grade / 10).ToString() + "分";
                else if (map._Grade < 750)
                    ack = " 斗中强者 " + (map._Grade / 10).ToString() + "分";
                else
                    ack = " 真乃神人也 " + (map._Grade / 10).ToString() + "分";
                SolidBrush bru = new SolidBrush(Color.Black);
                //显示分数
                Font font = new Font("华文琥珀", 100, FontStyle.Regular, GraphicsUnit.Pixel);
                g.DrawString(ack, font, bru, 0, 70);
            }
            
        }
        //绘制人物和猎手
        private void Draw(Graphics g)
        {
            
            if (map._GameState==GameState.start)
            {
                //绘制人物
                _player.Draw(g,map._ISpeak);
                //绘制猎手
                for (int i = 0; i < _listHunters.Count; i++)
                    _listHunters[i].Draw(g, map._IfSpeak[i],map._EveryBodySay);

                //判断游戏是否结束     
                foreach(Hunter h in _listHunters)
                    if (Math.Sqrt(Math.Pow(h.Location.X - _player.Location.X, 2) +
                                 Math.Pow(h.Location.Y - _player.Location.Y, 2)) < 27)
                    {
                        GameOver();
                        return;
                    }
                //绘制出口
                if (map._IfYouCanGo)
                {
                    g.DrawImage(_ufo, (float)(map._SavePoint.X - 32.5), (float)(map._SavePoint.Y - 32.5));
                    if (Math.Sqrt(Math.Pow(map._SavePoint.X - _player.Location.X, 2) +
                                 Math.Pow(map._SavePoint.Y - _player.Location.Y, 2)) < 27)
                        GameWin();
                }
            }
            else if (map._GameState==GameState.lose||map._GameState==GameState.win)
            {
                GradeDraw(g);
            }
            if (map._GameState==GameState.win && map._Difficulty == Difficulty.hard)
            {
                Font font1 = new Font("黑体",15, FontStyle.Bold,GraphicsUnit.Pixel);
                SolidBrush bru = new SolidBrush(Color.Orange);
                #region 通关
                g.DrawString("本游戏制作于2019年11月17日，历时4天。", font1, bru, 5, 492);
                g.DrawString("期间熬着夜，却不感到疲倦，怀着一种做好游戏的热情，一直前进着。", font1, bru, 5, 492 + 19);
                g.DrawString("想过游戏的难度是否太高了，但你能看到这里，或许也并非如此。", font1, bru, 5, 492 + 19 * 2);
                g.DrawString("真不希望你是从一行行代码中看到我，哈哈，你是真的通关了吧。", font1, bru, 5, 492 + 19 * 3);
                g.DrawString("这里感谢十面埋伏的作者，从他那学会了很多，虽然我还不知道他的名字(憨笑)。", font1, bru, 5, 492 + 19 * 4);
                g.DrawString("最后感谢一波我的npy,在这4天里，发生了很多，感谢有她陪伴(猛虎含泪)。", font1, bru, 5, 492 + 19 * 5);
                g.DrawString("加油吧骚年，期待你做出更好玩的游戏！", font1, bru, 5, 492 + 19 * 6);
                #endregion
            }

            
        }
        //游戏结束
        private void GameOver()
        {

            if (map._Level == 1)
            {
                //显示按键
                buttonAgain.Visible = true;
                pictureBox1.Image = Properties.Resources.你哭了1;
            }
            else
            {
                buttonLevel2Again.Visible = true;
                pictureBox1.Image = Properties.Resources.你哭了2;
            }
            //调整图片位置
            pictureBox1.Location = new Point(0, 0);
            
            //人物移动关闭
            timerPlayerMove.Enabled = false;
            //Hunter移动关闭
            timerHunterMove.Enabled = false;
            TimerHunterShow.Enabled = false;
            _listHunters.Clear();
            
            //暂停游戏声音
             BGM.Ctlcontrols.pause();
            //修改地图属性
             map.GameOver();
          
            //防止还没讲话就被抓出现的异常
            timerSpeak.Enabled = false;
        }

        //你赢了！！
        private void GameWin()
        {
            //暂停游戏声音
            BGM.Ctlcontrols.pause();
            //修改地图属性
            map.YouWin();
            if (map._Level == 1)
            {
                //显示按键
                buttonAgain.Visible = true;
                if (map._Difficulty == Difficulty.hard)
                    pictureBox1.Image = Properties.Resources.你赢了困难;
                else
                    pictureBox1.Image = _gameWin;
                //如果通关简单以上，可以进行下一关
                if (map._Difficulty != Difficulty.easy)
                    buttonNextLevel.Visible = true;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.过关2;
                BGM.URL = "songs//擱淺.mp3";
                BGM.Ctlcontrols.play();
            }
            //调整图片位置
            pictureBox1.Location = new Point(0, 0);
            //人物移动关闭
            timerPlayerMove.Enabled = false;
            //Hunter移动关闭
            timerHunterMove.Enabled = false;
            TimerHunterShow.Enabled = false;
            _listHunters.Clear();
            
           
            //防止出现的异常
            timerSpeak.Enabled = false;
            
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }
        
        //生成一个猎手
        public void CreateHunter()
        {
            Teacher tch = new Teacher(map._Difficulty, map._Level);
            if (map._PlayTime <= 250)
                tch.Pic = new Bitmap("images//语文老师.png");
            else if (map._PlayTime <= 500)
                tch.Pic = new Bitmap("images//英语老师.png");
            else if (map._PlayTime <= 700)
                tch.Pic = new Bitmap("images/校长.png");
            else if (map._PlayTime <= 900)
                tch.Pic = new Bitmap("images//教授.png");
            else
                tch.Pic = new Bitmap("images//神奇生物.png");
            tch.Dialog = _speak;
            Random rand=new Random(DateTime.Now.Second);
            tch.Location = map._HuntBirthLoc[rand.Next(0,map._HuntBirthLoc.Count)];//出生点
            map._IfSpeak.Add(false);
            _listHunters.Add(tch);
            //生成随机语录
            Random random = new Random(DateTime.Now.Second);
            int i = random.Next(_listSentence.Count);
            tch.Words = _listSentence[i];
            //开始讲话
            timerSpeak.Enabled = true;
        }
        //猎手移动
        private void timerHunterMove_Tick(object sender, EventArgs e)
        {
            foreach (Hunter h in _listHunters)
                h.Move(map,_player.Location);
        }


        private void buttonAgain_Click(object sender, EventArgs e)
        {
            //切换背景
            pictureBox1.Image = _startBack;
            //显示开始、说明按键
            buttonStart.Visible = true;
            buttonHowToPlay.Visible = true;
            //隐藏再玩、下一关按键
            buttonAgain.Visible = false;
            buttonNextLevel.Visible = false;
            //打开音乐
            BGM.Ctlcontrols.play();
            //改为准备状态
            map._GameState = GameState.ready;
            //显示菜单栏
            menuStrip1.Visible = true;
        }

        private void buttonAgain_MouseMove(object sender, MouseEventArgs e)
        {
            buttonAgain.Image = Properties.Resources.再玩一次21;
        }

        private void buttonAgain_MouseLeave(object sender, EventArgs e)
        {
            buttonAgain.Image = Properties.Resources.再玩一次12;
        }


        //控制人物移动
        private void timerPlayerMove_Tick(object sender, EventArgs e)
        {
            if (map._GameState==GameState.start)
            {
                _player.Direction = dir.none;
                bool KeyDown = (((ushort)GetAsyncKeyState((int)Keys.Down)) & 0xffff) != 0;
                if (KeyDown == true) { _player.Direction = dir.down; _player.Move(map); }

                bool KeyUp = (((ushort)GetAsyncKeyState((int)Keys.Up)) & 0xffff) != 0;
                if (KeyUp == true) { _player.Direction = dir.up; _player.Move(map); }

                bool KeyLeft = (((ushort)GetAsyncKeyState((int)Keys.Left)) & 0xffff) != 0;
                if (KeyLeft == true) { _player.Direction = dir.left; _player.Move(map); }

                bool KeyRight = (((ushort)GetAsyncKeyState((int)Keys.Right)) & 0xffff) != 0;
                if (KeyRight == true) { _player.Direction = dir.right; _player.Move(map); }

                if (KeyUp == true)
                    _player.Pic = _playerSide;
                else if (KeyLeft == true)
                    _player.Pic = _playerLeft;
                else if(KeyRight==true)
                    _player.Pic = _playerRight;
                else 
                    _player.Pic = _playerFront;

                //刷新
                pictureBox1.Invalidate();
            }
        }
    
        private void timerHunterShow_Tick(object sender, EventArgs e)
        {
            //用于记录随机的刷怪时间
            int leftTime = 120;
            map._PlayTime++;
            
            //空投泡面,出现出口
            if (map._PlayTime == map._OutTime)
            {
                map.CreateOutDoor();
            }
            //多人说话
            if (map._PlayTime % 200 == 0 || map._PlayTime == 650)
            {
                map._EveryBodySay = true;
                timerSpeak.Enabled = true;
            }
            //你讲话
            if (map._PlayTime % 170 == 0)
            {
                Random random = new Random(DateTime.Now.Second);
                int i = random.Next(0, _listYourSen.Count);
                _player.Words = _listYourSen[i];

                map._ISpeak = true;
                timerSpeak.Enabled = true;
            }
            //生成猎手
            if (map._Level == 1)
            {
                if (map._PlayTime == 50)
                {
                    //刷怪
                    CreateHunter();
                }
                else if (map._PlayTime % 100 == 0)
                {

                    //记录随机刷怪时间
                    Random random = new Random(DateTime.Now.Second);
                    //简单模式15到16秒刷怪
                    if (map._Difficulty == Difficulty.easy)
                        leftTime = random.Next(150, 160);//111到150
                    else if (map._Difficulty == Difficulty.normal)
                        leftTime = random.Next(110, 130);
                    else
                        leftTime = random.Next(80, 130);
                }
                else if (map._PlayTime % (leftTime) == 0)
                {
                    //刷怪
                    CreateHunter();
                }
            }
            else
            {
                if (map._PlayTime % 50 == 0)
                {
                    //刷怪
                    CreateHunter();
                }
            }

        }

        private void timerSpeak_Tick(object sender, EventArgs e)
        {

            if(map.SpeakTurn())
                timerSpeak.Enabled = false;
            //我说话
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            #region 不起作用
            if (Math.Sqrt(Math.Pow(e.X - _player.Location.X, 2) + Math.Pow(e.Y - (_player.Location.Y-40), 2)) < 5)
                Slabel1.Text = "My favorite girl is LWN , and yours ?";
            else
                Slabel1.Text = "";
            #endregion
        }

        private void MenuItemEsay_Click(object sender, EventArgs e)
        {
            MenuItemEsay.Image = Properties.Resources.确认;
            MenuItemNormal.Image = null;
            MenuItemHard.Image = null;
            map._Difficulty = Difficulty.easy;
        }

        private void MenuItemNormal_Click(object sender, EventArgs e)
        {
            MenuItemEsay.Image = null;
            MenuItemNormal.Image = Properties.Resources.确认;
            MenuItemHard.Image = null;
            map._Difficulty = Difficulty.normal;
        }

        private void MenuItemHard_Click(object sender, EventArgs e)
        {
            MenuItemEsay.Image = null;
            MenuItemNormal.Image = null;
            MenuItemHard.Image = Properties.Resources.确认;
            map._Difficulty = Difficulty.hard;
        }

        private void BGM_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (BGM.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                //如果视屏播放完，从歌曲断点开始
                if (_video == true)
                {
                    _video = false;
                    BGM.Visible = false;
                    this.Size = new Size(608, 679);
                    //修改位置
                    int width = Screen.PrimaryScreen.Bounds.Width;
                    int height = Screen.PrimaryScreen.Bounds.Height;
                    this.Location = new Point((width - 608) / 2, (height - 679) / 2);
                }
                //如果是歌曲播放完，则从头开始
                else
                    _location = 0;
                Thread thread = new Thread(new ThreadStart(PlayThread));
                thread.Start();
            } 

        }

        private void PlayThread()
        {
            if (map._Level == 1)
            {
                BGM.URL = "songs//BGM.WAV"; //音乐文件
                BGM.Ctlcontrols.currentPosition = _location;
            }
            else
                BGM.URL = "songs//半獸人.mp3"; //音乐文件
            BGM.Ctlcontrols.play();
        }

        private void buttonNextLevel_MouseLeave(object sender, EventArgs e)
        {
            buttonNextLevel.Image = Properties.Resources.下一关1;
        }

        private void buttonNextLevel_MouseMove(object sender, MouseEventArgs e)
        {
            buttonNextLevel.Image = Properties.Resources.下一关2;
        }

        private void buttonNextLevel_Click(object sender, EventArgs e)
        {
            //游戏准备开始开始
            map._GameState = GameState.ready;
            this.Size = new Size(850, 820);
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - 450, 0);
            pictureBox1.Size = new Size(850, 787);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile("images//第二关背景.png");
            //清空计时
            //隐藏再玩、下一关按键
            buttonAgain.Visible = false;
            buttonNextLevel.Visible = false;
            //隐藏状态栏
            statusStrip1.Visible = false;
            //生成新地图
            map = new Map(2);
            //生成逃生时间
            map.CreateOutTime();
            //打开定时器
            timerStart.Enabled = true;
            pictureBox1.Invalidate();
            //音乐播放
            Thread thread = new Thread(new ThreadStart(PlayThread));
            thread.Start();
        }

        private void timerPicMove_Tick(object sender, EventArgs e)
        {
            _count++;
            //pictureBox移动速度
            double vy = 4.53;
            if (pictureBox1.Location.Y > -453)
            {
                pictureBox1.Location = new Point(0, (int)(_count * vy * (-1)));
                //重新加载图片
                pictureBox1.Image = _startBack;
            }
            else 
            {
                _countStop = _count;
                timerStart.Enabled = true;
                timerPicMove.Enabled = false;
            }

        }

        private void timerStart_Tick(object sender, EventArgs e)
        {
            _count++;
            //绘制人物0.2秒
            if (_count < _countStop + 20)
            {
                if (_count == _countStop + 1)
                {
                    _player.Location = map._PlayBirthLoc;
                    _player.Pic = _playerFront;
                    Graphics g = pictureBox1.CreateGraphics();
                    g.DrawImage(_playerFront, map._PlayBirthLoc.X - 27, map._PlayBirthLoc.Y - 55);
                }
            }
            //再绘制对话框0.8秒
            else if (_count < _countStop + 100)
            {
                if (_count == _countStop + 20)
                {
                    ////说话
                    Graphics g = pictureBox1.CreateGraphics();
                    //调整图片位置
                    g.DrawImage(_thinking, map._PlayBirthLoc.X + 5, map._PlayBirthLoc.Y - 55 - 110);
                    //g.DrawImage(_speak, 297 -10, 631 - 55 - 75);
                    //在状态栏上说话
                    if (map._Level == 1)
                    {
                        SolidBrush bru = new SolidBrush(Color.Black);
                        Font font1 = new Font("黑体", 20, FontStyle.Regular, GraphicsUnit.Pixel);
                        g.DrawString("啊，好想吃面！！！", font1, bru, (599 - 9 * 20) / 2, 1056);
                    }
                }

            }
            else
            {
                
                //清空_count
                _count = 0;
                _countStop = 0;
                //关闭Start
                timerStart.Enabled = false;
                //游戏开始
                map._GameState = GameState.start;
                timerPlayerMove.Enabled = true;
                timerHunterMove.Enabled = true;
                //开始计时
                TimerHunterShow.Enabled = true;
                pictureBox1.Invalidate();
            }
        }

        private void buttonLevel2Again_MouseLeave(object sender, EventArgs e)
        {

            buttonLevel2Again.Image = Properties.Resources.再玩一次12;
        }

        private void buttonLevel2Again_MouseMove(object sender, MouseEventArgs e)
        {
            buttonLevel2Again.Image = Properties.Resources.再玩一次21;
        }

        private void buttonLevel2Again_Click(object sender, EventArgs e)
        {
            //游戏准备开始开始
            map._GameState = GameState.ready;
            pictureBox1.Image = Image.FromFile("images//第二关背景.png");
            buttonLevel2Again.Visible = false;
            //生成逃生时间
            map.CreateOutTime();
            //打开定时器
            timerStart.Enabled = true;
            //打开音乐
            BGM.Ctlcontrols.play();
            //重绘
            pictureBox1.Invalidate();
        }

        private void buttonT_Click(object sender, EventArgs e)
        {
            //保存歌曲进度
            _location = BGM.Ctlcontrols.currentPosition;
            _video = true;
            BGM.Visible = true;
            BGM.Size = new Size(1000, 570);
            BGM.Location = new Point(0, 0);
            this.Size = new Size(1000, 570);
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point((width - 1000) / 2, (height - 570) / 2);
            BGM.URL = "video//实例.mp4";
            BGM.Ctlcontrols.play();
            BGM.Focus();
        }

        private void BGM_KeyDownEvent(object sender, AxWMPLib._WMPOCXEvents_KeyDownEvent e)
        {
            if (e.nKeyCode == (ushort)Keys.Escape)
            {
                _video = false;
                BGM.Visible = false;
                this.Size = new Size(608, 679);
                int width = Screen.PrimaryScreen.Bounds.Width;
                int height = Screen.PrimaryScreen.Bounds.Height;
                this.Location = new Point((width - 608) / 2, (height - 679) / 2);
                //音乐播放
            
                Thread thread = new Thread(new ThreadStart(PlayThread));
                thread.Start();
            }
            else if (e.nKeyCode == (ushort)Keys.Left)
                BGM.Ctlcontrols.currentPosition -= 5;
            else if (e.nKeyCode == (ushort)Keys.Right)
                BGM.Ctlcontrols.currentPosition += 5;
        }

        private void buttonT_MouseLeave(object sender, EventArgs e)
        {
            buttonT.Image = Properties.Resources.视频1;
        }

        private void buttonT_MouseMove(object sender, MouseEventArgs e)
        {
            buttonT.Image = Properties.Resources.视频2;
        }











    }
}
