using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float velocidade = 10f;
    public float limiteSuperior = 7f;

    void Update()
    {
        transform.Translate(
            Vector3.up *
            velocidade *
            Time.deltaTime
        );

        if (transform.position.y > limiteSuperior)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Meteoro meteoro =
            other.GetComponent<Meteoro>();

        if (meteoro != null)
        {
            meteoro.DestruirPorTiro();

            Destroy(gameObject);
        }
    }
}