namespace back.Service
{
    public class EncriptacionService : IEncriptacionService
    {
        public string encriptar(string frase, int clave)
        {
            string alfabeto = "abcdefghijklmnopqrstuvwxyz";
            string fraseEncriptada = "";

            foreach (char letra in frase)
            {
                if (char.IsLetter(letra))
                {
                    char letraEncriptada = char.ToLower(letra);
                    int indice = (alfabeto.IndexOf(letraEncriptada) + clave) % alfabeto.Length;
                    fraseEncriptada += char.IsUpper(letra) ? char.ToUpper(alfabeto[indice]) : alfabeto[indice];
                }
                else
                {
                    // Si no es una letra, mantener el carácter original
                    fraseEncriptada += letra;
                }
            }

            return fraseEncriptada;
        }        
    }
}