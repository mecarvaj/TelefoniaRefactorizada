using System;
namespace TelefoniaRefactorizada.logicaNegocio
{

    public class Llamada
    {
        private int minutos;
        private int numDestino;
        private String hora;
        private DateTime fecha;
        private String tipo;

        public Llamada(ChipPrepago destino, int pMinutos)
        {
            this.minutos = pMinutos;
            this.numDestino = destino.getNum();
            setFecha();
            setHora();
        }

        public int getMinutos()
        {
            return this.minutos;
        }

        public int getNumDestino()
        {
            return this.numDestino;
        }

        public DateTime getFecha()
        {
            return this.fecha;
        }

        public String getHora()
        {
            return this.hora;
        }

        private void setFecha()
        {
            DateTime hoy = DateTime.Today;
            this.fecha = hoy;
        }

        private void setHora()
        {
            DateTime ahora = DateTime.Now;
            this.hora = ahora.ToString("HH:mm:ss tt");
        }
        override
        public String ToString()
        {
            String msg;
            msg = "Lista de llamadas:\n\n";
            msg += "Minutos: " + getMinutos() + "\n";
            msg += "Número Destino: " + getNumDestino() + "\n";
            msg += "Fecha: " + getFecha() + "\n";
            msg += "Hora: " + getHora() + "\n";

            return msg;
        }
    }
}
