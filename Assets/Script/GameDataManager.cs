using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDataManager
{
    public static int state = 1; // 第幾關
    public static bool Rope = false;
    public static bool Album = false;
    public static bool Pot = false;
    public static bool Blood_Tissue = false;
    public static bool Invoice = false;
    public static bool Tissue = false;
    public static bool Draw = false;
    public static bool Key = false;
    public static bool Note = false;
    public static bool move = true;
    public static int dead = 0;
    //1:位於時間內調查鬼
    //2:道具不夠
    //3:與鬼肉搏死亡
    //4:使用繩子死亡
    //5:使用鍋子死亡
    //6:安撫死亡
    //7:溝通死亡
    //8:未靠近樓梯死亡
    public static bool dad_dead = false;
    public static float posx = 0f;
    public static bool toilet_entered = false;
    public static bool second_floor_entered = false;
    public static bool brother_room_entered = false;
    public static bool parent_room_entered = false;
    public static bool grandmom_room_entered = false;
    public static int window_count = 1;
    public static bool MirrorBlood = false;
}
