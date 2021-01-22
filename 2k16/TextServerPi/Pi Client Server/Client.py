#!/usr/bin/env python

import socket, threading, Log



errLog = Log.Logger("ClientErrorLog")

def ConnectSocket(s, host, port):
    try :
        s.connect((host,port))

    except Exception as err:
        print err.message
        errLog.WriteToLog(err.message)

def SetupSocket():
    host = 'localhost'
    port = 50001
    dataSize = 1024
    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    ConnectSocket(s, host, port)
    return host, port, dataSize, s


def ReceivedMsg(socket, dataSize):
    while 1:
        msg = socket.recv(dataSize)
        print msg

def closeThis(s):
    if s:
        s.send("/exit")
        s.close()
        print "Connection ended"

def main():



    print "Use /connect 'nickname' to connect"

    toSend = raw_input()
    commandLine = toSend.split(' ')

    while len(commandLine) <= 1 and commandLine[0] != '/connect':
        print "You didn't connect, retry"
        toSend = raw_input()

    print commandLine

    host, port, dataSize, s = SetupSocket()

    receivedHandler = threading.Thread(target = ReceivedMsg, args = (s, dataSize))
    receivedHandler.start()

    s.send(toSend)

    while toSend != '/exit':
        try:
            toSend = raw_input()
            s.send(toSend)

        except KeyboardInterrupt:
            closeThis()
            break

    closeThis(s)

if __name__ == "__main__":
    main()
