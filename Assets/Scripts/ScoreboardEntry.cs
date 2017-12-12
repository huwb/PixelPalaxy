using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardEntry {
    public string Name;
    public int Score;

    public ScoreboardEntry(string name, int score)
    {
        Name = name;
        Score = score;
    }

}

public class ScoreboardComparer : IComparer<ScoreboardEntry>
{
    public int Compare(ScoreboardEntry x, ScoreboardEntry y)
    {
        return x.Score - y.Score;
    }
}
