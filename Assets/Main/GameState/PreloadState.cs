//-----------------------------------------------------------------------
// <copyright>
//     Copyright (c) 2018 wanderer. All rights reserved.
// </copyright>
// <describe> #预加载状态# </describe>
// <email> dutifulwanderer@gmail.com </email>
// <time> #2018年7月8日 15点55分# </time>
//-----------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer.GameFramework;

namespace Main.GameState
{
    public partial class PreloadState : FSMState<GameStateContext>
    {
        public override void OnEnter(FSM<GameStateContext> fsm)
        {
            base.OnEnter(fsm);
            Debug.Log("OnEnter PreloadState");
        }

        public override void OnExit(FSM<GameStateContext> fsm)
        {
            base.OnExit(fsm);
            Debug.Log("OnExit PreloadState");
        }

        public override void OnUpdate(FSM<GameStateContext> fsm)
        {
            base.OnUpdate(fsm);
            
        }
    }
}
