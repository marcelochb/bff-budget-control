# BFF Budget Control

### Tecnologias usadas

- Mapster
- MediatR
- FluentValidation
- ErrorOr
- DependenceInjection
- EnityFrameworkCore
- TokenJwt

### Estrutura do projeto

- src =>
  - core => Configurações globais.
    - config =>
    - service => clientes api
    - constants =>
    - interfaces => interfaces globas
    - componentes =>
  - features =>
    - todo
        - dtos => modelagem com regras de negócio
        - infra
            - binds
            - presenter
                - create
                    - controllers
                    - pages
                    - componentes
                - list
        - mocks
        - usecases
- test => testes unitários
