namespace act
{
    namespace fsm
    {
        public class Study<T> : State<T>
        {
            public override void Enter()
            {
                ui.UiManager.instance.OpenUi<ui.StudyCanvas>();
            }

            public override void Exit()
            {

            }

            public override void Update()
            {

            }

            private void InitializeGame()
            {

            }
        }
    }
}