namespace back.Service
{
    public interface IEncriptacionService
    {
        public string encriptar(string frase, int clave);
        public string deseencriptar(string frase);

    }
}
