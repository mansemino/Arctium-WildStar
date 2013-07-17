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

using Framework.Logging;
using WorldServer.Network;
using WorldServer.Packets.Handlers;
using WorldServer.World.Chat.Commands.Manager;

namespace WorldServer
{
    class WorldServer
    {
        static void Main(string[] args)
        {
            Log.Message(LogType.Init, "__________________WILDSTAR_________________");
            Log.Message(LogType.Init, "    __                                     ");
            Log.Message(LogType.Init, "    / |                     ,              ");
            Log.Message(LogType.Init, "---/__|---)__----__--_/_--------------_--_-");
            Log.Message(LogType.Init, "  /   |  /   ) /   ' /    /   /   /  / /  )");
            Log.Message(LogType.Init, "_/____|_/_____(___ _(_ __/___(___(__/_/__/_");
            Log.Message(LogType.Init, "_________________WorldServer________________");
            Log.Message();

            new Server("127.0.0.1", 24000);

            PacketManager.DefineMessageHandler();
            ChatCommandManager.DefineChatCommands();

            Log.Message(LogType.Normal, "WorldServer listening on {0} port {1}.", "127.0.0.1", 24000);
            Log.Message(LogType.Normal, "WorldServer successfully started!");
        }
    }
}
