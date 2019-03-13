using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Cell {
    public int High;
    public int Medium;
    public int Low;

    

    public override string ToString()
    {
        return "H: " + High + " M: " + Medium + " Low: " + Low;
    }
    public void init()
    {
        High = 0;
        Medium = 0;
        Low = 0;
    }

    public Cell(Cell cell)
    {
        High = cell.High;
        Medium = cell.Medium;
        Low = cell.Low;
    }
}
