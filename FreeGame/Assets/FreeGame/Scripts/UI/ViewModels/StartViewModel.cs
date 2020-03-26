using Loxodon.Framework.Asynchronous;
using Loxodon.Framework.Commands;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Services;
using Loxodon.Framework.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FreeGame
{
    public class StartViewModel : ViewModelBase
    {
        private SimpleCommand startCommand;
        private SimpleCommand loadCommand;

        private ProgressBar progressBar = new ProgressBar();

        public ProgressBar ProgressBar
        {
            get { return this.progressBar; }
        }
        public ICommand StartCommand
        {
            get { return this.startCommand; }
        }

        public ICommand LoadCommand
        {
            get { return this.loadCommand; }
        }

        public StartViewModel()
        {
            ApplicationContext applicationContext = Context.GetApplicationContext();
            IServiceContainer container = applicationContext.GetContainer();
            IPlayerService playerService = container.Resolve<IPlayerService>();
            this.startCommand = new SimpleCommand(() =>
            {
                this.startCommand.Enabled = false;

                playerService.ClearPlayerData();//清空玩家数据
                playerService.SetPlayerPosition(new Vector3(-30, 0, 16.6f));//设置玩家默认出生地

                LoadGameScene();
            });

            this.loadCommand = new SimpleCommand(() =>
            {
                this.loadCommand.Enabled = false;
                LoadGameScene();
            });
        }

        /// <summary>
        /// 异步加载GameScene场景，带进度条
        /// </summary>
        private void LoadGameScene()
        {
            ProgressTask<float> task = new ProgressTask<float>(new Func<IProgressPromise<float>, IEnumerator>(DoLoadGameScene));

            task.OnPreExecute(() =>
            {
                this.progressBar.Enable = true;//让进度条显示出来
            }).OnProgressUpdate(progress =>
            {
                this.ProgressBar.Progress = progress;//实时更新进度
            }).OnFinish(() =>
            {
                this.progressBar.Enable = false;//隐藏进度条
            }).Start();
        }

        private IEnumerator DoLoadGameScene(IProgressPromise<float> progressPromise)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("GameScene");
            while (!asyncOperation.isDone)
            {
                progressPromise.UpdateProgress(asyncOperation.progress);
                yield return null;
            }
            progressPromise.UpdateProgress(1f);
            progressPromise.SetResult();
        }
    }

}