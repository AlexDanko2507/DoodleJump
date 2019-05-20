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
    class Platforms
    {
        bool Right = true;//флаг движения по горизонтали
        bool Up = true;//флаг движения по вертикали
        int HP;//количество прыжков
        int speedLeftRight = 5;//скорость по горизонтали
        int speedUpDown = 2;//скорость по вертикали
        int xCoord;//координата х
        int yCoord;//координата у
        int sizeX = 60;//ширина
        int sizeY = 20;//высота
        int UpDown;//точка перемещения вверх-вниз
        Bitmap skin;//скин
        Rectangle rectPlatform;//поле платформы
        int rndDir;//рандомное направление
        int checkBonus;//проверка на бонус
        int checkMonster;//проверка на монстров
        int bonusX;//координата х бонуса
        int bonusY;//координата у бонуса
        Random rnd = new Random();//рандом

        //Platforms()
        //{
        //    rndColor = rnd.Next(0, 4);
        //    switch (rndColor)
        //    {
        //        case 0:
        //            skin = Properties.Resources.green;
        //            break;
        //        case 1:
        //            skin = Properties.Resources.blue;
        //            break;
        //        case 2:
        //            skin = Properties.Resources.red.Clone(new Rectangle(0, 145, 114, 30), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //            break;
        //        case 3:
        //            skin = Properties.Resources.white;
        //            break;
        //    }
        //}

        public Platforms()
        {
        }//конструктор

        public void Draw(Graphics dc)
        {
                dc.DrawImage(skin, rectPlatform);
        }//отрисовка

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
        }//движение по горизонтали

        public void moveUpDown()
        {
            if (Up) setCoordY(getCoordY() - speedUpDown);
            else setCoordY(getCoordY() + speedUpDown);
            if (yCoord < UpDown - 50)
            {
                Up = false;
                setCoordY(getCoordY() + speedUpDown);
            } 
            else if (yCoord > UpDown + 50)
            {
                Up = true;
                setCoordY(getCoordY() - speedUpDown);
            }
        }//по вертикали

        public Rectangle PlatBounds()
        {
            return rectPlatform;
        }//возвращает поле платформы

        public void setrndDir(int dir)
        {
            rndDir = dir;
        }//устанавливает рандомное направление

        public void setRect(Rectangle r)
        {
            rectPlatform = r;
        }//устанавливает поле платформы
        
        public void setSkin(Bitmap sk)
        {
            skin = new Bitmap(sk);
        }//устанавливает скин

        public void setCoordX(int x)
        {
            xCoord = x;
            rectPlatform.X = x;
        }//устанавливает координату х

        public void setCoordY(int y)
        {
            yCoord = y;
            rectPlatform.Y = y;
        }//устанавливает координату у

        public void setUpDown(int y)
        {
            UpDown = y;
        }//устанавливает координату опоры для вверх-вниз
        
        public void setHP(int hp)
        {
            HP = hp;
        }//устанавливает жизни платформы

        public void setBonus(int b)
        {
            checkBonus = b;
        }//устанавливает бонус на платформу

        public void setBonusX(int b)
        {
            bonusX = xCoord + b;
        }//координата х бонуса на платформе

        public void setBonusY(int b)
        {
            bonusY = b;
        }//координата у бонуса  на платформе
        
        public void setMonster(int b)
        {
            checkMonster = b;
        }//установка монстра на платформу

        public int getBonusY()
        {
            return bonusY;
        }//возвращает координату у бонуса

        public int getBonusX()
        {
            return bonusX;
        }//возвращает координату х бонуса

        public int getBonus()
        {
            return checkBonus;
        }//возвращает бонус

        public int getMonster()
        {
            return checkMonster;
        }//возвращает монстра

        public int getHP()
        {
            return HP;
        }//возвращает жизни

        public int getrndDir()
        {
            return rndDir;
        }//возвращает рандомноне направление

        public int getCoordX()
        {
            return xCoord;
        }//возвращает х

        public int getCoordY()
        {
            return yCoord;
        }//возвращает у

        public int getSizeX()
        {
            return sizeX;
        }//возвращает ширину

        public int getSizeY()
        {
            return sizeY;
        }//возвращает высоту
    }
}
