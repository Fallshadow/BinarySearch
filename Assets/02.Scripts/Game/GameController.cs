using UnityEngine;

namespace act
{
    namespace game
    {
        public class GameController : SingletonMonoBehaviorNoDestroy<GameController>
        {
            public readonly fsm.Fsm<GameController> FSM = new fsm.Fsm<GameController>();

            protected override void Awake()
            {
                base.Awake();
            }

            private void Start()
            {
                FSM.Initialize(this);
                FSM.AddState((int)fsm.GameFsmState.ENTRY, new fsm.Entry<GameController>());
                FSM.AddState((int)fsm.GameFsmState.MAINMENU, new fsm.MainMenu<GameController>());
                FSM.AddState((int)fsm.GameFsmState.STUDY, new fsm.Study<GameController>());
                FSM.AddState((int)fsm.GameFsmState.ASYNCLOADING, new fsm.AsyncLoading<GameController>());
                FSM.SwitchToState((int)fsm.GameFsmState.ENTRY);
            }

            private void Update()
            {
                FSM.Update();
            }

            private void FixedUpdate()
            {
                FSM.FixedUpdate();
            }

            private void LateUpdate()
            {
                FSM.LateUpdate();
            }

            private void OnApplicationQuit()
            {
                FSM.Finalize();
            }
        }
    }
}