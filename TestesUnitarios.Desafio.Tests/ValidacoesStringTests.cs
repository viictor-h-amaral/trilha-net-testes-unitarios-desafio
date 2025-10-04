using TestesUnitarios.Desafio.Console.Services;

namespace TestesUnitarios.Desafio.Tests;

public class ValidacoesStringTests
{
    private ValidacoesString _validacoes = new ValidacoesString();

    [Theory]
    [InlineData(6, "matrix")]
    [InlineData(6, "victor")]
    [InlineData(11, "hello world")]
    [InlineData(0, "")]
    [InlineData(1, "1")]
    [InlineData(1, " ")]
    public void DeveRetornarQuantidadeCorretaDeCaracteresDaString(int quantidadeCorreta, string texto)
    {
        var resultado = _validacoes.RetornarQuantidadeCaracteres(texto);

        Assert.Equal(quantidadeCorreta, resultado);
    }

    [Theory]
    [InlineData("ola", " ola ola ola ")]
    [InlineData("6", "numero 6 (seis)")]
    [InlineData("(seis", "numero 6 (seis)")]
    public void DeveConterASubStringNoTexto(string substring, string texto)
    {
        bool contemSubString = _validacoes.ContemSubString(texto, substring);

        Assert.True(contemSubString);
    }

    [Theory]
    [InlineData("o la", " ola ola ola ")]
    [InlineData("06", "numero 6 (seis)")]
    [InlineData("( seis", "numero 6 (seis)")]
    public void NaoDeveConterASubStringNoTexto(string substring, string texto)
    {
        bool contemSubString = _validacoes.ContemSubString(texto, substring);

        Assert.False(contemSubString);
    }

    [Fact]
    public void TextoDeveTerminarComAPalavraProcurado()
    {
        var texto = "Começo, meio e fim do texto procurado";
        var textoProcurado = " procurado";

        bool resultado = _validacoes.TextoTerminaCom(texto, textoProcurado);

        Assert.True(resultado);
    }
}
