Para criar o banco e a tabela utilize o código abaixo:

	create database pokemondb;
	use pokemondb;
	create table pokemons(
		Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	    Nome VARCHAR(50),
	    Tipo1 VARCHAR(50),
	    Tipo2 VARCHAR(50),
	    Altura DECIMAL,
	    Peso DECIMAL,
	    HP INT,
	    Ataque INT,
	    Defesa INT,
	    Velocidade INT,
	    imagem_url VARCHAR(500)
	);

OBS: Banco MySQL. Atualizar no código com as credenciais do seu banco.
