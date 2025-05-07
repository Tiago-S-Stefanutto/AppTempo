# AppTempo - Aplicativo de Previsão do Tempo

AppTempo é uma aplicação móvel desenvolvida com .NET MAUI (Multi-platform App UI) que permite aos usuários consultar informações meteorológicas atuais de diferentes cidades ao redor do mundo.

## Funcionalidades

- Consulta de dados meteorológicos em tempo real
- Pesquisa por nome de cidade
- Apresentação de dados detalhados como:
  - Temperatura atual, máxima e mínima
  - Descrição do clima
  - Horários de nascer e pôr do sol
  - Velocidade do vento
  - Coordenadas geográficas
  - Visibilidade

## Tecnologias Utilizadas

- .NET MAUI (Multi-platform App UI)
- C# / XAML
- API OpenWeatherMap
- Newtonsoft.Json para processamento de dados JSON

## Plataformas Suportadas

- Android
- iOS
- Windows
- MacOS (via Catalyst)

## Requisitos

- Visual Studio 2022 com suporte a .NET MAUI
- .NET 9.0
- Chave de API do OpenWeatherMap

## Como Começar

1. Clone o repositório:
   ```
   git clone https://github.com/Tiago-S-Stefanutto/AppTempo.git
   ```

2. Abra a solução (`AppTempo.sln`) no Visual Studio 2022

3. No arquivo `Services/DataServices.cs`, substitua o texto "Your OpenWeather api key" pela sua chave de API do OpenWeatherMap

4. Compile e execute o aplicativo em seu dispositivo ou emulador preferido

## Como Usar

1. Inicie o aplicativo
2. Digite o nome da cidade desejada no campo de entrada
3. Clique no botão "Search"
4. Os dados meteorológicos serão exibidos na tela

## Estrutura do Projeto

- **AppTempo**: Projeto principal
  - **Models**: Classes de modelo de dados
  - **Services**: Serviços para consumo de APIs
  - **Platforms**: Código específico para cada plataforma

## Licença

[MIT License](LICENSE)

## Autor

Tiago S. Stefanutto

## Agradecimentos

- OpenWeatherMap pela disponibilização da API
- Equipe de desenvolvimento do .NET MAUI
