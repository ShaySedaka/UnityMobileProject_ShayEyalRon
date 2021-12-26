using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public struct UpgradeCost
{
    int _woodCost;
    int _stoneCost;
    int _ironCost;
    int _coalCost;

    public int WoodCost { get => _woodCost; set => _woodCost = value; }
    public int StoneCost { get => _stoneCost; set => _stoneCost = value; }
    public int IronCost { get => _ironCost; set => _ironCost = value; }
    public int CoalCost { get => _coalCost; set => _coalCost = value; }

    public UpgradeCost(int woodCost, int stoneCost, int ironCost, int coalCost)
    {
        _woodCost = woodCost;
        _stoneCost = stoneCost;
        _ironCost = ironCost;
        _coalCost = coalCost;
    }

    
}

