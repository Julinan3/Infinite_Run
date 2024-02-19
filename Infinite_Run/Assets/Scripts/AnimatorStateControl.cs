using UnityEngine;

public class AnimatorStateControl : StateMachineBehaviour
{
    //karakterin animasyon esnasinda fiziksel etkilesimlerini kontrol eden kod
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Run"))
        {
            Physics.IgnoreLayerCollision(6, 7, false);
            Physics.IgnoreLayerCollision(6, 8, false);
        }
        //karakterin yuvarlanma animasyonu oynadigi surece yuvarlanarak gecilen engeller ona zarar veremez
        if (stateInfo.IsName("Roll"))
        {
            Physics.IgnoreLayerCollision(6, 7, true);
        }
        //karakterin atlama animasyonu oynadigi surece atlanarak gecilen engeller ona zarar veremez
        if (stateInfo.IsName("Jump"))
        {
            Physics.IgnoreLayerCollision(6, 8, true);
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(stateInfo.IsName("Roll")|| stateInfo.IsName("Jump"))
        {
            Physics.IgnoreLayerCollision(6, 7, false);
            Physics.IgnoreLayerCollision(6, 8, false);
        }
    }
}
