using System;
using TelefoniaRefactorizada.logicaNegocio;
namespace TelefoniaRefactorizada.logicaApp
{
    public class AplTelefonia
    {
        public static void Main(string[] args)
        {
            ChipPrepago chipPrepago = new ChipPrepago(71932787);
            ChipPrepago chipPrepago2 = new ChipPrepago(71932788);

            chipPrepago.recargar(7000);
            chipPrepago2.recargar(7000);

            Console.WriteLine(chipPrepago2.llamar(chipPrepago, 10));
            Console.WriteLine(chipPrepago.llamar(chipPrepago2, 20));
            Console.WriteLine(chipPrepago.consultarLlamadasRealizadas());
            Console.WriteLine(chipPrepago2.consultarLlamadasRealizadas());
        }
    }
}
