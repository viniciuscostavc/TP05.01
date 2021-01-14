using System;
using System.Collections.Generic;
using System.Text;

namespace projMedicamento
{
    class Medicamento
    {
        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes;

        public Medicamento(int id, string nome, string laboratorio)
        {
            this.id = id;
            this.nome = nome;
            this.laboratorio = laboratorio;
            lotes = new Queue<Lote>();
        }

        public Medicamento()
            : this(0, "", "")
        { }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Laboratorio
        {
            get { return laboratorio; }
            set { laboratorio = value; }
        }

        public Queue<Lote> Lotes
        {
            get { return lotes; }
            set { lotes = value; }
        }

        public int qtdeDisponivel()
        {
            int total = 0;
            foreach (Lote l in lotes)
            {
                total += l.Qtde;
            }
            return total;
        }

        public void comprar(Lote lote)
        {
            lotes.Enqueue(lote);
        }

        public Boolean vender(int qtde)
        {

            if (qtde > qtdeDisponivel())
            {
                return false;
            }
            else
            {
                int qtdeFaltando = qtde;
                int qtdeLotes = lotes.Count;
                for (int i = 0; i <= qtdeLotes; i++)
                {
                    if (qtdeFaltando > lotes.Peek().Qtde)
                    {
                        qtdeFaltando -= lotes.Peek().Qtde;
                        lotes.Peek().Qtde = 0;
                        lotes.Dequeue();

                    }
                    else
                    {
                        lotes.Peek().Qtde -= qtdeFaltando;
                        qtdeFaltando = 0;
                        break;
                    }
                }
                return true;
            }

        }

        public string toString()
        {
            return id + " - " + nome + " - " + laboratorio + " - " + qtdeDisponivel();
        }

        public Boolean Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            else return false;
        }

    }
}
