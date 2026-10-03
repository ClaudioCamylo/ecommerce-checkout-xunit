# EcommerceCheckout

Lista 22 de Garantia da Qualidade de Software / Gestão e Qualidade de Software. Professor Daniel Henrique Matos de Paiva.

**Autor:** Cláudio Martins Camilo  
**RA:** 325131832

## Tecnologias e estrutura

- .NET 10 e C#.
- xUnit para testes unitários.
- EcommerceCheckout.sln: solução com os dois projetos.
- EcommerceCheckout.App: aplicação de console e classe PedidoService.
- EcommerceCheckout.Tests: testes com referência ao projeto App.

## Métodos

| Método | Regra | Exemplo |
| --- | --- | --- |
| GerarCodigoRastreio(string regiao, int numeroPedido) | Região em maiúsculas, hífen e número com zeros à esquerda até quatro dígitos. | ("sudeste", 42) → "SUDESTE-0042" |
| CalcularPontosFidelidade(int valorTotal) | Dois pontos por cada R$ 10 completos; descarta a parcela incompleta. | 150 → 30 |
| TemDireitoAFreteGratis(int valorTotal, bool eClienteVIP) | Retorna true se o valor for maior ou igual a R$ 200 ou o cliente for VIP. | (150, true) → true; (150, false) → false |

## Cobertura dos testes

Os seis testes de PedidoServiceTests.cs usam [Fact] e verificam:

1. Código exato com Assert.Equal("SUDESTE-0042", resultado).
2. Pontos para R$ 150 com Assert.Equal(30, resultado).
3. Frete grátis para VIP abaixo de R$ 200 com Assert.True.
4. Ausência de frete grátis para não-VIP abaixo de R$ 200 com Assert.False.
5. Frete grátis para não-VIP exatamente no limite de R$ 200.
6. Descarte da parcela incompleta de R$ 10 (R$ 159 → 30 pontos).

## Execução

Com o SDK .NET 10 instalado, execute na raiz do repositório:

```sh
dotnet build
dotnet test
```

O build restaura as dependências e compila a solução. dotnet test executa todos os testes xUnit.

Para executar a demonstração:

```sh
dotnet run --project EcommerceCheckout.App
```

## Licença

Licença MIT, disponível no arquivo LICENSE.
