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

    public UpgradeCost(int woodCost, int stoneCost, int ironCost, int coalCost)
    {
        _woodCost = woodCost;
        _stoneCost = stoneCost;
        _ironCost = ironCost;
        _coalCost = coalCost;
    }
}

