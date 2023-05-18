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
    public static bool Insurance = false;
    public static bool move = true;
    public static int dead = 0;
    public static bool dad_dead = false;
    public static float posx = 0f;
    public static float Exposx = 0f;
    public static bool toilet_entered = false;
    public static bool second_floor_entered = false;
    public static bool brother_room_entered = false;
    public static bool parent_room_entered = false;
    public static bool grandmom_room_entered = false;
    public static bool drama_played = false;
    public static int window_count = 1;
    public static bool MirrorBlood = false;
    public static bool isinGranadmaPart = false;
    public static bool GrandMaCanDie = false;
    public static bool FirstTimeGetinGrandMaRoom = true;
    public static bool isFirstToSecond = true;
    public static string SceneName = "FirstScene";
}
