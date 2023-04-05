using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace MyApp.Models
{
    public class Abonnement
    {
        public long id { get; set; }

        public string description { get; set; }

        public long? idClient { get; set; }

        public List<Chaine> listeChaine {get; set; }

        public Remise remise {get; set;}

        public Abonnement() {}

        public Abonnement(long i, string d, long c) {
            id = i;
            description = d;
            idClient = c;
        }

        public float getPrixRemise() {
            return getPrixTotal() * (1 - remise.remise/100); 
        }

        public float getPrixTotal() {
            float s = 0;
            foreach(Chaine chaine in listeChaine) {
                s = s + chaine.prix;
            }
            return s;
        }

        public Abonnement getAbonnementById() {
            return getAbonnementById(id.ToString());
        }

        public Abonnement getAbonnementById(string id) {
            string connetionString = @"Server= localhost; Database= canalsat;Integrated Security=SSPI;";
            List<Abonnement> liste=new List<Abonnement>();
            SqlConnection connection = new SqlConnection(connetionString);
            connection.Open();       
            String sql = "SELECT * FROM Abonnements where id = "+id;
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            try{
                reader.Read();
                long idClient = 0;
                if (!reader.IsDBNull(2)) {
                    idClient = (long) reader.GetValue(2);
                }
                Abonnement ab=new Abonnement((long)reader.GetValue(0), (string)reader.GetValue(1),idClient);
                ab.fetchListeChaine();
                ab.fetchRemise();
                return ab;
            }finally{
                reader.Close();
                command.Dispose();
                connection.Close();
            }
        }

        public List<Abonnement> getAllAbonnements(){
            string connetionString = @"Server= localhost; Database= canalsat;Integrated Security=SSPI;";
            List<Abonnement> liste=new List<Abonnement>();
            SqlConnection connection = new SqlConnection(connetionString);
            connection.Open();       
            String sql = "SELECT * FROM Abonnements";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            try{
                while (reader.Read())
                {
                    Abonnement ab=new Abonnement((long)reader.GetValue(0), (string)reader.GetValue(1),(long)reader.GetValue(2));
                    ab.fetchListeChaine();
                    ab.fetchRemise();
                    liste.Add(ab);
                }
                return liste;
            }finally{
                reader.Close();
                command.Dispose();
                connection.Close();
            }
        }

        public void fetchRemise() {
            remise = getRemiseActuelle();
        }

        public Remise getRemiseActuelle() {
            string connetionString = @"Server= localhost; Database= canalsat;Integrated Security=SSPI;";
            List<Client> liste=new List<Client>();
            SqlConnection connection = new SqlConnection(connetionString);
            connection.Open();       
            String sql = "SELECT * FROM abonnements_remises where (dateDeb <= GETDATE() AND dateFin >= GETDATE()) AND idAbonnement = "+id;
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            try{
                if(reader.HasRows == true) {
                    reader.Read();
                    Remise r = new Remise((long) reader["id"], (float) reader["remise"], Convert.ToDateTime(reader["dateDeb"]), Convert.ToDateTime(reader["dateFin"]));
                    return r;
                }
                else return  new Remise(0, 0, DateTime.Now, DateTime.Now);
            }finally{
                reader.Close();
                command.Dispose();
                connection.Close();
            }
        }

        public void fetchListeChaine() {
            this.listeChaine = getListeChaine();
        }

         public List<Chaine> getListeChaine(){
            string connetionString = @"Server= localhost; Database= canalsat;Integrated Security=SSPI;";
            List<Chaine> liste=new List<Chaine>();
            SqlConnection connection = new SqlConnection(connetionString);
            connection.Open();       
            String sql = "select * from v_abonnements_chaine_signal where idAbonnement = "+id;
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            try{
                while (reader.Read())
                {
                    Chaine c=new Chaine((long)reader["idChaine"], (string)reader["descrichaine"], (float) reader["prix"], (float) reader["signal"]);
                    liste.Add(c);
                }
                return liste;
            }finally{
                reader.Close();
                command.Dispose();
                connection.Close();
            }
        }
    }
}
