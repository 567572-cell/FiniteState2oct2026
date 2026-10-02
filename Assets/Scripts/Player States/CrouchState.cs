using UnityEngine;

public class CrouchState : State
{
    public CrouchState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("entering crouch state");

        player.sr.color = new Color(0.8f, 0.6f, 0.3f);
        player.rb.linearVelocity = Vector2.zero;   // stop moving while crouched
        player.anim.SetBool("isCrouch", true);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("exiting crouch state");

        player.StopAllCoroutines();
        player.anim.SetBool("isCrouch", false);
    }

    public override void Update()
    {
        // let go of the crouch key -> back to idle
        if (!player.crouchAction.IsPressed())
        {
            sm.ChangeState(sm.idleState);
        }

        UIscript.ui.DrawText("*** This is the crouch state ***\n");
        UIscript.ui.DrawText("Release C = Idle State");
    }

    public override void FixedUpdate()
    {
    }


}
