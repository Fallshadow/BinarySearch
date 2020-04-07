using System;
using UnityEngine;

namespace act.ui
{
    [RequireComponent(typeof(Animator))]
    public class UiAnimator : MonoBehaviour, IUiAnimation
    {
        [SerializeField] protected Animator animator = null;
        [SerializeField] protected string clipNamePrefix = null;

        protected void Reset()
        {
            animator = GetComponent<Animator>();
            animator.applyRootMotion = false;
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;
            clipNamePrefix = name;
        }

        bool IUiAnimation.HasClip(UiAnimationClip clip, string suffix)
        {
            switch (clip)
            {
                case UiAnimationClip.UAC_SHOW:
                    return animator.HasState(0, Animator.StringToHash(UiBase.ShowClipName + suffix));
                case UiAnimationClip.UAC_HIDE:
                    return animator.HasState(0, Animator.StringToHash(UiBase.HideClipName + suffix));
                default:
                    return false;
            }
        }

        // NOTE: Animation使用反射來呼叫callback.
        void IUiAnimation.Initialize(Action<IUiAnimation> completeCb)
        {
            string showClipName = string.Format("{0}_{1}", clipNamePrefix, UiBase.ShowClipName);
            string hideClipName = string.Format("{0}_{1}", clipNamePrefix, UiBase.HideClipName);
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            for (int i = 0; i < clips.Length; ++i)
            {
                if (clips[i].name.Contains(showClipName))
                {
                    setCompleteCb(clips[i]);
                    continue;
                }

                if (clips[i].name.Contains(hideClipName))
                {
                    setCompleteCb(clips[i]);
                    continue;
                }
            }
        }

        void IUiAnimation.Play(UiAnimationClip clip, string suffix)
        {
            animator.enabled = true;
            switch (clip)
            {
                case UiAnimationClip.UAC_SHOW:
                    animator.Play(UiBase.ShowClipName + suffix, 0);
                    break;
                case UiAnimationClip.UAC_HIDE:
                    animator.Play(UiBase.HideClipName + suffix, 0);
                    break;
                default:
                    debug.PrintSystem.LogError("[UiAnimator] Unexpected clip: " + clip.ToString() + suffix);
                    return;
            }
        }

        void IUiAnimation.Stop()
        {
            animator.enabled = false;
        }

        protected void setCompleteCb(AnimationClip clip)
        {
            if (clip == null)
            {
                return;
            }

            AnimationEvent evt = new AnimationEvent
            {
                time = clip.length,
                objectReferenceParameter = this,
                functionName = UiBase.OnCompleteFunctionName
            };
            clip.AddEvent(evt);
        }
    }
}