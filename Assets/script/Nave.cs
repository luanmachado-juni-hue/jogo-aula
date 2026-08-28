using UnityEngine;
using UnityEngine.InputSystem;

public class Nave : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 7f;

    [Header("Limites")]
    public float limiteEsquerdo = -7f;
    public float limiteDireito = 7f;

    [Header("Tiro")]
    public GameObject tiroPrefab;
    public Transform pontoDeTiro;
    public float intervaloTiro = 0.25f;

    private float proximoTiro;

    void Update()
    {
        Mover();
        Atirar();
    }

    void Mover()
    {
        float movimento = 0f;

        if (Keyboard.current != null)
        {
            if (
                Keyboard.current.leftArrowKey.isPressed ||
                Keyboard.current.aKey.isPressed
            )
            {
                movimento = -1f;
            }

            if (
                Keyboard.current.rightArrowKey.isPressed ||
                Keyboard.current.dKey.isPressed
            )
            {
                movimento = 1f;
            }
        }

        Vector3 novaPosicao = transform.position;

        novaPosicao.x +=
            movimento *
            velocidade *
            Time.deltaTime;

        novaPosicao.x = Mathf.Clamp(
            novaPosicao.x,
            limiteEsquerdo,
            limiteDireito
        );

        transform.position = novaPosicao;
    }

    void Atirar()
    {
        if (Keyboard.current == null)
            return;

        if (
            Keyboard.current.spaceKey.isPressed &&
            Time.time >= proximoTiro
        )
        {
            proximoTiro =
                Time.time + intervaloTiro;

            if (
                tiroPrefab != null &&
                pontoDeTiro != null
            )
            {
                Instantiate(
                    tiroPrefab,
                    pontoDeTiro.position,
                    Quaternion.identity
                );
            }
        }
    }
}