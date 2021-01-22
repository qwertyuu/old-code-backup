#!/usr/bin/env python

import socket, threading, Log

def main():

    def ConnectSocket(s, host, port):
        try :
            s.connect((host,port))

        except Exception as err:
            errLog.WriteToLog(err.message)

    def SetupSocket():
        host = 'localhost'
        port = 50001
        dataSize = 1024
        s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        ConnectSocket(s, host, port)
        return host, port, dataSize, s


    def ReceivedMsg(socket):
        while 1:
            msg = socket.recv(dataSize)
            print msg
            

    def closeThis():
        if s:
            s.send("/exit")
            s.close()
            print "Connection ended"

    errLog = Log.Logger("ClientErrorLog")


    print "Use /connect 'nickname' to connect"

    toSend = raw_input()
    commandLine = toSend.split(' ')

    while (len(commandLine) <= 1 and commandLine[0] != '/connect') or toSend == '/connect':
        print "You didn't connect, retry"
        toSend = raw_input()

    print commandLine

    host, port, dataSize, s = SetupSocket()

    receivedHandler = threading.Thread(target = ReceivedMsg, args = (s,))
    receivedHandler.start()

    s.send(toSend)

    while toSend != '/exit':
        try:
            toSend = raw_input()
            s.send(toSend)

        except KeyboardInterrupt:
            closeThis()
            break

    closeThis()

if __name__ == "__main__":
    main()
