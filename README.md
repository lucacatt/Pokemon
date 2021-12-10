# POKÉMON SHOWDOWN

PROTOCOLLO DI COMUNICAZIONE

porta: 12345
Gestione porte separate;
Ascolto sulla porta 12345
Invio da porta "random"

APERTURA
fase1:
  a;NOME_MITTENTE;

fase2:
  se posso/voglio accettare la connessione ->
  y;NOME_DESTINATARIO;
  se non posso/voglio accettare la connessione ->
  n;
  
fase3:
  y;
  n;

Dopo aver stabilito la connesione si invia il pokemon evocato:
  -p;nomePokemon;vitaRimanente;numeroPokemonRimasti;

FASE DI ATTACCO
  Quando è il proprio turno:
  -at;nomeMossa;danno;
  //oppure\\
  -og;nomeOggetto; --> usare un oggetto;
  //oppure\\
  -p;nomePokemon;vitaRimanente; --> cambio pokemon

  Il secondo giocatore invia:
  -p;nomePokemon;vitaRimanente;numeroPokemonRimasti;

FASE DI CHIUSURA
  Esce il risultato della partita (vinto/perso)
  invia
  -c;
