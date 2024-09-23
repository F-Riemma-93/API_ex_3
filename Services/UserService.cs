using API_ex_3.Models;

namespace API_ex_3.Services
{
    public class UserService
    {
        private List<User> _users = new List<User>();

        // Metodo per registrare un nuovo utente
        public string Register(User user)
        {
            // Aggiungi logica per controllare se l'email o l'username sono già esistenti
            if (_users.Any(u => u.Username == user.Username))
            {
                return "Username già esistente.";
            }

            _users.Add(user);
            return "OK";
        }

        // Metodo per autenticare un utente
        public User? Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user;  // Se null, il login è fallito
        }

        // Metodo per ottenere l'utente loggato
        public User? GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }
    }
}
