using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace testJump
{
    [Serializable]
    public partial class Form1 : Form
    {
        private Bitmap fon, fonPause;//фон
        private Bitmap fon1, fonPause1;//фон
        Graphics dc, dcfon1;//графика
        PrivateFontCollection custom_font = new PrivateFontCollection();//шрифт
        Player pl;//игрок
        List<Platforms> listPlatform = new List<Platforms>();//список платформ
        List<Bonus> listBonus = new List<Bonus>();//список бонусов
        List<Bullet> listBullet = new List<Bullet>();//список пуль
        List<Monsters> listMonsters = new List<Monsters>();//список монстров
        Random rnd = new Random();//рандом
        int dy = 0;//расстояние по оси у
        int rndColor;//рандомный цвет
        int g;//джи
        int scores = 0;//очки
        bool checkStopStart = false;//флаг паузы
        Rectangle pause;//поле паузы
        Bitmap pauseSkin = Properties.Resources.Pause;//скин паузы
        string fileScores = "Scores.txt";//имя файла
        string[] scoresfile;//массив результатов
        bool checkGodMode = false;

        public Form1()
        {
            InitializeComponent();
            scoresfile = File.ReadAllLines(fileScores);
            FontLoad();
            dc = this.CreateGraphics();
            fon = new Bitmap(Properties.Resources.bck_2x);
            fon1 = new Bitmap(Properties.Resources.bck_2x);
            fonPause = new Bitmap(Properties.Resources.pauseOnBck);
            fonPause1 = new Bitmap(Properties.Resources.pauseOnBck);
            dcfon1 = Graphics.FromImage(fon1);
            createLevel();
        }//конструктор

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < listMonsters.Count; i++)
            {
                if (listMonsters[i].check() == 2 || listMonsters[i].check() == 3)
                {
                    listMonsters[i].moveLeftRight(this);
                }

                if (pl.PlBounds().IntersectsWith(listMonsters[i].boundMonster()) && pl.getSpeedY() > 0 && pl.PlBounds().Bottom > listMonsters[i].getCoordY() && pl.getLive())
                {
                    listMonsters[i].checkDieMon();
                    pl.setSpeedY(pl.getSpeedJump() - 5);
                }
                else if (pl.PlBounds().IntersectsWith(listMonsters[i].boundMonster()) && pl.getLive())
                {
                    pl.checkDie();
                }
                else for (int j = 0; j < listBullet.Count; j++)
                {
                    if(listBullet[j].boundRect().IntersectsWith(listMonsters[i].boundMonster()))
                    {
                            listMonsters[i].checkHP();
                            listBullet[i].checkDel();
                    }
                }
            }

            for (int i = 0; i < listBonus.Count; i++)
            {
                if (pl.PlBounds().IntersectsWith(listBonus[i].boundsBonus()) && pl.getSpeedY() > 0 && pl.getLive())
                {
                    pl.checkBonus(listBonus[i].check());
                    listBonus[i].checkPlayer();
                }
            }

            for (int i = 0; i < listPlatform.Count; i++)
            {
                //if(pl.PlBounds().IntersectsWith(plat.PlatListBounds()[i].PlatBounds()) && ((pl.PlBounds().Bottom > plat.PlatListBounds()[i].getCoordY() && pl.PlBounds().Bottom < plat.PlatListBounds()[i].PlatBounds().Bottom) || (pl.PlBounds().Bottom <= plat.PlatListBounds()[i].getCoordY() && pl.PlBounds().Bottom+pl.getSpeedY() >= plat.PlatListBounds()[i].PlatBounds().Bottom)))
                if (pl.getLive() && pl.PlBounds().IntersectsWith(listPlatform[i].PlatBounds()) && pl.getSpeedY() > 0 && pl.PlBounds().Right-8 > listPlatform[i].getCoordX()+2 && pl.getCoordX()+6 < listPlatform[i].PlatBounds().Right-2 &&
                    ((pl.PlBounds().Bottom >= listPlatform[i].PlatBounds().Top && pl.PlBounds().Bottom <= listPlatform[i].PlatBounds().Bottom) ||
                     (pl.PlBounds().Bottom <= listPlatform[i].PlatBounds().Top) ||
                     (pl.PlBounds().Bottom + pl.getSpeedY() >= listPlatform[i].PlatBounds().Bottom && pl.PlBounds().Bottom <= listPlatform[i].PlatBounds().Bottom) ||
                     (pl.PlBounds().Bottom  >= listPlatform[i].PlatBounds().Bottom && pl.PlBounds().Bottom + pl.getSpeedY() <= listPlatform[i].PlatBounds().Bottom) ||
                     (pl.PlBounds().Bottom + pl.getSpeedY() >= listPlatform[i].PlatBounds().Bottom && pl.PlBounds().Bottom + pl.getSpeedY() <= listPlatform[i].PlatBounds().Bottom) ||
                     (pl.PlBounds().Bottom - pl.getSpeedY() >= listPlatform[i].PlatBounds().Bottom && pl.PlBounds().Bottom <= listPlatform[i].PlatBounds().Bottom) ||
                     (pl.PlBounds().Bottom > listPlatform[i].PlatBounds().Bottom && pl.PlBounds().Bottom - pl.getSpeedY() <= listPlatform[i].PlatBounds().Bottom) ||
                     (pl.PlBounds().Bottom - pl.getSpeedY() >= listPlatform[i].PlatBounds().Bottom && pl.PlBounds().Bottom - pl.getSpeedY() <= listPlatform[i].PlatBounds().Bottom))
                   )
                {
                        pl.setCoordY(listPlatform[i].PlatBounds().Bottom - pl.PlBounds().Height);
                        pl.setSpeedY(pl.getSpeedJump());
                    if (listPlatform[i] is White)
                    {
                        deletePlat(i);
                    }
                    if (listPlatform[i] is Red)
                    {
                        if (listPlatform[i].getHP() != 0)
                        {
                            g++;
                            if (listPlatform[i].getHP() == 4) g = 0;
                                listPlatform[i].setHP(listPlatform[i].getHP() - 1);
                                listPlatform[i].setSkin(Properties.Resources.red.Clone(new Rectangle(0, ((g+1) * 35) + g, 114, 30), System.Drawing.Imaging.PixelFormat.Format32bppArgb));
                                
                        }
                        else
                        {
                            deletePlat(i);
                            g = 0;
                        }
                    }

                }
                if (listPlatform[i] is Blue || listPlatform[i] is White)
                {
                    if (listPlatform[i].getrndDir() % 3 == 0)
                    listPlatform[i].moveUpDown();
                    if (listPlatform[i].getrndDir() % 5 == 0)
                    listPlatform[i].moveLeftRight(this);
                }
            }

            if (pl.getCoordY() < this.ClientSize.Height/2)
            {
                pl.setCoordY(this.ClientSize.Height / 2);
                moveLevel();
                //drawScores(scores);
            }

            for (int i = 0; i < listBullet.Count;i++)
            {
                listBullet[i].Move();
                listBullet[i].Draw(dcfon1);
                if (listBullet[i].getCoordY() < 0)
                {
                    listBullet[i].checkDel();
                }
            }


            drawPauseButton();
            checkPlat();
            checkEnd();
            pl.move(this);
            drawLevel();
            drawScores(scores);
            pl.Draw(dcfon1);
            dc.DrawImage(fon1, 0, 0);
            dcfon1.DrawImage(fon, 0, 0);
        }//тик таймера

        private void drawPauseButton()
        {
            pause = new Rectangle(this.ClientSize.Width - 30, 8, 20, 30);
            dcfon1.DrawImage(pauseSkin, pause);
        }//отрисовка паузы

        private void FontLoad()
        {
            string fileName = Path.GetTempFileName();
            File.WriteAllBytes(fileName, Properties.Resources.DoodleJump);
            custom_font.AddFontFile(fileName);
        }//загрузка шрифта

        private void checkGun()
        {
            if(pl.getCheckGun())
            {
                Bullet bullet = new Bullet(pl.getCoordX() - 4 + pl.PlBounds().Width / 2, pl.getCoordY() - 20);
                //bullet.Draw(dcfon1);
                listBullet.Add(bullet);
                bullet.onCheckDelBullet += Bullet_onCheckDelBullet;
            }
        }//проверка на выстрел

        private void Bullet_onCheckDelBullet()
        {
            listBullet.Remove(listBullet[0]);
        }//событие удаление пули

        private void createMonsters(int h, int f, int x, int y, int sx, int sy, bool ms, Bitmap s)
        {
            Monsters monster = new Monsters(h, f, x, y, sx, sy, ms, s);
            listMonsters.Add(monster);
            monster.onCheckHP += Monster_onCheckHP;
            monster.onCheckDieMonster += Monster_onCheckDieMonster;
        }//создание монстров

        private void Monster_onCheckDieMonster()
        {
            listMonsters.Remove(listMonsters[0]);
        }//событие смерть монстра

        private void Monster_onCheckHP()
        {
            if (listMonsters[0].getHP() != 0)
            {
                listMonsters[0].setHP(listMonsters[0].getHP() - 1);
            }
            else
            {
                listMonsters[0].checkDieMon();
            }
        }//событие уменьшение жизней монстра

        private void drawScores(int s)
        {
            dcfon1.DrawString(Convert.ToString(s), new Font(custom_font.Families[0], 30, FontStyle.Bold), Brushes.Black, new Point(0, 0));
        }//отрисовка очков

        private void checkdy(Platforms pl)
        {
            if (dy == 0)
            {
                dy = 650 - 140;
            }
            else
            {
                dy = listPlatform[listPlatform.Count - 1].getCoordY() - 10 - rnd.Next(50, 60);
            }
            pl.setCoordX(rnd.Next(0, this.ClientSize.Width - pl.getSizeX() + 1));
            pl.setCoordY(dy);
            pl.setUpDown(dy);
            pl.setrndDir(rnd.Next());
            pl.setBonus(rnd.Next(0,100));
            pl.setMonster(rnd.Next(0, 100));
            pl.setBonusX(rnd.Next(0, 50));
            pl.setRect(new Rectangle(pl.getCoordX(), pl.getCoordY(), pl.getSizeX(), pl.getSizeY()));
            listPlatform.Add(pl);
        }//проверка расстояний между платформами

        private void createPlat()
        {
            rndColor = rnd.Next(0, 4);
            switch (rndColor)
            {
                case 0:
                    Green pl = new Green();
                    checkdy(pl);
                    if(pl.getBonus() % 2 == 0 && pl.getBonus() % 3 == 0)
                    {
                        int a = rnd.Next(0, 2);
                        switch (a)
                        {
                            case 0:
                                createBonus(a,pl.getBonusX(), pl.getCoordY(), 30, 0, 10, 15, Properties.Resources.pruzhina.Clone(new Rectangle(0, 0, 34, 33), System.Drawing.Imaging.PixelFormat.Format32bppArgb));
                                break;
                            case 1:
                                createBonus(a,pl.getBonusX(), pl.getCoordY(), 35, 0, 25, 15, Properties.Resources.batut.Clone(new Rectangle(74, 0, 74, 34), System.Drawing.Imaging.PixelFormat.Format32bppArgb));
                                break;
                        }
                    }
                    if(pl.getMonster() % 2 == 0 && pl.getMonster() % 7 == 0)
                    {
                        int e = rnd.Next(0, 4);
                        switch (e)
                        {
                            case 0:
                                createMonsters(2, e, pl.getCoordX() - 5, pl.getCoordY() - 45, 70, 50, false, Properties.Resources.m1);
                                break;
                            case 1:
                                createMonsters(0, e, pl.getCoordX(), pl.getCoordY() - 40, 50, 40, false, Properties.Resources.m2);
                                break;
                            case 2:
                                createMonsters(1, e, pl.getCoordX(), pl.getCoordY() - 40, 50, 70, true, Properties.Resources.m3);
                                break;
                            case 3:
                                createMonsters(0, e, pl.getCoordX(), pl.getCoordY() - 40, 60, 40, true, Properties.Resources.m4);
                                break;
                        }
                    }
                    break;
                case 1:
                    Blue pl1 = new Blue();
                    checkdy(pl1);
                    break;
                case 2:
                    Red pl2 = new Red();
                    checkdy(pl2);
                    if (pl2.getBonus() % 2 == 0 && pl2.getBonus() % 3 == 0)
                    {
                        int b = rnd.Next(0, 2);
                        switch (b)
                        {
                            case 0:
                                createBonus(b,pl2.getBonusX(), pl2.getCoordY(), 30, 0, 10, 15, Properties.Resources.pruzhina.Clone(new Rectangle(0, 0, 34, 33), System.Drawing.Imaging.PixelFormat.Format32bppArgb));
                                break;
                            case 1:
                                createBonus(b,pl2.getBonusX(), pl2.getCoordY(), 35, 0, 25, 15, Properties.Resources.batut.Clone(new Rectangle(74, 0, 74, 34), System.Drawing.Imaging.PixelFormat.Format32bppArgb));
                                break;
                        }
                    }
                    break;
                case 3:
                    White pl3 = new White();
                    checkdy(pl3);
                    break;
            }
        }//создание платформ

        private void moveLevel()
        {
            for (int i = 0; i < listPlatform.Count; i++)
            {
                if (i % 2 == 0)
                scores += 1;
                listPlatform[i].setCoordY(listPlatform[i].getCoordY() - pl.getSpeedY());
                listPlatform[i].setUpDown(listPlatform[i].getCoordY() - pl.getSpeedY());
                //listPlatform[i].setBonusY(listPlatform[i].getCoordY() - pl.getSpeedY());
            }

            for (int i = 0; i < listBonus.Count; i++)
            {
                listBonus[i].setCoordY(listBonus[i].getCoordY() - pl.getSpeedY());
            }

            for (int i = 0; i < listMonsters.Count; i++)
            {
                listMonsters[i].setCoordY(listMonsters[i].getCoordY() - pl.getSpeedY());
            }
        }//движение всей игры

        private void deletePlat(int i)
        {
            listPlatform.Remove(listPlatform[i]);
            createPlat();
        }//удаление платформы

        private void deleteBonus(int i)
        {
            listBonus.Remove(listBonus[i]);
        }//удаление бонуса

        private void deleteMonsters(int i)
        {
            listMonsters.Remove(listMonsters[i]);
        }//удаление монстра

        private void checkPlat()
        {
            for (int i = 0; i < listPlatform.Count; i++)
            {
                if (listPlatform[i].getCoordY() >= this.ClientSize.Height)
                {
                    deletePlat(i);
                }
            }

            for (int i = 0; i < listBonus.Count; i++)
            {
                if (listBonus[i].getCoordY() >= this.ClientSize.Height)
                {
                    deleteBonus(i);
                }
            }

            for (int i = 0; i < listMonsters.Count; i++)
            {
                if (listMonsters[i].getCoordY() >= this.ClientSize.Height)
                {
                    deleteMonsters(i);
                }
            }
        }//проверка платформ

        private void createBonus(int f,int x, int y, int k, int t, int sx, int sy, Bitmap sk)
        {
            Bonus bonus = new Bonus(f, x, y, k, t, sx, sy, sk);
            bonus.onCheckPlayer += Bonus_onCheckPlayer;
            listBonus.Add(bonus);
        }//создание бонуса

        private void Bonus_onCheckPlayer()
        {
            if(listBonus[0].check()==0)
            {
                listBonus[0].setSkin(Properties.Resources.pruzhina.Clone(new Rectangle(0, 0, 34, 23), System.Drawing.Imaging.PixelFormat.Format32bppArgb));
            }
            else if(listBonus[0].check()==1)
            {
                listBonus[0].setSkin(Properties.Resources.batut.Clone(new Rectangle(0, 0, 74, 34), System.Drawing.Imaging.PixelFormat.Format32bppArgb));
            }
        }//событие пересечение бонуса с игроком

        private void createLevel()
        {
            for (int i = 0; i < 20; i++)
            {
                createPlat();
                //createLevelBonus(i);
            }
            pl = new Player(listPlatform[0].getCoordX(), listPlatform[0].getCoordY()-100, Properties.Resources.underwater_right_2x);
            pl.onCheckBonus += Pl_onCheckBonus;
            pl.onCheckDie += Pl_onCheckDie;
        }//создание игры

        private void Pl_onCheckDie()
        {
            pl.setLive(false);
        }//событие смерть игрока

        private void Pl_onCheckBonus()
        {
            pl.setSpeedY(listBonus[0].getSpeedBonus());
        }//событие подбор бонуса игроком

        private void drawLevel()
        {
            for (int i = 0; i < listPlatform.Count; i++)
            {
                listPlatform[i].Draw(dcfon1);
            }

            for (int i = 0; i < listBonus.Count; i++)
            {
                listBonus[i].Draw(dcfon1);
            }

            for (int i = 0; i < listMonsters.Count; i++)
            {
                listMonsters[i].Draw(dcfon1);
            }
        }//отрисовка игры

        private void keyisdown(object sender, KeyEventArgs e)
        {
            pl.checkKeyDown(this, e);
            checkGun();

            if (e.KeyCode == Keys.G)
            {
                if (!checkGodMode)
                {
                    checkGodMode = true;
                    pl.setLive(false);
                    pl.setGravitation(0);
                }
                else
                {
                    checkGodMode = false;
                    pl.setLive(true);
                    pl.setGravitation(1);
                }
                    
            }

            if (e.KeyCode == Keys.Escape)
            {
                timer1.Stop();
                Menu mn = new Menu();
                mn.Show();
                Hide();
            }
            //if(e.KeyCode == Keys.S)
            //{
            //    Level lev = new Level(scores, pl, listPlatform, listBonus, listBullet, listMonsters);
            //    FileStream stream = File.Create("level.bin");
            //    var serializer = new BinaryFormatter();
            //    serializer.Serialize(stream, lev);
            //    stream.Close();
            //}

            //if (e.KeyCode == Keys.R)
            //{
            //    Level lev;
            //    FileStream stream = File.Open("level.bin", FileMode.Open);
            //    var deserializer = new BinaryFormatter();
            //    lev = deserializer.Deserialize(stream) as Level;
            //    stream.Close();
            //    scores = lev.score;
            //    pl = lev.pl;
            //    listPlatform = lev.listPlatform;
            //    listBonus = lev.listBonus;
            //    listBullet = lev.listBullet;
            //    listMonsters = lev.listMonsters;
            //}

            if (e.KeyCode == Keys.P)
            {
                if (!checkStopStart)
                {
                    checkStopStart = true;
                    dc.DrawImage(fonPause1, 0, 0);
                    dcfon1.DrawImage(fonPause, 0, 0);
                    timer1.Stop();
                }
                else
                {
                    checkStopStart = false;
                    timer1.Start();
                }
            }
        }//зажата клавиша

        private void keyisup(object sender, KeyEventArgs e)
        {
            pl.checkKeyUp(this, e);
        }//не зажата клавиша

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }//выход из формы

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
                if(e.X > pause.X && e.X < pause.X + pause.Width && e.Y > pause.Y && e.Y < pause.Y + pause.Height)
                {
                    pauseSkin = Properties.Resources.PauseOn;
                }
                else
                {
                    pauseSkin = Properties.Resources.Pause;
                }
        }//движение мыши

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > pause.X && e.X < pause.X + pause.Width && e.Y > pause.Y && e.Y < pause.Y + pause.Height)
            {
                if (!checkStopStart)
                {
                    checkStopStart = true;
                    dc.DrawImage(fonPause1, 0, 0);
                    dcfon1.DrawImage(fonPause, 0, 0);
                    timer1.Stop();
                }
                else
                {
                    checkStopStart = false;
                    timer1.Start();
                }
            }
        }//клик мыши

        private void checkEnd()
        {
            if (pl.getCoordY() > this.ClientSize.Height)
            {
                if (Convert.ToInt32(scoresfile[scoresfile.Length - 1]) < scores)
                {
                    scoresfile[scoresfile.Length - 1] = Convert.ToString(scores);
                    CheckRecord.Scores = scores;
                    CheckRecord.Value = true;
                }

                else
                {
                    CheckRecord.Value = false;
                }
                File.WriteAllLines(fileScores, scoresfile);
                timer1.Stop();
                GameEnd gm = new GameEnd();
                gm.Show();
                Hide();
            }
        }//конец игры
    }
}
