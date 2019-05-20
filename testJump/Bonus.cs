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
    class Bonus
    {
        int xCoord;//координата х
        int yCoord;//координата у
        int sizeX;//ширина
        int sizeY;//высота
        int speedBonus;//бонусная скорость
        int checkBonus;//проверка бонуса
        int timeSpeed;//время действия
        Bitmap skin;//скин
        Rectangle rectBonus;//поле бонуса
        public delegate void Method3();//делегат
        public event Method3 onCheckPlayer;//событие пересечения с игроком

        public void checkPlayer()
        {
            onCheckPlayer();
        }//инициализация события

        public Bonus(int f, int x, int y, int speed, int time, int sx, int sy, Bitmap sk)
        {
            checkBonus = f;
            skin = sk;
            speedBonus = -speed;
            timeSpeed = time;
            sizeX = sx;
            sizeY = sy;
            xCoord = x;
            yCoord = y - sizeY + 5;
        }//конструктор

        public void Draw(Graphics dc)
        {
            rectBonus = new Rectangle(xCoord, yCoord, sizeX, sizeY);
            dc.DrawImage(skin,rectBonus);
        }//отрисовка

        public void setSizeY(int y)
        {
            sizeY = y;
        }//установка высоту

        public void setSkin(Bitmap sk)
        {
            skin = new Bitmap(sk);
        }//установка скина

        public void setCoordX(int x)
        {
            xCoord = x;
            rectBonus.X = x;
        }//установка координаты х

        public void setTimeSpeed(int t)
        {
            timeSpeed = t;
        }//установка времени действия

        public void setCoordY(int y)
        {
            yCoord = y;
            rectBonus.Y = y;
        }//установка координаты у

        public int getTimeSpeed()
        {
            return timeSpeed;
        }//возвращает время действия

        public int getSpeedBonus()
        {
            return speedBonus;
        }//возвращает бонусную скорость

        public int getSizeY()
        {
            return sizeY;
        }//возвращает высоту

        public int getCoordX()
        {
            return xCoord;
        }//возвращает координату х

        public int getCoordY()
        {
            return yCoord;
        }//возвращает координату у

        public int check()
        {
            return checkBonus;
        }//проверка бонуса

        public Rectangle boundsBonus()
        {
            return rectBonus;
        }//возвращает поле бонуса
    }
}
