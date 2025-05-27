# EmployeeRecordsManagement

<img src="wwwroot/img/videoEmployeeMng.gif" width=700px>

## Vis�o Geral

O **EmployeeRecordsManagement** � um projeto desenvolvido em .NET 9 com foco em Blazor, destinado ao gerenciamento de registros de funcion�rios e departamentos. O sistema permite cadastrar, editar, listar e remover funcion�rios e departamentos, promovendo boas pr�ticas de arquitetura e desenvolvimento web moderno.

---

## Principais Funcionalidades

- Cadastro, edi��o, listagem e exclus�o de funcion�rios
- Cadastro, edi��o, listagem e exclus�o de departamentos
- Valida��o de dados no lado do servidor
- Interface responsiva utilizando Bootstrap
- Separa��o clara entre camadas de apresenta��o, dom�nio e dados

---

## Padr�o de Projeto em Destaque: Repository Pattern

### O que � Repository Pattern?

O **Repository Pattern** (Padr�o Reposit�rio) � uma abordagem de design que abstrai a l�gica de acesso a dados, centralizando opera��es de leitura e escrita em classes espec�ficas chamadas *reposit�rios*. Isso facilita a manuten��o, os testes e a evolu��o do sistema, pois desacopla a l�gica de neg�cios da infraestrutura de dados.

### Como foi aplicado neste projeto?

- **Interfaces de Reposit�rio**:  
  Foram criadas interfaces como `IEmployeeRepository` e `IDepartmentRepository` para definir os contratos de acesso a dados.
- **Implementa��es Concretas**:  
  As classes `EmployeeRepository` e `DepartamentRepository` implementam essas interfaces, utilizando o Entity Framework Core para interagir com o banco de dados.
- **Inje��o de Depend�ncia**:  
  Os reposit�rios s�o injetados nos controllers e componentes Blazor, promovendo baixo acoplamento e facilitando a troca de implementa��es (por exemplo, para testes unit�rios com mocks).
- **Exemplo de Uso**:

```
public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _employeeRepository.GetAllAsync();
        return View(employees);
    }
}
```

- **Benef�cios Observados**:
  - Facilidade para testar a l�gica de neg�cio sem depender do banco de dados real
  - Centraliza��o das regras de acesso a dados
  - C�digo mais limpo e organizado

---

## Como Executar

1. **Pr�-requisitos**:  
   - .NET 9 SDK  
   - SQL Server ou outro banco de dados configurado no `AppDbContext`

2. **Restaurar depend�ncias**:
`dotnet restore`

3. **Aplicar migra��es e atualizar o banco**:
`dotnet ef database update`

4. **Executar o projeto**:
`dotnet run`

5. **Acessar no navegador**:
`https://localhost:7202`

---

## Aprendizados

- **Repository Pattern**:  
  O projeto demonstra como aplicar o padr�o reposit�rio para isolar a l�gica de acesso a dados, tornando o c�digo mais test�vel e sustent�vel.
- **Blazor e ASP.NET Core**:  
  Integra��o de componentes modernos de UI com backend robusto.
- **Boas pr�ticas de valida��o e organiza��o de c�digo**.

---
## Cr�ditos
Este projeto foi inspirado pelo tutorial de JustPickLearn dispon�vel no canal do YouTube. Agradecimentos especiais a Codingblue por compartilhar seu conhecimento e ajudar a comunidade de desenvolvedores.