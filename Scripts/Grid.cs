using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public static int w = 10;
    public static int h = 20;
    public static Transform[,] grid = new Transform[w, h];

    public int scoreOneLine = 40;
    public int scoreTwoLine = 100;
    public int scoreThreeLine = 300;
    public int scoreFourLine = 1200;

    public Text hud_score;

    private int numberOfRowsThisTurn = 0;

    private static int currentScore = 0;

    void Update()
    {
        UpdateScore();
        UpdateUI();
    }

    public void UpdateUI()
    {
        hud_score.text = currentScore.ToString();
    }

    public void UpdateScore()
    {
        if (numberOfRowsThisTurn == 0)
        {
            if (numberOfRowsThisTurn == 1)
            {
                ClearedOneLine();
            }
            else if (numberOfRowsThisTurn == 2)
            {
                ClearedTwoLines();
            }
            else if (numberOfRowsThisTurn == 3)
            {
                ClearedThreeLines();
            }
            else if (numberOfRowsThisTurn == 4)
            {
                ClearedFourLines();
            }

            numberOfRowsThisTurn = 0;
        }
    }

    public void ClearedOneLine()
    {
        currentScore += scoreOneLine;
    }

    public void ClearedTwoLines()
    {
        currentScore += scoreTwoLine;
    }

    public void ClearedThreeLines()
    {
        currentScore += scoreThreeLine;
    }

    public void ClearedFourLines()
    {
        currentScore += scoreFourLine;
    }

    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x),
            Mathf.Round(v.y));
    }

    public static bool insideBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 &&
            (int)pos.x < w &&
            (int)pos.y >= 0);
    }

    public static void deleteRow(int y)
    {
        for (int x = 0; x < w; ++x) {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public static void decreaseRow(int y)
    {
        for (int x = 0; x < w; ++x)
        {
            if (grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void decreaseRowsAbove(int y)
    {
        for (int i = y; i < h; ++i)
        {
            decreaseRow(i);
        }
    }

    public static bool isRowFull(int y)
    {
        for (int x = 0; x < w; ++x)
            if (grid[x, y] == null)
                return false;
            return true;
    }

    public static void deleteFullRows()
    {
        for (int y = 0; y < h; ++y)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                decreaseRowsAbove(y+1);
                --y;
            }
        }
    }
}
