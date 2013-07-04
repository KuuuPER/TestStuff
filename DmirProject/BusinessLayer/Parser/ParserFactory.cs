using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Parser
{
    public static class ParserFactory
    {
        public static IParser GetUsersParser(ParserType type)
        {
            switch (type)
            {
                case ParserType.CSV:
                    return new UsersFileParser();
                    break;
                default:
                    throw new Exception("Unknown type!");
            }
        }
    }

    public enum ParserType
    {
        CSV,
    }
}
