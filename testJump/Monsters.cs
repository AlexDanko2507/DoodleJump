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
    class Monsters
    {
        bool Right = true;//флаг движения по горизонтали
        int speedLeftRight = 3;//скорость по горизонтали
        int xCoord;//координата х
        int yCoord;//координата у
        int sizeX;//ширина
        int sizeY;//высота
        int checkMonster;//проверка монстра
        int HP;//жизни
        bool moveStand;//флаг на движение
        Rectangle rectMonster;//поле монстра
        Bitmap skin;//скин
        public delegate void Method4();//делегат
        public event Method4 onCheckHP;//событие уменьшение жизней
        public delegate void Method6();//делегат
        public event Method6 onCheckDieMonster;//событие смерти монстра

        public void checkDieMon()
        {
            onCheckDieMonster();
        }//инициализация события

        public void checkHP()
        {
            onCheckHP();
        }//инициализация события

        public Monsters(int h, int f, int x, int y, int sx, int sy, bool ms, Bitmap s)
        {
            HP = h;
            checkMonster = f;
            xCoord = x;
            yCoord = y;
            skin = s;
            moveStand = ms;
            sizeX = sx;
            sizeY = sy;
        }//конструктор

        public void Draw(Graphics dc)
        {
            rectMonster = new Rectangle(xCoord, yCoord, sizeX, sizeY);
            dc.DrawImage(skin, rectMonster);
        }//отрисовка

        public void setCoordX(int x)
        {
            xCoord = x;
            rectMonster.X = x;
        }//установка х

        public void setCoordY(int y)
        {
            yCoord = y;
            rectMonster.Y = y;
        }//установка у

        public void setHP(int hp)
        {
            HP = hp;
        }//установка жизней

        public int getCoordX()
        {
            return xCoord;
        }//возвращает х

        public int getCoordY()
        {
            return yCoord;
        }//возвращает у

        public int getHP()
        {
            return HP;
        }//возвращает жизни

        public int check()
        {
            return checkMonster;
        }//проверка монстра

        public Rectangle boundMonster()
        {
            return rectMonster;
        }//возвращает поле монстра

        public void moveLeftRight(Form1 form)
        {
            if (Right) setCoordX(getCoordX() + speedLeftRight);
            else setCoordX(getCoordX() - speedLeftRight);
            if (xCoord > form.ClientSize.Width - sizeX)
            {
                Right = false;
                setCoordX(getCoordX() - speedLeftRight);
            }
            else if (xCoord < 0)
            {
                Right = true;
                setCoordX(getCoordX() + speedLeftRight);
            }
        }//движение по горизнтали
    }
}
