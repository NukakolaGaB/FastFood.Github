using UnityEngine;
using System.Collections;

public class AnimacionBoca : MonoBehaviour {

    [SerializeField]
    Animator ninnoAnimator;

    void Start() {

        ninnoAnimator = gameObject.GetComponent<Animator>();

    }
    public void AbrirBoca() {

        ninnoAnimator.SetBool("apuntando", true);

        }
    public void CerrarBoca()
    {
        ninnoAnimator.SetBool("apuntando", false);

    }

}
