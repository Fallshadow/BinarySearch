using UnityEngine;
using System.Collections;

namespace act.ui
{
    [BindingResource("MainMenuCanvas")]
    public class MainMenuCanvas : FullScreenCanvasBase
    {
        public override void Initialize()
        {

        }
        public override void Release()
        {

        }
        public override void Refresh()
        {

        }


        public void TurnToStudyScene()
        {
            game.SceneMgr.instance.NextScene = game.SceneEnum.Study;
            game.GameController.instance.FSM.SwitchToState((int)fsm.GameFsmState.ASYNCLOADING);
        }

        public void TurnToPlayTownScene()
        {
            game.SceneMgr.instance.NextScene = game.SceneEnum.Study;
            game.GameController.instance.FSM.SwitchToState((int)fsm.GameFsmState.ASYNCLOADING);
        }

    }
}
