using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PickAxe
    {
        private int _level;

        public int Level { get => _level; set => _level = value; }

        private Dictionary<int, float> mineSpeedBonus = new Dictionary<int, float>();

        public float TimePerMineHit { get => (1f / (1f + (mineSpeedBonus[Level]/100f))); }

        public void InitializePickaxe()
        {
            InitializePickaxeAttackSpeed();
        }
        
        public void InitializePickaxeAttackSpeed()
        {
            mineSpeedBonus.Add(0, 0);
            mineSpeedBonus.Add(1, 20f);
            mineSpeedBonus.Add(2, 50f);
            mineSpeedBonus.Add(3, 100f);
            mineSpeedBonus.Add(4, 100f);
            mineSpeedBonus.Add(5, 100f);

    }
    }

