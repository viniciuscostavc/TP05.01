using System;
using System.Collections.Generic;
using System.Text;

namespace projMedicamento
{
    class Medicamentos
    {
        private List<Medicamento> listaMedicamentos;

        public Medicamentos()
        {
            this.listaMedicamentos = new List<Medicamento>();
        }

        public List<Medicamento> ListaMedicamentos
        {
            get { return listaMedicamentos; }
            set { listaMedicamentos = value; }
        }

        public void adicionar(Medicamento medicamento)
        {
            this.listaMedicamentos.Add(medicamento);
        }

        public Boolean deletar(Medicamento medicamento)
        {

            if (listaMedicamentos.Find(m => m == medicamento).qtdeDisponivel() == 0)
            {
                listaMedicamentos.Remove(medicamento);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Medicamento pesquisar(Medicamento medicamento)
        {
            medicamento = listaMedicamentos.Find(m => m.Id == medicamento.Id);
            if (medicamento == null)
            {
                medicamento = new Medicamento(0, "", "");
            }
            return medicamento;
        }
    }
}
