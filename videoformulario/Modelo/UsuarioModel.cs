namespace videoformulario.Modelo
{
    public class UsuarioModel
    {
        public UsuarioModel(string Nombre, int Edad)
        {
            this.Nombre = Nombre;
            this.Edad = Edad;
        }

        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}
