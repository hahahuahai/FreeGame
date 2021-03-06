﻿using System;
using System.Collections;
using System.Collections.Generic;
using Loxodon.Framework.Asynchronous;
using Loxodon.Framework.Prefs;
using UnityEngine;

namespace FreeGame
{
    public class PlayerService : IPlayerService
    {
        private PlayerModel m_PlayerModel;
        private Preferences preferences;
        public PlayerService()
        {
            BinaryFilePreferencesFactory factory = new BinaryFilePreferencesFactory();
            Preferences.Register(factory);

            preferences = Preferences.GetGlobalPreferences();
        }

        public PlayerModel GetPlayerData()
        {
            PlayerModel playerModel = new PlayerModel();
            playerModel.Score = 0;
            playerModel.Position = new Vector3(0, 0, 0);
            playerModel.Rotation = new Vector3(0, 0, 0);

            if (preferences.ContainsKey("score") || preferences.ContainsKey("position") || preferences.ContainsKey("rotation"))
            {
                Debug.Log("Score为:" + preferences.GetInt("score"));
                Debug.Log("Position为:" + preferences.GetObject<Vector3>("position"));
                Debug.Log("Rotation为:" + preferences.GetObject<Vector3>("rotation"));
                playerModel.Score = preferences.GetInt("score");
                playerModel.Position = preferences.GetObject<Vector3>("position");
                playerModel.Rotation = preferences.GetObject<Vector3>("rotation");
            }
            return playerModel;
        }

        public void SetPlayerModel(PlayerModel playerModel)
        {
            preferences.SetInt("score", playerModel.Score);
            preferences.SetObject("position", playerModel.Position);
            preferences.SetObject("rotation", playerModel.Rotation);

            preferences.Save();
        }

        public void SetPlayerScore(int score)
        {
            preferences.SetInt("score", score);
            preferences.Save();
        }
        public void SetPlayerPosition(Vector3 position)
        {
            preferences.SetObject("position", position);
            preferences.Save();
        }
        public void SetPlayerRotation(Vector3 rotation)
        {
            preferences.SetObject("rotation", rotation);
            preferences.Save();
        }

        /// <summary>
        /// 清空玩家数据
        /// </summary>
        public void ClearPlayerData()
        {
            preferences.RemoveAll();
            preferences.Save();
        }
    }

}
