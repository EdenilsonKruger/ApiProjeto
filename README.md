# ApiProjeto
Cadastro Clientes
### Descrição
Clarice Ana Elisa Moreira é uma secretária de turismo da empresa Agência Moreira. E como secretária da empresa ela precisa deixar o cadastro dos clientes sempre atualizado.
## Construído com
Front-End:
* .NET Core 3.1
* Bootstrap v4.3.1
* Microsoft.AspNetCore.Mvc
* RestSharp

Back-End:
* DDD
* .NET Core 3.1
* Swagger 6.4.0
* FluentValidation 11.2.2
* AutoMapper 12.0.0
* Microsoft.EntityFrameworkCore 3.1.30

## Começando
### Dependências
* Visual Studio 2022;
* Sql Server 2019;

### Executando programa
* Para criar o banco de dados vai ser necessário executar o script 01 na pasta App_Data:
![image](https://user-images.githubusercontent.com/115954543/196936891-26cb8540-0746-421c-b364-ac4a465269f4.png)
 
* Necessário configurar a conexão com o banco de dados no arquivo appsettings.json:
 ![image](https://user-images.githubusercontent.com/115954543/196936901-93d7d225-c3e4-4ca0-8ebf-f91b07ecf2a2.png)
 ![image](https://user-images.githubusercontent.com/115954543/196936919-25d972ea-aa67-4497-831f-a1793c240c23.png)
 
* Configurando porta Back-End:

![image](https://user-images.githubusercontent.com/115954543/196936930-802b4051-cbe8-4ec8-a86e-ac5d37fe06fe.png)
![image](https://user-images.githubusercontent.com/115954543/196936936-128c8a73-90db-4454-afe0-5298177b202e.png)
![image](https://user-images.githubusercontent.com/115954543/196936945-76677ec6-59f1-47d7-81e3-bf7b42b1bb1e.png)

 
* Configurando a Url no Front-End:

![image](https://user-images.githubusercontent.com/115954543/196936954-772615cf-06d8-4ac0-9d99-9b5c78260c62.png)
![image](https://user-images.githubusercontent.com/115954543/196936959-54d3980c-c197-449a-aa7b-aec12085c1dc.png)
 
* Configurando o projeto para executar o Front e Back ao mesmo tempo:

  1 - Propriedades da Solução:
 
  ![image](https://user-images.githubusercontent.com/115954543/196936970-63552287-120d-4e16-a059-72169991acd4.png)
  ![image](https://user-images.githubusercontent.com/115954543/196936980-bbd585bf-2aae-481b-8b30-3a6a76da521b.png)
 
  2 – Alterando a Ação para Iniciar:
 
  ![image](https://user-images.githubusercontent.com/115954543/196936986-a5c66edd-ea45-4b4e-84d8-3c928436f365.png)

* Podemos executar o sistema:

  1 – Crud básico no Swagger:
  
  ![image](https://user-images.githubusercontent.com/115954543/196936990-b845fbb4-db6a-4184-b127-cca36c09e86c.png)
  
  2 – Crud básico em MVC consultando as rotas:
  
  2.1 – Consulta:
  
  ![image](https://user-images.githubusercontent.com/115954543/196937020-1dfa051d-901d-4711-890d-5200596271d6.png)
 
  2.2 – Novo:
  
  ![image](https://user-images.githubusercontent.com/115954543/196937039-9bfb5f75-eec3-4288-9195-ce5d8a96f4eb.png)
  
  2.3 – Editar:
  
  ![image](https://user-images.githubusercontent.com/115954543/196937053-a1442bf0-3b97-4c4b-b59d-7da77252fcd1.png)
 
  2.4 – Visualizar:
  
  ![image](https://user-images.githubusercontent.com/115954543/196937062-a68af690-0056-42eb-b91b-73549e2c8fbb.png)
 
  2.5 – Excluir:
  
  ![image](https://user-images.githubusercontent.com/115954543/196937072-840795cb-57e2-4475-a9f5-d04c48d01bcc.png)
 
## Melhorias
* Na segunda versão vai ser implantado: Migrations, teste unitário e teste integrado.

## Autor
* Edenilson Krüger – edenilsonkruger@hotmail.com

## Histórico de versões
* 1.0 - Lançamento inicial
