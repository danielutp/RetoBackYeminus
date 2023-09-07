namespace back.Service
{
    public class FibonacciService : IFibonacciService
    {       
        public bool presente(int numero)
        {
            int suma = 0;
            int variable1 = 0;
            int variable2 = 1;

            if (numero == 0 || numero == 1)
            {
                return true;
            }
            for (int i = 0; i <= numero; i++)
            {
                suma = variable1 + variable2;
                variable1 = variable2;
                variable2 = suma;

                if (numero == suma)
                {
                    return true;
                }
            }
            return false;
        }
    }
}