using Dominio.Entidades;
using Integracao;
using Newtonsoft.Json;

namespace prova;

public partial class ShareDetails : ContentPage
{

    private readonly BaseClient _client = new BaseClient();
    private string _simboloAcao;

    public ShareDetails(string simboloAcao)
    {
        InitializeComponent();
        _simboloAcao = simboloAcao;
        ShareDetailsMetodo(_simboloAcao);
    }
    private async Task ShareDetailsMetodo(String simboloAcao)
    {
        HttpResponseMessage respostaAPI = await _client.GetShare(simboloAcao);
        string conteudo = await respostaAPI.Content.ReadAsStringAsync();
        EntidadeAcao entidade = JsonConvert.DeserializeObject<EntidadeAcao>(conteudo);


        shortName.Text = $"{entidade.ShortName}";
        longName.Text = $"{entidade.LongName}";
        regularMarketChange.Text = $"{entidade.RegularMarketChange}";
        regularMarketChangePercent.Text = $"{entidade.RegularMarketChangePercent}";
        regularMarketPrice.Text = $"{entidade.RegularMarketPrice}";
        regularMarketDayHigh.Text = $"{entidade.RegularMarketDayHigh}";
    }
}