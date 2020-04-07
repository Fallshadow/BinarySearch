using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace act.ui
{
    public enum FadeType
    {
        FullBlackFade = 0,
    }
    [BindingResource("SceneFadeCanvas")]
    public class SceneFadeCanvas : UiBase
    {
        public FadeType fadeType = FadeType.FullBlackFade;
        [SerializeField] private UiStaticText processText = null;

        private Action completeOutCB = null;
        private Action completeInCB = null;
        private Animator anim; 
        public override void Initialize()
        {
            anim = GetComponent<Animator>();
        }

        public override void Refresh()
        {

        }

        public override void Release()
        {

        }

        protected override void onClose()
        {
            base.onClose();
            processText.text = "";
        }
        private void Update()
        {
            processText.text = game.SceneMgr.instance.process.ToString();
        }
        public void FadeIn(Action completeInCB = null)
        {
            this.completeInCB = completeInCB;
            anim.Play($"FadeIn_{utility.ConvertUtility.ConvertEnumToString<FadeType>(fadeType)}");
        }

        public void FadeInCB()
        {
            completeInCB?.Invoke();
        }

        public void FadeOut(Action completeOutCB = null)
        {
            this.completeOutCB = completeOutCB;
            anim.Play($"FadeOut_{utility.ConvertUtility.ConvertEnumToString<FadeType>(fadeType)}");
        }

        public void FadeOutCB()
        {
            completeOutCB?.Invoke();
        }
    }
}
