using UnityEngine;

public class Meteoro : MonoBehaviour
{
    [Header("Velocidade")]
    public float velocidade = 0.7f;

    [Header("Limite")]
    public float limiteInferior = -6f;

    private bool jaPontuou = false;

    void Update()
    {
        // Desce devagar
        transform.Translate(
            Vector3.down *
            velocidade *
            Time.deltaTime
        );

        // Saiu da tela
        if (transform.position.y < limiteInferior)
        {
            if (!jaPontuou)
            {
                jaPontuou = true;

                if (GameManager.Instance != null)
                {
                    GameManager.Instance.MeteoroDesviado();
                }
            }

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.PerdeuVida();
            }

            Destroy(gameObject);
        }
    }

    public void DestruirPorTiro()
    {
        if (!jaPontuou)
        {
            jaPontuou = true;

            if (GameManager.Instance != null)
            {
                GameManager.Instance.MeteoroDestruido();
            }
        }

        Destroy(gameObject);
    }
}