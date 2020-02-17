# crmall-test

Teste cadastro de clientes

# Objetivo:
Desenvolver sistema para cadastro de clientes com as funcionalidades de listagem, adição/edição e remoção.              
   1ª tela: Listagem dos clientes cadastrados em grid, disponibilizar botões: Adicionar, editar e remover clientes. <br>
   2ª tela: Tela para adicionar/editar clientes. <br>


 # Resumo do projeto: 
 
 Para um projeto simples de CRUD como esse um modelo de api data-driven era mais enxuto e barato, mas como é um teste, resolvi utilizar conceitos mais avançados para afim de demonstração e compartilhar. 
 
 # API:

 Na api procurei utilizar:  
 	
<ul> 
<li><b>Conceitos de OOP, SOLID e Clean Code</b> </li>

<li><b>Arquitetura em camadas tatica DDD para uma facil futura implementação de microserviços com contextos limitados e pattern como domain notification</b> <br>

 ![GitHub Logo](/Onion%20Layers.png)

<br> <br>

<i>Referencias:</i> <br><br>
<a href="https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice">
	https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice 
</a> <br>
<br>
Domain notification <br> 
<a href="https://martinfowler.com/eaaDev/Notification.html">https://martinfowler.com/eaaDev/Notification.html</a><br>
<a href="https://martinfowler.com/articles/replaceThrowWithNotification.html">https://martinfowler.com/articles/replaceThrowWithNotification.html</a> <br>
</li>

<li> 
<b>CQRS, Repository e UnitOfWork</b> <br> <br>
	
 ![GitHub Logo](/cqrs.png) <br>	
	
<i>Referencias:</i>

 
<a href="https://martinfowler.com/bliki/CQRS.html">https://martinfowler.com/bliki/CQRS.html</a> <br/>

<a href="https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/cqrs-microservice-reads">https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/cqrs-microservice-reads</a><br/>

</li>

<li>
<b>Testes unitários e de integração utilizando xUnit e Moq</b>
</li>

<li> 
<b>Padrão de Camada Anticorrupção com a api ViaCep</b> <br><br>
<i>Referencias:</i>

<a href="https://docs.microsoft.com/pt-br/azure/architecture/patterns/anti-corruption-layer">
https://docs.microsoft.com/pt-br/azure/architecture/patterns/anti-corruption-layer
</a>

</li>

</ul>		



# SPA
 A camada de UI é uma SPA simples criada com Vue.js, até o ano passado eu estava trabalhando com angular.js, mas para o teste eu quis utilizar algum framework mais atual, não tive tempo de separar tudo em componente ou dar um clean code desejado, mas procurei utilizar o core de uma SPA

<ul>
	<li>Rotas</li>
	<li>Componentes</li>
	<li>Eventos de pai para filho</li>
	<li>Eventos de filho para pai</li>
	<li>Services</li>
	<li>Diretiva</li>
</ul>


<b>Tela 1:</b>

 ![GitHub Logo](/tela1.png) <br>
 
<b>Tela 2</b> 

 ![GitHub Logo](/tela2.png) <br>
 
 
 # Get Started
 
 <b>Api:</b> <br>
 O projeto da api foi feito com bibliotecas de classe net standard 2.0 e net core 3.1
 
 <b>Banco:</b> <br>
 O arquivo do banco como foi pedido está em DataBaseSchema.sql
 O arquivo de configuração da conexão está hardcode no arquivo do projeto da api Startup.cs, caso queira tem a opção de banco em memória, basta trocar as linhas: 

		 //services.AddDbContext<ClienteDataContext>(opt => opt.UseInMemoryDatabase("Crmall"));
		services.AddDbContext<ClienteDataContext>(opt => 	opt.UseMySql("server=127.0.0.1;database=Crmall;user=root;password=qwer1234#"));

 <b>Spa</b>
 
 Você pode fazer o deploy acredito eu em qualquer servidor (Apache, node, IIS) de sua preferência, já deixei também uma pasta deploy, com os arquivos minificados. 

<i>Observação</i>: 
- Recomendo o servidor local node, bem simples e utilizo ele aqui <a href="https://www.npmjs.com/package/http-server">http-server</a>, com um simples comando no terminal dentro do diretório, você está rodando o servidor:
  		http-server path
		
- Caso seu servidor esteja rodando em uma porta diferente da configurada na SPA, o arquivo com a URI Base é o main.js


	import VueResourse from 'vue-resource'; <br>
	Vue.use(VueResourse); <br>
	Vue.http.options.root = 'https://localhost:5003'; <-- Sua URL aqui <br>

		
		
	
	
 
 
 
 
 
<b>Qualquer duvida, entre em contato comigo: murilando@gmail.com</b>





  



  
   

