namespace act
{
    namespace fsm
    {
        public class MainMenu<T> : State<T>
        {
            public override void Enter()
            {
                ui.UiManager.instance.OpenUi<ui.MainMenuCanvas>();
            }

            public override void Exit()
            {

            }

            public override void Update()
            {

            }
        }
    }
}