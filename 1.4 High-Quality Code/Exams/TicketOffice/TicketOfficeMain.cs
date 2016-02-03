namespace TicketOffice
{
    using System;

    using TicketOffice.Data;

    class Salimur
    {
        static void Main()
        {
            TicketRepository ticketRepository = new TicketRepository();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                line = line.Trim();
                string commandResult = ticketRepository.CommandExecutor(line);
                if (commandResult != null)
                {
                    Console.WriteLine(commandResult);
                }
            }
        }
    }
}