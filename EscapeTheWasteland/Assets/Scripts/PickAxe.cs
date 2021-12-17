using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PickAxe
    {
        private int _level;

        public int Level { get => _level; set => _level = value; }

        private Dictionary<int, int> attackSpeedBonus = new Dictionary<int, int>();

        public float TimePerAttack { get => (1 / (1 + (attackSpeedBonus[Level]/100))); }

        public void InitializePickaxe()
        {
            InitializePickaxeAttackSpeed();
        }
        
        public void InitializePickaxeAttackSpeed()
        {
            attackSpeedBonus.Add(0, 0);
            attackSpeedBonus.Add(1, 20);
            attackSpeedBonus.Add(2, 50);
            attackSpeedBonus.Add(3, 100);

        }
    }

