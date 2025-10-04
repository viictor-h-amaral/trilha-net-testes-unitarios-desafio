using TestesUnitarios.Desafio.Console.Services;

namespace TestesUnitarios.Desafio.Tests;

public class ValidacoesListaTests
{
    private ValidacoesLista _validacoes = new ValidacoesLista();

    [Fact]
    public void DeveRemoverNumerosNegativosDeUmaLista()
    {
        // Arrange
        var lista = new List<int> { 5, -1, -8, 9 };
        var resultadoEsperado = new List<int> { 5, 9 };

        // Act
        var resultado = _validacoes.RemoverNumerosNegativos(lista);

        // Assert
        Assert.Equal(resultadoEsperado, resultado);
    }

    [Fact]
    public void DeveConterONumero9NaLista()
    {
        // Arrange
        var lista = new List<int> { 5, -1, -8, 9 };
        var numeroParaProcurar = 9;

        // Act
        var resultado = _validacoes.ListaContemDeterminadoNumero(lista, numeroParaProcurar);

        // Assert
        Assert.True(resultado);
    }

    [Theory]
    [InlineData(10, new int[] { 5, -1, -8,  11, -26,   41 })]
    [InlineData(-4, new int[] { 5, -1,  4, -11,  50,   41 })]
    [InlineData(0,  new int[] { 5,  4, -8,  11,  102, -86 })]
    public void QuandoListaNaoContemNumeroProcurado_DeveRetornarFalso(int numeroParaProcurar, IList<int> lista)
    {
        var listaConvertida = lista.ToList();

        bool resultado = _validacoes.ListaContemDeterminadoNumero(listaConvertida, numeroParaProcurar);

        Assert.False(resultado);
    }

    [Fact]
    public void DeveMultiplicarCadaElementosDaListaPor2()
    {
        var lista = new List<int> { -1, 0, 5, 7, 8, 9 };
        var resultadoEsperado = new List<int> { -2, 0, 10, 14, 16, 18 };
        
        var resultado = _validacoes.MultiplicarNumerosLista(lista, 2);

        Assert.Equal(resultadoEsperado, resultado);
    }

    [Fact]
    public void DeveRetornar9ComoMaiorNumeroDaLista()
    {
        var lista = new List<int> { 5, -1, -8, 9, 8, 8, -9 };
        int resultadoEsperado = 9;

        int resultado = _validacoes.RetornarMaiorNumeroLista(lista);

        Assert.Equal(resultadoEsperado, resultado);
    }

    [Fact]
    public void DeveRetornarOitoNegativoComoMenorNumeroDaLista()
    {
        var lista = new List<int> { 5, -1, -8, 9, -7, -8, 8};
        int resultadoEsperado = -8;

        var resultado = _validacoes.RetornarMenorNumeroLista(lista);

        Assert.Equal(resultadoEsperado, resultado);
    }
}
