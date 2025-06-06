# Nobreaking - Global Solution Nobreak Management System


# Integrantes

* Gabriel Dalaqua - RM551986
* Paloma Mirela - RM551321
* Victor Kenzo - RM551649



## Finalidade do Sistema
Nobreaking é um sistema de gerenciamento de nobreaks hospitalares desenvolvido em Windows Forms (C#). O objetivo principal é oferecer uma ferramenta integrada que permita a hospitais e outras instituições de saúde gerenciarem de forma centralizada e proativa todo o ciclo de vida dos nobreaks (UPS) – desde o cadastro e monitoramento em tempo real até a manutenção preventiva e geração de relatórios gerenciais.

## Dependências
1. **Ambiente de Desenvolvimento**  
   - Windows 10 ou superior  
   - Visual Studio 2019 (ou superior) com workload de desenvolvimento em .NET Desktop

2. **.NET Framework**  
   - .NET Framework 8.0 (ou superior)

3. **Banco de Dados**  
   - SQLite (System.Data.SQLite)  
   - O arquivo de banco (`NobreakDB.sqlite`) será criado automaticamente na primeira execução.

4. **Pacotes NuGet**  
   - `System.Data.SQLite`  
   - `iTextSharp` (para geração de relatórios em PDF)  
   - `ReaLTaiizor` (biblioteca de ícones para WinForms)  
   - `WinForms.DataVisualization` (para dashboards e gráficos)

5. **Outros Recursos**  
   - Ícones e assets adicionais (embutidos via ReaLTaiizor)  

## Instruções de Execução
1. **Clone o Repositório**
   ```bash
   git clone https://github.com/seu-usuario/Nobreaking.git
   cd Nobreaking
   ```

2. **Abra a Solução no Visual Studio**
   - Abra o arquivo `Nobreaking.sln`.
   - Aguarde o Visual Studio restaurar todos os pacotes NuGet automaticamente.

3. **Configuração Inicial**
   - Na primeira execução, o sistema criará a pasta Com o nome do projeto na pasta Roaming do sistema do usuário na raiz do projeto e gerará o arquivo `NobreakDB.sqlite` (banco SQLite).

4. **Compilação e Execução**
   - Selecione `Debug` ou `Release` conforme sua necessidade.
   - Pressione **F5** (ou clique em “Iniciar Depuração”) para executar o aplicativo.  
   - O formulário de login aparecerá; cadastre um usuário e senha para acessar o sistema.

5. **Uso Básico**
   1. **Tela de Login**: Informe e-mail e senha cadastrados.  
   2. **Menu Principal**: Navegue entre as opções:
      - **Nobreaks**: Cadastro, edição e arquivamento de nobreaks.
      - **Monitoramento**: Inicie/parar leituras periódicas e visualize status em tempo real.
      - **Dashboard**: Histórico completo de incidentes registrados.
      - **Relatórios**: Geração e visualização de PDF com inventário, indicadores e incidentes.
   3. **Registrar Manutenção**: Dentro do form de Nobreak, use o botão específico para atualizar data de manutenção.

## Estrutura de Pastas
```
Nobreaking/
├── Data/                          # Relacionado a configurações iniciais do Banco de Dados              
├── Models/                        # Entidades de domínio (C# classes)
├── Repositories/                  # Acesso a dados (classes que conversam com o SQLite)
├── Services/                      # Lógica de negócio e validações
├── Utils/                         # Utilitários e helpers (validações, hashing)
├── Forms/                         # Telas WinForms (UI)
```
