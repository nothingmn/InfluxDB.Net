using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InfluxDB.REPL.Commands;
using InfluxDB.REPL.Contracts;

namespace InfluxDB.REPL.Entities
{
    public class CommandFactory
    {
        private static readonly Dictionary<string, Tuple<CommandDescriptorAttribute, Type>> Commands = new Dictionary<string, Tuple<CommandDescriptorAttribute, Type>>();

        static CommandFactory()
        {
            var commandTypes = from t in typeof(CommandFactory).GetTypeInfo().Assembly.GetTypes()
                               where
                                t.GetTypeInfo().IsClass
                                && t.GetTypeInfo().IsPublic
                                && t.GetTypeInfo().IsSubclassOf(typeof(BaseCommand))
                               select t;
            foreach (var t in commandTypes)
            {
                foreach (var a in t.GetTypeInfo().GetCustomAttributes(typeof(CommandDescriptorAttribute), false))
                {
                    var d = a as CommandDescriptorAttribute;
                    if (d != null)
                    {
                        Commands.Add(d.Name.Trim().ToLowerInvariant(), new Tuple<CommandDescriptorAttribute, Type>(d, t));
                    }
                }
            }
        }
        public static IList<string> GetHelp()
        {
            var lst = new List<string>();
            foreach (var c in Commands.OrderBy(pair => pair.Value.Item1.Description))
            {
                lst.Add($"\"{c.Value.Item1.Usage}\" - {c.Value.Item1.Description}");
            }
            return lst;
        }
        public ICommand GetCommand(string input)
        {
            input = input.Trim();
            var lowerInput = input.ToLowerInvariant();
            if (string.IsNullOrEmpty(lowerInput)) return null;

            ICommand command = null;
            var key = "";
            foreach (var cmd in Commands)
            {
                if (input.StartsWith(cmd.Key))
                {
                    key = cmd.Key;
                    command = cmd.Value.Item2.GetTypeInfo().Assembly.CreateInstance(cmd.Value.Item2.FullName) as ICommand;
                    if (command == null) return null;
                }
            }
            if (command == null) return null;

            var args = input.Substring(key.Length).Trim().Split(' ');
            var finalArgs = new List<string>();
            var first = false;
            foreach (var a in args)
            {
                if (!string.IsNullOrEmpty(a))
                {
                    var arg = a;
                    //if (!first && key.Contains(" "))
                    //{
                    //    arg = "/i:" + arg;
                    //    first = true;
                    //}
                    finalArgs.Add(arg);
                }
            }
            if (Parser.ParseArgumentsWithUsage(finalArgs.ToArray(), command))
            {
                return command;
            }
            return null;
        }
    }
}
