# Relatorio EatToBeat

## Sobre o projeto

O sistema a implementar baseia-se no famoso livro Eat to Beat Disease do doutor e cientista William Li.
Uma das premissas do livro é que há alimentos com características benéficas para a saúde e que se enquadram em 5 principais sistemas de defesa.

## Primeiros Passos
 
#### 1. Criar a base de Dados
Tabelas utilizadas:
Ation; ActionFood; BlackListedFood; Category; FavoriteFood; Food; FoodMeal; Meal; User;
 
#### 2. Primeiro Acesso
Depois de criar a base de dados o utilizador deverá fazer login como "Administrador".
email: "admin@gmail.com"
senha: "Aa123**"
 
 ## Page Administrador
 Após logar como Administrador aparecerá as funcionalidades especificas que só ele podera utilizar. 
 Como Importar Documento. Adicionar, Deletar as Acoes, Categorias e Foods.
  
 #### 1. Importar Documento 
 Em Importar documento, deverá selecionar o arquivo "Listadealimentos.xlsx" que estará dentro da pasta do projeto, e depois clicar em Importar. 
 Após concluida a importacao, as listas de Acao, Categoria, Alimento serão preenchidas, sendo possivel a sua visualizacao e edicao.
 
  #### 2. Page Alimentos
 Na pagina Alimentos é possivel visualizar os dados separados por : FoodName; Action; CategoryName;
 Também é possivel Editar, Detalhar ou Deletar os dados.
 
 #### 3. Page Acoes
 Na pagina Acoes é possivel visualizar os dados separados por : Name;
 Também é possivel Editar, Detalhar ou Deletar os dados.
 
 #### 3. Page Categorias
 Na pagina Categorias é possivel visualizar os dados separados por : Name;
 Também é possivel Editar, Detalhar ou Deletar os dados.
 
 #### 4. General Report
 Em general report para já não aparecerá nada pois ainda nao foi incluída nenhuma meal ou outro User.
  
 ## Page User
 
 #### 1. Registrar um usuário
 O user deverá primeiramente realizar um registro na página Register, com email e senha a escolha.
 Depois deverá comfirmar o email. Depois de Logado, poderá acessar sua Black Listed; Favorite Food; FoodMeals; Meals;
 
 #### 2. Informacao Nutricional
 Dentro da Page encontrar acesso a Análise de alimentos, onde poderá vizualizar informacoes sobre as Foods, Actions e Category.
 
 #### 3. My Black Listed
 Dentro da Page poderá criar sua BlackListed: 
 1. Clicar em Creat new;
 2. Selecionar o alimento desejado dentro da lista de alimentos existente;
 3. Clicar em Create; 
 Depois de adicionar seu primeiro alimento, sua BlackList é criada e agora só é possível adicionar novos alimentos a lista. Logo abaixo aparecerá a lista de todos os alimentos adiconados, sendo possível editar, detalhar ou deletar o aliemento. 
 
 #### 4. My Favorite Food
 Dentro da Page poderá criar sua FavoriteFood: 
 1. Clicar em Creat new;
 2. Selecionar o alimento desejado dentro da lista de alimentos existente;
 3. Clicar em Create;
 Depois de adicionar seu primeiro alimento, sua Favorite Food é criada e agora só é possível adicionar novos alimentos a lista. Logo abaixo aparecerá a lista de todos os alimentos adiconados, sendo possível editar, detalhar ou deletar o aliemento. . 
 
 #### 5. My Meals
 Dentro da Page poderá criar suas Refeicões: 
 1. Escrever o Nome da refeicão no primeiro campo;
 2. Selecionar o inicio da sua refeicão;
 3. Selecionar o fim da sua refeicão;
 4. Clicar em Create;
 Depois de criar sua refeicão, aparecerá uma lista com todas as refeicões criadas, com sua data de inicio e fim, sendo possível editar, detalhar ou deletar a refeicão.
 
 #### 6. My FoodMeals
 Dentro da Page poderá adicionar os alimentos consumidos dentro da Refeicão acima: 
 1. Selecionar a refeicão no campo MealId;
 2. Selecionar o alimento no campo FoodId;
 3. Selecionar a quantidade consumida no campo Amount;
 4. Selecionar a porcão (em gramas ou unidades) no campo Portion;
 4. Clicar em Create;
Depois de criar sua foodMeal, aparecerá uma lista com os alimentos adiconados, separados por: Name; Amount; Portion; 
Sendo possível editar, detalhar ou deletar cada alimento da sua Refeicão.

 ## General Report
 Depois de adicionados os Users e as Meals já é possível visualizar dentro do utilizador "Administrador" : os 5 top users mais Ativos; os top 10 alimentos mais consumidos; o número total de refeicões já registradas; e o número total de utilizadores.  
 
 

 
 
