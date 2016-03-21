using System.Collections.Generic;
using UnityEngine;

public class LevelsList : MonoBehaviour
{
    public int nextLevel;

    public List<TextAsset> Levels;

    public TextAsset GetNextLevel()
    {
        if (nextLevel > Levels.Count - 1)
        {
            return null;
        }
        Debug.Log("Level[" + nextLevel + "]");
        var level = Levels[nextLevel];
        nextLevel++;
        return level;
    }
}
