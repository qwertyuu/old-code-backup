#!/usr/bin/env python
#! unicode UTF-8

"""
A simple echo client
"""

import socket, thread

def ReceivedMsg(sockete, *args):
    while 1:
        msg = sockete.recv(size)
        print msg

def closeThis():
    s.send("/exit")
    s.close()

print "Press enter to start connection"
raw_input()

host = '192.168.1.16'
port = 50001
size = 1024
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect((host,port))
receivedHandler = thread.start_new_thread(ReceivedMsg, (s, 1))
toOutput = ""

while toOutput != "/exit":
    try:
        toOutput = raw_input()
        s.send(toOutput)
    except KeyboardInterrupt:
        closeThis()
s.close()
print "Connection ended"

