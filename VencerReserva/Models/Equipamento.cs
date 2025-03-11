using SQLite;

namespace VencerReserva.Models
{
    public class Equipamento
    {
        string _nome;  

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome 
        {
            get => _nome; 
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, Preencha o Nome");
                }

                _nome = value;
            }
        }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Sala { get; set; }
        public int Quantidade { get; set; }
        public string Responsavel { get; set; }
    }
}
