/*
 * Copyright (C) 2012-2013 Arctium Emulation <http://arctium.org>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Text;
using DefaultConsole = System.Console;

namespace Framework.Logging
{
    public class Log
    {
        static public void Message()
        {
            SetLogger(LogType.Default, "");
        }

        static public void Message(LogType type, string text, params object[] args)
        {
            SetLogger(type, text, args);
        }

        static void SetLogger(LogType type, string text, params object[] args)
        {
            DefaultConsole.OutputEncoding = UTF8Encoding.UTF8;

            switch (type)
            {
                case LogType.Normal:
                    DefaultConsole.ForegroundColor = ConsoleColor.Green;
                    text = text.Insert(0, "System: ");
                    break;
                case LogType.Error:
                    DefaultConsole.ForegroundColor = ConsoleColor.Red;
                    text = text.Insert(0, "Error: ");
                    break;
                case LogType.Dump:
                    DefaultConsole.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogType.Init:
                    DefaultConsole.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case LogType.Debug:
                    text = text.Insert(0, "Debug: ");
                    DefaultConsole.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    DefaultConsole.ForegroundColor = ConsoleColor.White;
                    break;
            }


            if (type.Equals(LogType.Init) | type.Equals(LogType.Default))
                DefaultConsole.WriteLine(text, args);
            else if (type.Equals(LogType.Dump))
                DefaultConsole.WriteLine(text, args);
            else
                DefaultConsole.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] " + text, args);
        }
    }
}
