
# Azor.Tecnologia.Hostex.Api

API para integração com plataformas de hospedagem como **Airbnb**, **Booking.com** e outras.

## Sobre o Hostex

O **Hostex** é responsável por integrar aplicações com plataformas de hospedagem.  
Documentação oficial disponível em: [Hostex API Documentation](https://hostex-openapi.readme.io/reference)

### Integração com Expedia

**Preciso criar novas APIs para integrar com Expedia?**  
*Não é necessário.* Você pode conectar diretamente sua conta Expedia por meio do portal Hostex:  
[Conectar Conta Expedia](https://hostex.io/app/connected-accounts/list)

---

## Documentação da API

Acesse a documentação da API completa para mais detalhes:  
[https://hostex-openapi.readme.io/reference/overview](https://hostex-openapi.readme.io/reference/overview)

---

## Instalação do Pacote

### .NET Core

Para utilizar o pacote **AzorHostexApi** no seu projeto, instale-o com os seguintes comandos:

```bash
# Via CLI do .NET Core
dotnet add package AzorHostexApi --version x.x.x

# Ou via NuGet Package Manager
Install-Package AzorHostexApi -Version x.x.x
```

### Configuração no Projeto

Após a instalação, registre o serviço no **`Program.cs`**:

```csharp
builder.Services.AddAzorHostexApi(hostexAccessToken);
```

> **Nota:** O `hostexAccessToken` deve ser gerado diretamente em sua conta Hostex.

---

## Exemplo de Consumo da API

Abaixo, um exemplo de como consumir a **AzorHostexApi** usando **ASP.NET Core**.

### Controller de Exemplo

```csharp
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HostexController : ControllerBase
{
    private readonly HostexApiClient _httpHostexApiClient;

    public HostexController(HostexApiClient httpHostexApiClient)
    {
        _httpHostexApiClient = httpHostexApiClient;
    }

    // Endpoint para buscar propriedades
    [HttpGet("properties")]
    public async Task<IActionResult> GetProperties(int offset = 0, int limit = 20)
    {
        try
        {
            var properties = await _httpHostexApiClient.GetProperties(offset, limit);
            return Ok(properties);
        }
        catch (HttpRequestException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
```

---

## Suporte

Caso tenha dúvidas ou encontre problemas, confira a documentação oficial no [Hostex API Documentation](https://hostex-openapi.readme.io/reference) ou entre em contato com o suporte.

--- 
