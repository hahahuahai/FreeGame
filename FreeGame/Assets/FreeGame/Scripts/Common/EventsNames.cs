using Loxodon.Framework.Localizations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FreeGame
{
    public static class EventsNames
    {
        //纯UI之间的事件




        //Game逻辑相关的事件
        public readonly static string UI_Score = "UI_Score";//增加金币数量
        public readonly static string UI_RentCar = "UI_RentCar";//租车开，对话框文字
        public readonly static string UI_CarPlayerMode = "UI_CarPlayerMode";//开车模式
        public readonly static string UI_PlayerMode = "UI_PlayerMode";//人型模式
        public readonly static string UI_AntiDie = "UI_AntiDie";//防卡死
    }
}
