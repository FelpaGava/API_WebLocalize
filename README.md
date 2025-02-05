# 📋 README - Teste Técnico

Este projeto foi desenvolvido como parte de um teste técnico para demonstrar minhas habilidades em desenvolvimento de software, integração com banco de dados e boas práticas de configuração. Abaixo, você encontrará instruções claras e detalhadas para configurar e executar o projeto.

---

## 🛠️ Pré-requisitos

Antes de começar, certifique-se de ter os seguintes itens instalados em sua máquina:

- **SQL Server**: Para gerenciar o banco de dados.
- **Visual Studio**: Para compilar e executar a aplicação.
- **.NET SDK**: Compatível com a versão utilizada no projeto.

---

## 🗄️ Configuração do Banco de Dados

### 1. Conectando ao SQL Server

1. Inicie o aplicativo do SQL Server.
2. No **SQL Server Management Studio (SSMS)**, clique em "Conectar o Pesquisador de Objetos".
3. Copie o **Nome do Servidor** exibido na tela de conexão.
4. Certifique-se de que a autenticação está configurada como **"Autenticação do Windows"**.

### 2. Configurando a Conexão no Projeto

1. No projeto, localize o arquivo `appsettings.json`.
2. Substitua o valor de `"server=*INSIRA AQUI*"` no campo `"DefaultConnection"` pelo nome do seu servidor copiado anteriormente. Exemplo:
   
   ```json
   "DefaultConnection": "server=NOME_DO_SEU_SERVIDOR;Database=NOME_DO_BANCO;Trusted_Connection=True;trustservercertificate=true"

## 🛠️ Criando e Configurando o Banco de Dados

### 1. Executando Migrações

1. Abra o **Visual Studio**.
2. Navegue até **Ferramentas** > **Gerenciador de Pacotes do NuGet** > **Console do Gerenciador de Pacotes**.
3. No console, execute o seguinte comando para criar a migração inicial:
   
   ```bash
   add-migration CriandoBancoDeDados

Isso gerará os arquivos de migração necessários.

Após a criação da migração, execute o comando abaixo para aplicar as alterações ao banco de dados:


```update-database```

### 2. Verificando o Banco de Dados

1. No **SQL Server Management Studio**, verifique se o banco de dados foi criado com sucesso.
2. Confira se todas as tabelas e estruturas estão corretamente configuradas.

---

## 🚀 Executando a Aplicação

1. No **Visual Studio**, compile a solução.
2. Execute o projeto utilizando o comando `F5` ou clicando em **Iniciar**.
3. A API estará disponível no endereço padrão (geralmente `https://localhost:5001` ou `http://localhost:5000`).

---

## 📝 Considerações Finais

Este projeto foi desenvolvido com atenção aos detalhes, seguindo boas práticas de desenvolvimento e configuração. Estou extremamente motivado para contribuir com a equipe e agregar valor à empresa. Caso haja alguma dúvida ou feedback, estou à disposição para discutir e aprimorar ainda mais este trabalho.

Agradeço pela oportunidade e espero fazer parte do time!

---

**Autor**: [Marcos Felipe Gava da Cruz]  
**Contato**: [marcosfelipegava@gmail.com]  
**LinkedIn**: [(https://www.linkedin.com/in/marcos-felipe-gava-093910263/)]
