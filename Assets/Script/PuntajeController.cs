using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntajeController : MonoBehaviour
{
    private int points = 0;
    public int GetPoints()
    {
        return points;
    }
    public void AddPoints(int points)
    {
        this.points += points;
    }
}
