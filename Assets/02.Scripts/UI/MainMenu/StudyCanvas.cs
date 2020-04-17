using UnityEngine;
using System.Collections;

namespace act.ui
{
    [BindingResource("StudyCanvas")]
    public class StudyCanvas : FullScreenCanvasBase
    {

        [SerializeField] private UiStaticText desc = null;

        private const string mouseName = "mouse";
        public override void Initialize()
        {

        }
        public override void Release()
        {

        }
        public override void Refresh()
        {

        }


        public void ChangeMouseIcon()
        {
            desc.text =
                @"1.可以直接在项目中设置鼠标的icon
                2.可以用代码改变鼠标icon
                3.可以在图片设置中更改图标大小";
            Cursor.SetCursor(ui.UiManager.instance.GetTexture(data.ResourcesPathSetting.MouseTextures, mouseName) as Texture2D,Vector2.zero,CursorMode.Auto);
        }

        public void ExitToMain()
        {
            game.SceneMgr.instance.NextScene = game.SceneEnum.MainMenu;
            game.GameController.instance.FSM.SwitchToState((int)fsm.GameFsmState.ASYNCLOADING);
        }

    }
}
