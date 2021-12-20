using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PickAxe
    {
        private int _level;

        public int Level { get => _level; set => _level = value; }

        private Dictionary<int, float> attackSpeedBonus = new Dictionary<int, float>();

        public float TimePerAttack { get => (1f / (1f + (attackSpeedBonus[Level]/100f))); }

        public void InitializePickaxe()
        {
            InitializePickaxeAttackSpeed();
        }
        
        public void InitializePickaxeAttackSpeed()
        {
            attackSpeedBonus.Add(0, 0);
            attackSpeedBonus.Add(1, 20f);
            attackSpeedBonus.Add(2, 50f);
            attackSpeedBonus.Add(3, 100f);

        }
    }

