using System;
namespace TelefoniaRefactorizada.logicaNegocio
{
    public class Mensaje
    {
        String mensaje;
        int numDestino;
        String hora;
        DateTime fecha;
        String tipo;

        public Mensaje(ChipPrepago destino, String pMensaje)
        {
            this.mensaje = pMensaje;
            this.numDestino = destino.getNum();
            setFecha();
            setHora();
        }

        public String getMensaje()
        {
            return this.mensaje;
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
            msg = "\nLista de mensajes:\n\n";
            msg += "Mensaje: " + getMensaje() + "\n";
            msg += "Número Destino: " + getNumDestino() + "\n";
            msg += "Fecha: " + getFecha() + "\n";
            msg += "Hora: " + getHora() + "\n";

            return msg;
        }
    }
}
