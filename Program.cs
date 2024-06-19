
using System.ComponentModel;
using System.Security.AccessControl;

namespace Exemplo
{
    public class Exemplo
    {

        //Curiosidade: "string[] args" significa que seu programa recebe alguma informação (args = argumentos)
        // e salva ele em um array de strings 
        //Na inicialização, igual aqueles programas de console, que vc escrevia algo tipo:
        // Program.cs 123.123.123.123 F

        // Program.cs       é você chamando o programa, isso varia de console (no VScode eu uso "dotnet run")
        // 123.123.123-12   um argumento, nesse caso o IP que vai atacar
        // F                mais um argumento, como por exemplo "força total" ou algo do tipo
        public static void Main(string[] args)
        {
            //Vou fazer 2 programas em 1, um vai ser um de hacking (não funcional, apenas vai mostrar uns textos)
            // e outro vai ser algo como um jogo, tambem não funcional, apenas para exemplo.


            //Leia a partir da linha 89, depois que terminar volte aqui para ver os resultados


            //Aqui eu crio uma instancia da classe Hack, como eu nomeei ela hack, usaremos esse nome.
            Hack hack = new();

            //Aqui eu chamo a função Attack, e entrego ela os argumentos do começo
            // note que eu fiz uma variavel I para guardar o boolean que a função vai devolver
            bool I = hack.Attack(args);

            if (I == true)
            {
                Console.WriteLine("Recebi um boolean true");
            }
            else
            {
                Console.WriteLine("recebi um boolean false");
            }

            //Aqui eu crio um player, só entreguei 1 numero, então a vida e vida maxima são iguais
            //linha 163
            Player player1 = new Player(10);

            //Uso a função AddLife para somar 5 de vida do player
            // linha: 177
            player1.AddLife(5);

            //Mostro a vida do player1, eu acesso ela usando: nomePlayer.nomeVariavel
            Console.WriteLine("\nA vida do player é: " + player1.Life);

            Console.WriteLine("Função Check Life chamada");
            //Linha: 184
            player1.CheckLife();

            //aqui a vida do player sera reduzida a 10, por que ultrapassou o limite
            Console.WriteLine("A vida do player é: " + player1.Life);

            //O codigo a seguir irá dar um erro, por que a variavel Max_Life é privada, diferente da Life.
            // Linha: 153       private int Max_life;
            //Console.WriteLine("A vida maxima do player é: player1.Max_Life");

            //Aqui eu crio um switch, um jeito compacto e eficiente de escrever
            // muitos "if else", você escreve o valor analisado entre parenteses () e depois os valores possiveis

            switch (player1.Life)
            {
                case 1:
                    Console.WriteLine("A vida do jogador é 1");
                    break;
                case 2:
                    Console.WriteLine("A vida do jogador é 2");
                    break;
                //aqui eu coloco um default, que funciona similar ao "else", caso nada ative, ele irá.
                default:
                    Console.WriteLine("\nA vida do jogador não é 1 ou 2");
                    break;
            }

            //aqui eu crio mais um player, e abrevio a criação
            //de: "new Player(Var)" para "new(Var)"
            Player player2 = new(100);

            Console.WriteLine($"\nPlayer 1 Life: {player1.Life}\nPlayer 2 Life {player2.Life}");
            //apesar dos dois terem o mesmo código, eles tem valores diferentes.
        }
    }

    public class Hack
    {
        /*
        modificador de acesso + retorno + nome + (argumentos)

        mod. acesso = determina de onde é possivel acessar ele
        public -> pode ser acessado de qualquer lugar
        private -> só essa classe e oque está dentro pode acessar

        retorno = se quando um código acessar ele, ele vai devolver algo
        void -> não devolve nada
        string/int/double/etc -> permite você devolver algo do tipo escrito
        */
        public bool Attack(string[] Argumentos)
        {
            Console.WriteLine("Atacando o IP " + Argumentos[0]);
            /*Console.WriteLine -> escreve oque está dentro dos parenteses e aspas
            usando concatenação (+) é possivel adicionar uma string

            tambem seria possivel usando $ e {}, coloque $ antes das aspas e as variaveis
            dentro das {}
            */
            Console.WriteLine($"Atacando o IP {Argumentos[0]}");

            //colocar \n irá passar o texto pra proxima linha
            Console.WriteLine("Quer continuar o ataque? \n[Y] Sim \n[N] Não");

            ConsoleKeyInfo Tecla = Console.ReadKey(true);
            //lê a tecla pressionada no console, caso coloque "true" dentro dos parenteses
            //a tecla pressionada sera escondida, caso deixe vazio ou coloque "false" ela aparece
            //ConsoleKeyInfo é um tipo de dado, especializado em guardar Input do console.

            while (true)
            {
                if (Tecla.Key == ConsoleKey.Y)
                {
                    //devolve true, porque teoricamente o ataque foi um sucesso
                    return true;
                }
                else if (Tecla.Key == ConsoleKey.N)
                {
                    //devolve false, porque o ataque foi cancelado
                    return false;
                }
                else
                {
                    /* como as aspas ("") são usadas para começar e terminar o texto,
                     caso queira usa-las use uma \ para dizer ao programa que as aspas
                     fazem parte do texto (\"), mesma coisa caso queira escrever a propria 
                     barra (\\)
                    */
                    Console.WriteLine("Escreva apenas \"Y\" ou \"N\"!");
                }
            }
        }
    }

    //mais uma classe, agora um player com vida e limite de vida
    public class Player
    {
        //aqui uma variavel é publica e outra privada, mais pra frente você ira ver as implicações 
        public int Life;
        private int Max_life;

        //aqui eu crio um construtor, entre parenteses os argumentos dele
        //as caracteristicas dele ficam na identação
        public Player(int life, int max_life)
        {
            Life = life;
            Max_life = max_life;

        }
        // é possivel criar varios construtores, contanto que seus argumentos sejam diferentes
        // aqui ele só recebe vida maxima
        public Player(int max_life)
        {
            Life = max_life;
            Max_life = max_life;
        }

        // agora caso seja enviado uma string ao construtor, o numero a seguir sera elevado a 2
        public Player(string A, int max_life)
        {
            //Math.Sqrt leva o valor dentro dos parenteses ao quadrado
            //Sqrt retorna um double, então usando (int) eu converto em um inteiro
            Max_life = (int)Math.Sqrt(max_life);
        }

        public void AddLife(int life)
        {
            // usar (+=) é um jeito rapido de fazer:  Var1 = Var1 + Var2;
            Life += life;
        }

        //agora eu criei uma função, ela irá checar se a vida do player ultrapassa a vida maxima
        public bool CheckLife()
        {
            // se a vida for maior ou igual a vida maxima, diminui a vida
            if (Life >= Max_life)
            {
                Life = Max_life;
                return true;
            }

            /* você provavelmente já sabe os operados, mas vou deixar escrito os mais uteis
            ||              OU
            &&              E
            ==              igual
            !=              diferente
            >, >=, <=, <    maior que, maior ou igual, menor ou igual, menor que.
            */
            //fiz mais um IF apenas pra demonstrar um jeito diferente de verificar.
            if (Life > Max_life || Life == Max_life)
            {
                Life = Max_life;
                return true;
            }
            else
            {
                //caso a vida seja menor que o limite, então vai devolver false, indicando
                //que não estava acima do limite, frase bem redundante kkkkkkk.
                return false;
            }
        }
    }
}