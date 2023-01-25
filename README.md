# test-azure-functions

## Notes

requesthandler

delegatinghandler

le tout pour déléguer la récupération du token 

faire en sorte que la méthode de récupération du token ne dépende plus de mon httpclient et soit, par conséquent, réutilisable partout où je le souhaite

hook pre-request qui vérifie si le token en cache est valide ou pas
