using act.ui;
namespace act
{
    namespace fsm
    {
        public class AsyncLoading<T> : State<T>
        {
            public override void Enter()
            {
                loading();
            }

            public override void Exit()
            {

            }

            public override void Update()
            {

            }

            private void loading()
            {
                SceneFadeCanvas sceneFadeCanvas = UiManager.instance.CreateUi<SceneFadeCanvas>();
                UiManager.instance.OpenUi<ui.SceneFadeCanvas>();
                switch(game.SceneMgr.instance.NextScene)
                {
                    case game.SceneEnum.Entry:
                        break;
                    case game.SceneEnum.MainMenu:
                        sceneFadeCanvas.fadeType = FadeType.FullBlackFade;
                        sceneFadeCanvas.FadeOut(
                            () =>
                            {
                                game.SceneMgr.instance.LoadSceneAsync(game.SceneEnum.MainMenu,
                                    () =>
                                    {
                                        m_fsm.SwitchToState((int)fsm.GameFsmState.MAINMENU);
                                        sceneFadeCanvas.FadeIn(() => { sceneFadeCanvas.Close(); });
                                    });
                            }
                        );
                        break;
                    case game.SceneEnum.Study:
                        sceneFadeCanvas.fadeType = FadeType.FullBlackFade;
                        sceneFadeCanvas.FadeOut(
                            () =>
                            {
                                game.SceneMgr.instance.LoadSceneAsync(game.SceneEnum.Study,
                                    () =>
                                    {
                                        m_fsm.SwitchToState((int)fsm.GameFsmState.STUDY);
                                        sceneFadeCanvas.FadeIn(()=> { sceneFadeCanvas.Close(); });
                                    });
                            }
                        );
                        break;
                    default:
                        break;
                }
            }
        }
    }
}