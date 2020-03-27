using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FreeGame
{
    public static class Consts
    {
        public readonly static string PlayerPrefab = "PlayerPrefab";//人形玩家prefab，最外层
        public readonly static string Player = "Player";//人形玩家prefab，内层
        public readonly static string CarPlayerPrefab = "CarPlayerPrefab";//车型玩家prefab，最外层
        public readonly static string CarPlayer = "CarPlayer";//车型玩家prefab，内层

        public readonly static string PlayerTag = "Player";//人形玩家tag名
        public readonly static string CarPlayerTag = "CarPlayer";//人形玩家tag名

        public readonly static Vector3 PlayerStartingPosition = new Vector3(-30, 0, 16.6f); //Player第一次进游戏时的坐标
        public readonly static Vector3 CarPlayerStartingPosition = new Vector3(5, 0, 110); //CarPlayer第一次进游戏时的坐标

        //路径
        public readonly static string CsvPath = "\\Assets\\FreeGame\\Resources\\GameData\\";
    }
}
