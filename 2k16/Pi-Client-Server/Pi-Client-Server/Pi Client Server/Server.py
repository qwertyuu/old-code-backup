#!/usr/bin/env python

import socket, threading, Log, Handler, thread

host = ''
port = 50001
backlog = 5
size = 1024
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((host,port))
s.listen(backlog)
connHandler = Handler.ConnectionHandler()
msgHandler = Handler.MessageHandler(s)

errLog = Log.Logger("ServerErrorLog")
msgLog = Log.Logger("MessageLog")


def ReceivedMsg():
    while 1:

        for i in connHandler.clients:
            msg = None
            try:
                msg = i.recv(size)
                print client[i][0], msg
                msgLog.WriteToLog(msg)
                msgHandler.SendMessage(msg, connHandler.clients, i)

            except socket.error as err:
                errLog.WriteToLog(err.message)

            finally :
                lock.release()

receivedHandler = threading.Thread(target = ReceivedMsg, args = ())
receivedHandler.start()

print "Server ready"

while 1:
    connHandler.UpdateConnection(s)
    pass