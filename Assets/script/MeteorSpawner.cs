using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour
{
    [Header("Prefab do Meteoro")]
    public GameObject meteoroPrefab;

    [Header("Posição")]
    public float posicaoY = 5.5f;

    [Header("Área de Spawn")]
    public float limiteXMin = -7f;
    public float limiteXMax = 7f;

    [Header("Tempo")]
    public float intervalo = 1f;

    [Header("Velocidade")]
    public float velocidadeInicial = 0.7f;

    private GameObject meteoroAtual;

    void Start()
    {
        StartCoroutine(CicloDosMeteoros());
    }

    IEnumerator CicloDosMeteoros()
    {
        while (true)
        {
            // Cria um meteoro
            CriarMeteoro();

            // Espera até o meteoro ser destruído
            while (meteoroAtual != null)
            {
                yield return null;
            }

            // Espera 1 segundo
            yield return new WaitForSeconds(intervalo);
        }
    }

    void CriarMeteoro()
    {
        if (meteoroPrefab == null)
        {
            Debug.LogError(
                "ERRO: O campo Meteoro Prefab está vazio!"
            );

            return;
        }

        float x = Random.Range(
            limiteXMin,
            limiteXMax
        );

        Vector3 posicao = new Vector3(
            x,
            posicaoY,
            0f
        );

        meteoroAtual = Instantiate(
            meteoroPrefab,
            posicao,
            Quaternion.identity
        );

        // Tamanho
        meteoroAtual.transform.localScale =
            new Vector3(0.8f, 0.8f, 1f);

        // Velocidade
        Meteoro scriptMeteoro =
            meteoroAtual.GetComponent<Meteoro>();

        if (scriptMeteoro != null)
        {
            scriptMeteoro.velocidade =
                velocidadeInicial;
        }
        else
        {
            Debug.LogError(
                "ERRO: O prefab não possui o script Meteoro!"
            );
        }
    }
}