using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FreeGame
{
    public class StartWindow : Window
    {
        public Button startButton;
        public Button loadButton;
        public Button quitButton;
        public Text progressBarText;
        public Slider progressBarSlider;

        private StartViewModel startViewModel;
        protected override void OnCreate(IBundle bundle)
        {
            this.startViewModel = new StartViewModel();

            BindingSet<StartWindow, StartViewModel> bindingSet = this.CreateBindingSet(startViewModel);
            bindingSet.Bind(this.startButton).For(v => v.onClick).To(vm => vm.StartCommand);
            bindingSet.Bind(this.loadButton).For(v => v.onClick).To(vm => vm.LoadCommand);

            bindingSet.Bind(this.progressBarSlider.gameObject).For(v => v.activeSelf).To(vm => vm.ProgressBar.Enable).OneWay();
            bindingSet.Bind(this.progressBarSlider.GetComponent<Slider>()).For(v => v.value).To(vm => vm.ProgressBar.Progress).OneWay();
            bindingSet.Bind(this.progressBarText).For(v => v.text).ToExpression(vm => string.Format("{0}%", Mathf.FloorToInt(vm.ProgressBar.Progress * 100f))).OneWay();


            bindingSet.Build();
        }
    }

}
