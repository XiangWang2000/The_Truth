using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDataManager
{
    public static int state = 1; // 第幾關
    public static int [] Propos = new int[3]; // 跳繩/相簿/鍋子
    public static bool Rope=false;
    public static bool Album=false;
    public static bool Pot=false;
    public static bool move=true;
    public static int dead=0;
}
