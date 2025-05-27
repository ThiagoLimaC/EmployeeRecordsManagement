# EmployeeRecordsManagement

<img src="wwwroot/img/videoEmployeeMng.gif" width=700px>

## Visão Geral

O **EmployeeRecordsManagement** é um projeto desenvolvido em .NET 9 com foco em Blazor, destinado ao gerenciamento de registros de funcionários e departamentos. O sistema permite cadastrar, editar, listar e remover funcionários e departamentos, promovendo boas práticas de arquitetura e desenvolvimento web moderno.

---

## Principais Funcionalidades

- Cadastro, edição, listagem e exclusão de funcionários
- Cadastro, edição, listagem e exclusão de departamentos
- Validação de dados no lado do servidor
- Interface responsiva utilizando Bootstrap
- Separação clara entre camadas de apresentação, domínio e dados

---

## Padrão de Projeto em Destaque: Repository Pattern

### O que é Repository Pattern?

O **Repository Pattern** (Padrão Repositório) é uma abordagem de design que abstrai a lógica de acesso a dados, centralizando operações de leitura e escrita em classes específicas chamadas *repositórios*. Isso facilita a manutenção, os testes e a evolução do sistema, pois desacopla a lógica de negócios da infraestrutura de dados.

### Como foi aplicado neste projeto?

- **Interfaces de Repositório**:  
  Foram criadas interfaces como `IEmployeeRepository` e `IDepartmentRepository` para definir os contratos de acesso a dados.
- **Implementações Concretas**:  
  As classes `EmployeeRepository` e `DepartamentRepository` implementam essas interfaces, utilizando o Entity Framework Core para interagir com o banco de dados.
- **Injeção de Dependência**:  
  Os repositórios são injetados nos controllers e componentes Blazor, promovendo baixo acoplamento e facilitando a troca de implementações (por exemplo, para testes unitários com mocks).
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

- **Benefícios Observados**:
  - Facilidade para testar a lógica de negócio sem depender do banco de dados real
  - Centralização das regras de acesso a dados
  - Código mais limpo e organizado

---

## Como Executar

1. **Pré-requisitos**:  
   - .NET 9 SDK  
   - SQL Server ou outro banco de dados configurado no `AppDbContext`

2. **Restaurar dependências**:
`dotnet restore`

3. **Aplicar migrações e atualizar o banco**:
`dotnet ef database update`

4. **Executar o projeto**:
`dotnet run`

5. **Acessar no navegador**:
`https://localhost:7202`

---

## Aprendizados

- **Repository Pattern**:  
  O projeto demonstra como aplicar o padrão repositório para isolar a lógica de acesso a dados, tornando o código mais testável e sustentável.
- **Blazor e ASP.NET Core**:  
  Integração de componentes modernos de UI com backend robusto.
- **Boas práticas de validação e organização de código**.

---
## Créditos
Este projeto foi inspirado pelo tutorial de JustPickLearn disponível no canal do YouTube. Agradecimentos especiais a Codingblue por compartilhar seu conhecimento e ajudar a comunidade de desenvolvedores.