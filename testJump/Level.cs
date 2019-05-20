using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace testJump
{
    [Serializable]
    class Level
    {
        public int score;
        public Player pl;
        public List<Platforms> listPlatform = new List<Platforms>();
        public List<Bonus> listBonus = new List<Bonus>();
        public List<Bullet> listBullet = new List<Bullet>();
        public List<Monsters> listMonsters = new List<Monsters>();

        public Level(int sc, Player p, List<Platforms> l, List<Bonus> b, List<Bullet> bul, List<Monsters> m)
        {
            score = sc;
            pl = p;
            listPlatform = l;
            listBonus = b;
            listBullet = bul;
            listMonsters = m;
        }
    }
}
