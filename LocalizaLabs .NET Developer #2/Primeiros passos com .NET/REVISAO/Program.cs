using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        if (indiceAluno < 5)
                        { 
                            Console.WriteLine("Informe o nome do aluno:");
                            var aluno = new Aluno();
                            string nomealuno = Console.ReadLine();

                            while (string.IsNullOrEmpty(nomealuno))
                            {
                                Console.WriteLine("Informe o nome do aluno:");
                                nomealuno = Console.ReadLine();
                            }
                            aluno.Nome = nomealuno;
                            
                            Console.WriteLine("Informe a nota do aluno:");

                            string notadig = Console.ReadLine();
                                
                            while (!decimal.TryParse(notadig, out decimal verdadeiro))
                            {
                                Console.WriteLine("Informe a nota do aluno:");
                                notadig = Console.ReadLine();
                            }

                            decimal nota = decimal.Parse(notadig); 
                       
                            aluno.Nota = nota;
                        
                            if (nota < 2)
                            {
                                aluno.Concieto = "E";
                            }
                            else if (nota < 4)
                            {
                                aluno.Concieto = "D";
                            }
                            else if (nota < 6)
                            {
                                aluno.Concieto = "C";
                            }
                            else if (nota < 8)
                            {
                                aluno.Concieto = "B";
                            }
                            else
                            {
                                aluno.Concieto = "A";
                            }
                   
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        } else
                          {
                           Console.WriteLine("Número máximo de alunos atingido!");
                          }
                        break;

                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota} - CONCEITO: {a.Concieto}");
                            }
                        }
                        break;
                    
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        { 
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;
                    default:
                        Console.WriteLine("ESCOLHA UMA OPCAO");
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
