#!/usr/bin/env python

"""
A simple echo server
"""

import socket, thread

def ConnectionChecker(sockete, *args):
    while 1:
        client, address = sockete.accept()
        print client, "connected"
        if not client in connectionID:
            connectionID.append(client)
            print client, "added to list"
        else:
            print client, "was already there, fuck off"
            client.close()

def ReceivedMsg():
    while 1:
        for i in connectionID:
            msg = i.recv(size)
            if msg == "/exit":
                connectionID.remove(i)
                print "Client removed from list"
            else:
                received.append(msg)

received = []
host = ''
port = 50001
backlog = 5
connectionID = []
size = 1024
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((host,port))
s.listen(backlog)
data = None
connectionAcceptThread = thread.start_new_thread(ConnectionChecker, (s, 1))
receivedHandler = thread.start_new_thread(ReceivedMsg, ())


print "Server ready"

while 1:
    if connectionID:
        if received:
            for x in received:
                for i in connectionID:
                    print "sending", x, "to", i
                    i.send(x)
                received.remove(x)
        