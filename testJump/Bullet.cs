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
    class Bullet
    {
        int speedY = 20;//скорость пули
        int xCoord;//координата х
        int yCoord;//координата у
        int size = 10;//размер
        Rectangle rectBullet;//поле пули
        Bitmap skin = Properties.Resources.bullet;//скин
        public delegate void Method5();//делегат
        public event Method5 onCheckDelBullet;//событие удаления пули

        public void checkDel()
        {
            onCheckDelBullet();
        }//проверка на удаление

        public Bullet(int x, int y)
        {
            xCoord = x;
            yCoord = y;
        }//конструктор

        public void Move()
        {
            yCoord -= speedY;
        }//движение

        public void Draw(Graphics dc)
        {
            rectBullet = new Rectangle(xCoord, yCoord, size, size);
            dc.DrawImage(skin, rectBullet);
        }//отрисовка

        public void setCoordX(int x)
        {
            xCoord = x;
            rectBullet.X = x;
        }//установка х

        public void setCoordY(int y)
        {
            yCoord = y;
            rectBullet.Y = y;
        }//установка у

        public int getCoordX()
        {
            return xCoord;
        }//возвращает х

        public int getCoordY()
        {
            return yCoord;
        }//возвращает у

        public Rectangle boundRect()
        {
            return rectBullet;
        }//возвращает поле пули
    }
}
