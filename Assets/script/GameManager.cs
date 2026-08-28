using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text textoPontos;
    public TMP_Text textoVidas;
    public TMP_Text textoTempo;
    public TMP_Text textoGameOver;

    public int vidasIniciais = 3;

    private int vidas;
    private int pontos;
    private float tempo;
    private bool gameOver;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        vidas = vidasIniciais;
        pontos = 0;
        tempo = 0f;
        gameOver = false;

        if (textoGameOver != null)
        {
            textoGameOver.gameObject.SetActive(false);
        }

        AtualizarUI();
    }

    void Update()
    {
        if (gameOver)
            return;

        tempo += Time.deltaTime;

        AtualizarTempo();
    }

    public void MeteoroDesviado()
    {
        pontos += 10;
        AtualizarUI();
    }

    public void MeteoroDestruido()
    {
        pontos += 25;
        AtualizarUI();
    }

    public void PerdeuVida()
    {
        if (gameOver)
            return;

        vidas--;

        AtualizarUI();

        if (vidas <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;

        if (textoGameOver != null)
        {
            textoGameOver.gameObject.SetActive(true);
        }

        Debug.Log("GAME OVER!");
    }

    void AtualizarUI()
    {
        if (textoPontos != null)
        {
            textoPontos.text = "Pontos: " + pontos;
        }

        if (textoVidas != null)
        {
            textoVidas.text = "Vidas: " + vidas;
        }
    }

    void AtualizarTempo()
    {
        if (textoTempo != null)
        {
            int minutos = Mathf.FloorToInt(tempo / 60f);
            int segundos = Mathf.FloorToInt(tempo % 60f);

            textoTempo.text =
                string.Format(
                    "Tempo: {0:00}:{1:00}",
                    minutos,
                    segundos
                );
        }
    }

    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}