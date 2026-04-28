# 🏦 Algoritmo do Banqueiro (Banker's Algorithm)

Esse projeto foi desenvolvido como um trabalho prático da disciplina Sistemas Operacionais do curso de Sistemas de Informação da PUC Minas. É uma implementação em C# do Algoritmo do Banqueiro, utilizado em Sistemas Operacionais para evitar deadlocks por meio da verificação de estados seguros.

---

## 📚 Sobre o Projeto

Este projeto simula um sistema com múltiplos clientes (threads) que solicitam e liberam recursos de forma concorrente.

O algoritmo garante que:
- O sistema nunca entre em estado inseguro
- Deadlocks sejam evitados
- Apenas requisições seguras sejam atendidas

---

## ⚙️ Tecnologias utilizadas

- C#
- .NET 9
- Multithreading (Thread)
- Controle de concorrência com `lock` (mutex)

---

## 🧠 Conceitos aplicados

- Algoritmo do Banqueiro
- Deadlock avoidance
- Estado seguro (Safe State)
- Concorrência
- Sincronização de threads

---

## ▶️ Como executar

### Pré-requisitos:
- .NET instalado

Verifique com:

```bash
dotnet --version
````

### 🚀 Passo a passo

1. Abra o terminal de sua preferência:
   - Prompt de Comando (CMD)
   - PowerShell
   - Terminal do Linux/Mac

2. Clone ou baixe este repositório:
```
git clone https://github.com/moisesmaaia/Trabalho-Pratico-1-Algoritmo-do-Banqueiro.git
```

3. Acesse a pasta do projeto:
```
cd Trabalho-Pratico-1-Algoritmo-do-Banqueiro
```

4. Execute o programa com o comando:
```
cd AlgoritmoBanqueiro
dotnet run -- <quantidade_recurso_1> <quantidade_recurso_2> <quantidade_recurso_3>

```

5. Exemplo prático:
```
cd AlgoritmoBanqueiro
dotnet run -- 10 5 7
```

No exemplo acima, o sistema será iniciado com:
- 10 unidades do recurso 1
- 5 unidades do recurso 2
- 7 unidades do recurso 3

Para encerrar o programa, pressione **Ctrl+C**.

---

## 📁 Estrutura dos arquivos

| Arquivo | Responsabilidade |
|---|---|
| `Bank.cs` | Estruturas de dados e lógica do banqueiro: `request_resources`, `release_resources` e algoritmo de segurança |
| `Customer.cs` | Thread de cliente: solicita e libera recursos aleatoriamente em loop contínuo |
| `Program.cs` | Ponto de entrada: lê os argumentos, inicializa o banco e cria as threads |


