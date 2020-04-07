namespace act
{
    namespace fsm
    {
        public class Entry<T> : State<T>
        {
            public override void Enter()
            {
                InitializeGame();
                game.SceneMgr.instance.NextScene = game.SceneEnum.MainMenu;
                m_fsm.SwitchToState((int)fsm.GameFsmState.ASYNCLOADING);
            }

            public override void Exit()
            {

            }

            public override void Update()
            {

            }

            private void InitializeGame()
            {
                // 暫時先放在這邊讀取
                //localization.LocalizationManager.instance.LoadModule("example");
                game.ExampleMgr.instance.InitConfigData();
            }
        }
    }
}