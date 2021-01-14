using System;

namespace projMedicamento
{
    class Program
    {
        static void Main(string[] args)
        {

            int opcao = 1;
            int medId, id, qtde, dia, mes, ano;
            string medicamentoNome, medicamentoLaboratorio;

            Medicamentos medicamentos = new Medicamentos();

            Medicamento medicamento1 = new Medicamento(1, "medicamento1", "panvel");
            Medicamento medicamento2 = new Medicamento(2, "medicamento2", "butãtã");

            for (int i = 1; i < 6; i++)
            {
                Lote newlote = new Lote(i, i * 15, DateTime.Now);
                medicamento1.comprar(newlote);
            }

            medicamentos.adicionar(medicamento1);
            medicamentos.adicionar(medicamento2);


            Medicamento med;

            while (opcao != 0)
            {
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintético: informar dados1)");
                Console.WriteLine("3. Consultar medicamento (analítico: informar dados1 + lotes2)");
                Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
                Console.WriteLine("5. Vender medicamento (abater do lote mais antigo) ");
                Console.WriteLine("6. Listar medicamentos (informando dados sintéticos)");
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                if(opcao == 0){
                } 
                
                if (opcao == 1){
                        Console.Write("Insira o id do medicamento: ");
                        medId = int.Parse(Console.ReadLine());

                        Console.Write("Insira o nome do medicamento: ");
                        medicamentoNome = Console.ReadLine();

                        Console.Write("Insira o nome do laboratorio do medicamento: ");
                        medicamentoLaboratorio = Console.ReadLine();

                        med = new Medicamento(medId, medicamentoNome, medicamentoLaboratorio);
                        medicamentos.adicionar(med);                       
                }

                if(opcao == 2){
                        Console.Write("Insira o id do medicamento a ser pesquisado: ");
                        medId = int.Parse(Console.ReadLine());
                        med = new Medicamento(medId, "", "");

                        Console.WriteLine(medicamentos.pesquisar(med).toString());
                }
                        
                if(opcao == 3){
                    Console.Write("Insira o id do medicamento a ser pesquisado: ");
                    medId = int.Parse(Console.ReadLine());
                    med = new Medicamento(medId, "", "");

                    if (medicamentos.pesquisar(med).Id != 0)
                    {
                        Console.WriteLine(medicamentos.pesquisar(med).toString());

                        foreach (Lote l in medicamentos.pesquisar(med).Lotes)
                        {
                            Console.WriteLine(l.toString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não há medicamento com este ID!");
                    }
                }
                        
                if(opcao == 4){
                    Console.Write("Insira o id do medicamento: ");
                    medId = int.Parse(Console.ReadLine());
                    med = new Medicamento(medId, "", "");

                    if (medicamentos.pesquisar(med).Id == medId)
                    {
                        Console.Write("Insira o id do lote: ");
                        id = int.Parse(Console.ReadLine());

                        Console.Write("Insira a qtde no lote: ");
                        qtde = int.Parse(Console.ReadLine());

                        Console.Write("Insira o dia da data de vencimento do lote: ");
                        dia = int.Parse(Console.ReadLine());

                        Console.Write("Insira o mes da data de vencimento do lote: ");
                        mes = int.Parse(Console.ReadLine());

                        Console.Write("Insira o ano da data de vencimento do lote: ");
                        ano = int.Parse(Console.ReadLine());

                        Lote newlote = new Lote(id, qtde, new DateTime(ano, mes, dia));
                        medicamentos.ListaMedicamentos.Find(m => m.Id == medId).comprar(newlote);
                    }

                }

                if (opcao == 5){
                    Console.Write("Insira o nome do medicamento a ser vendido: ");
                    medicamentoNome = Console.ReadLine();
                    Console.Write("Insira a qtde a ser vendida: ");
                    qtde = int.Parse(Console.ReadLine());
                    Console.WriteLine(medicamentos.ListaMedicamentos.Find(md => md.Nome == medicamentoNome).vender(qtde) == true ? "Vendido" : "Não há quantidades suficientes disponível!");
                }

                if (opcao == 6){
                    foreach (Medicamento md in medicamentos.ListaMedicamentos)
                        {
                            Console.WriteLine(md.toString());
                        }                       
                }
                       
                

            }

        }
    }
}
