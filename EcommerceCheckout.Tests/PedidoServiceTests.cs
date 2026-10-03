using EcommerceCheckout.App;

namespace EcommerceCheckout.Tests;

public class PedidoServiceTests
{
    private readonly PedidoService _service = new();

    [Fact]
    public void GerarCodigoRastreio_DeveFormatarRegiaoENumeroPedido()
    {
        var resultado = _service.GerarCodigoRastreio("sudeste", 42);
        Assert.Equal("SUDESTE-0042", resultado);
    }

    [Fact]
    public void CalcularPontosFidelidade_DeveCalcularPontos()
    {
        var resultado = _service.CalcularPontosFidelidade(150);
        Assert.Equal(30, resultado);
    }

    [Fact]
    public void TemDireitoAFreteGratis_DevePermitirVIPAbaixoDeDuzentosReais()
    {
        var resultado = _service.TemDireitoAFreteGratis(150, true);
        Assert.True(resultado);
    }

    [Fact]
    public void TemDireitoAFreteGratis_DeveNegarNaoVIPAbaixoDeDuzentosReais()
    {
        var resultado = _service.TemDireitoAFreteGratis(150, false);
        Assert.False(resultado);
    }

    [Fact]
    public void TemDireitoAFreteGratis_DevePermitirNaoVIPNoLimite()
    {
        Assert.True(_service.TemDireitoAFreteGratis(200, false));
    }

    [Fact]
    public void CalcularPontosFidelidade_DeveDesconsiderarParcelaIncompleta()
    {
        Assert.Equal(30, _service.CalcularPontosFidelidade(159));
    }
}
