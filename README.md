# GeekBurguer-Ingredients

Microservice de Ingredientes matéria de Arquitetura de Integração e Microservices - FIAP - 11NET

## Escopo

Este microserviço encarrega-se de entregar uma lista de produtos, filtrados por restrições de ingredientes impostas pelo usuario.

### Swagger

Swagger do microserviço: http://geekburger-ingredients.azurewebsites.net/swagger/

### Autores
36155 - Guilherme Mendonça
31231 - Reginaldo Barros
32083 - Jessica Nathany
31889 - Wellington Castor
31993 - Ariel Cavalcante

### Como usar

# Instalação do contrato


# Request

Exemplo:
    "https://geekburger.azure-api.net/ingredients/ingredients/products?restriction=XXXXX"

  O termo "restriction" (indicando as restrições dos ingrediente) da query string, é uma string, aceita mais de um parâmetro, concatenado por ",", sem restrição de quantidade de restrições. A API então busca e retorna os produtos que não possuem os ingredientes passados como parâmetro. Caso não haja restrições, todos os produtos são retornados.

# Response

Code: "200" Success
Body:
```
[
  {
    "productId": "985d9443-f274-4795-869e-3e7b0a61ae1c",
    "items": [
      {
        "id": "29b499bc-60ac-4baf-9311-05b6f6cc3ad4",
        "ingredients": [
          "salt",
          "sugar"
        ]
      }
    ]
  }
]
```

O response da requisição é um JSON, que traz as informações:

-productId: Id do produto/Hamburguer
-Items: 
      -"id": Id do item presente no hamburguer
      -"ingredients": Dados dos ingredientes base do item

Code: "500" Error
```
[
  {
   "Exception Message"
  }
]
```

### Tecnologias utilizadas

## MongoDB

## Asp.NET Core
