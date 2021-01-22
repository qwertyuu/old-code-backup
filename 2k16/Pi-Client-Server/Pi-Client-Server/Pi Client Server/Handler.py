import os, sys, thread, socket

class MessageHandler(object):
    def __init__(self, socket):
        self.s = socket

    def SendMessage(self, message, clients, author):
        for i in clients:
            if i != author:
                i.send(message)


class CommandHandler(object):
    def __init__(self, part):
        self.commandList = {'/connect' : 1}
        self.s = socket
        self.parent = part

    def ParseMessage(self, msg):
        return msg.split(' ')

    def IsACommand(self, msg):
        return msg[0] == '/'

    def HandleCommand(self, command, sender):
        command = self.ParseMessage(command)
        if command[0] == '/connect':
            self.parent.ConnectClient(command[1], sender)

    def GetArgsForCommand(self, command):
        return self.commandList[command][1]

    
class ConnectionHandler(object):
    def __init__(self):
        self.clients = {}
        self.dataSize = (1024)
        self.commandH = CommandHandler(self)
        self.toAddClients = {}

    def UpdateConnection(self, s):
        client, address = s.accept()
        client.setblocking(0)
        self.toAddClients[client] = address

        try:
            msg = client.recv(self.dataSize)
            if self.commandH.IsACommand(msg):
                self.commandH.HandleCommand(msg, client)

        except socket.error as err:
            sys.stderr.write(err.message)
            pass

    def ConnectClient(self, nickname, sender):
        if not sender in self.clients:
            self.clients[sender] = (nickname, self.toAddClients[sender])
            print nickname, 'just connected'
        else:
            sender.close()
            del self.toAddClients[sender]