#!/usr/bin/env python

import socket, threading, Log, Handler, thread, errno

host = '127.0.0.1'
port = 81
backlog = 5
size = 1024
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((host,port))
s.listen(backlog)
connHandler = Handler.ConnectionHandler()
msgHandler = Handler.MessageHandler(s)

errLog = Log.Logger("ServerErrorLog")
msgLog = Log.Logger("MessageLog")

def name(client):
    return connHandler.clients[client][0]

def ReceivedMsg():
    while 1:

        for i in connHandler.clients.copy():
            msg = None
            try:
                msg = i.recv(size)
                #print client[i][0], msg
                print name(i) + ': ' + msg
                msgLog.WriteToLog(msg)
                msgHandler.SendMessage(msg, connHandler.clients, i)

            except socket.error as err:
                if err.args[0] != errno.EWOULDBLOCK:
                    if err.args[0] == 10054:
                        print name(i), "disconnected."
                        connHandler.removeClient(i)
                    else:
                        print err.args[0] , err
                        errLog.WriteToLog(str(err))
                


receivedHandler = threading.Thread(target = ReceivedMsg, args = ())
receivedHandler.start()
print "Thread started"

print "Server ready"

while 1:
    connHandler.UpdateConnection(s)
    pass
