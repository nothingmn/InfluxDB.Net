using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InfluxDB.Core.Contracts;
using InfluxDB.REPL.Commands;
using InfluxDB.REPL.Contracts;
using InfluxDB.REPL.Entities;

namespace InfluxDB.REPL
{
    public class Program
    {
        #region static
        public static void Main(string[] args)
        {
            var p = new Program(new NoTranslatorTranslator());
            p.Run(args);
        }
        #endregion


        private readonly ITranslate _translate;



        public Program(ITranslate translate)
        {
            _translate = translate;
        }

        public void Run(string[] args)
        {
            RunAsync(args); //just let this run

        }

        private void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            _cancellationTokenSource?.Cancel();
        }

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken _rootCancellationToken;
        public async Task RunAsync(string[] args)
        {
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            Console.CancelKeyPress += Console_CancelKeyPress;
            _rootCancellationToken = _cancellationTokenSource.Token;

            var commandFactory = new CommandFactory();
            var quitCommand = new QuitCommand();



            //wait loop
            while (!_rootCancellationToken.IsCancellationRequested)
            {
                try
                {

                    var display = "";
                    if (!string.IsNullOrEmpty(_configuration?.Username))
                    {
                        display = $"({_configuration?.Username}) {_configuration?.Host}";
                    }
                    Console.Write(display + _translate.Translate(">"));

                    var input = Console.ReadLine();
                    var loweredInput = input.ToLowerInvariant().Trim();
                    if (string.IsNullOrEmpty(loweredInput)) continue;

                    var command = commandFactory.GetCommand(input);

                    if (command == null) command = new HelpCommand();
                    if (command.GetType() == typeof(QuitCommand))
                        (command as QuitCommand).CancellationTokenSource = _cancellationTokenSource;

                    await command.Execute(_configuration, _influxDb);

                    if (command is ConnectCommand)
                    {
                        var connect = (command as ConnectCommand);
                        _configuration = connect.UpdatedConfiguration;
                        _influxDb = connect.UpdatedClient;

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);                    
                }
            }

        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine(e.Exception.Flatten());
            e.SetObserved();
        }

        private IInfluxDb _influxDb = null;
        private IConfiguration _configuration = null;


    }
}
