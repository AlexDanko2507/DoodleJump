using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testJump
{
    [Serializable]
    class Player
    {
        bool goleft;//флаг влево
        bool goright;//флаг вправо
        bool isPressed;//флаг нажатия клавиши
        bool checkLeftRight;//флаг поворота
        bool check;//флаг поворота(скин)
        bool checkGun = false;//флаг стрельбы
        bool live = true;//флаг жизни

        int size = 60;//размер
        int speedX = 15;//скороть по горизонтали
        int speedY;// скорость по вертикали
        int xCoord;// координата х
        int yCoord;// координата у
        int speed = -23;// сила прыжка
        int gravitation = 1;//сила притяжения
        Bitmap skin;// скин
        Rectangle rectPlayer;// поле персонажа
        public delegate void Method1();//делегат
        public delegate void Method2();//делегат

        public event Method1 onCheckBonus;//событие пересечения с бонусом
        public event Method1 onCheckDie;//событие смерти

        public void checkDie()
        {
            onCheckDie();
        }//проверка на смерть

        public void checkBonus(int k)
        {
            onCheckBonus();
        }//проверка на бонус

        public Player(int x, int y, Bitmap sk)
        {
            xCoord = x;
            yCoord = y;
            skin = new Bitmap(sk);
        }//конструктор

        public Rectangle PlBounds()
        {
            return rectPlayer;
        }//возвращает поле персонажа

        public void Draw(Graphics dc)
        {
            rectPlayer = new Rectangle(xCoord,yCoord,size,size);
            dc.DrawImage(skin, rectPlayer);
            //dc.DrawImage(skin, xCoord, yCoord);
        }//отрисовка персонажа

        public void setSkin(Bitmap sk)
        {
            skin = new Bitmap(sk);
        }//установка скина

        public void setCoordX(int x)
        {
            xCoord = x;
        }//установка координаты х

        public void setCoordY(int y)
        {
            yCoord = y;
        }//установка координаты у

        public int getCoordX()
        {
            return xCoord;
        }//возвращает координату х

        public int getCoordY()
        {
            return yCoord;
        }//возвращает координату у

        public int getSpeedY()
        {
            return speedY;
        }//возвращает скорость по вертикали

        public int getSpeedJump()
        {
            return speed;
        }//возвращает силу прыжка

        public void setSpeedY(int y)
        {
            speedY = y;
        }//установка скорости по вертикали

        public void setGravitation(int g)
        {
            gravitation = g;
        }//установка гравитации

        public bool getCheckGun()
        {
            return checkGun;
        }//проверка на выстрел

        public void setLive(bool t)
        {
            live = t;
        }//установка жизни/смерти

        public bool getLive()
        {
            return live;
        }//возвращает жизнь/смерть

        public void checkKeyDown(Form1 form, KeyEventArgs btn)
        {
            if (btn.KeyCode == Keys.Left)
            {
                checkLeftRight = false;
                goleft = true;
                skin = new Bitmap(Properties.Resources.underwater_left_2x);
            }

            if (btn.KeyCode == Keys.Right)
            {
                checkLeftRight = true;
                goright = true;
                skin = new Bitmap(Properties.Resources.underwater_right_2x);
            }

            if (btn.KeyCode == Keys.Up && !isPressed)
            {
                isPressed = true;
                if (!checkLeftRight) check = false;
                else check = true;
                skin = new Bitmap(Properties.Resources.underwater_up_2x);
                checkGun = true;
            }
        }//проверка на нажатие

        public void checkKeyUp(Form1 form, KeyEventArgs btn)
        {
            if (btn.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (btn.KeyCode == Keys.Right)
            {
                goright = false;
            }

            if (isPressed)
            {
                isPressed = false;
                if (check == false)
                    skin = new Bitmap(Properties.Resources.underwater_left_2x);
                else
                    skin = new Bitmap(Properties.Resources.underwater_right_2x);
                checkGun = false;
            }
        }//проверка на отпуск клавиши

        public void move(Form1 form)
        {
            speedY += gravitation;
            yCoord += speedY;

            if (goleft)
            {
                xCoord -= speedX;
                if (getCoordX() < -rectPlayer.Width)
                {
                    xCoord = form.ClientSize.Width;
                }
            }
            else if (goright)
            {
                xCoord += speedX;
                if (getCoordX() > form.ClientSize.Width)
                {
                    xCoord = -rectPlayer.Width;
                }
            }
        }//движение персонажа

    }
}
