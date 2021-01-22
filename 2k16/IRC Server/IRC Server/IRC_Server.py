# -*- coding: utf-8 -*-
import socket, time, os, datetime
host = ''
port = 6667
backlog = 100
s = socket.socket()
s.bind((host,port))
s.listen(backlog)
while 1:
    client, address = s.accept()

    while 1:
        data = client.recv(1024)
        print data
        if data[:4] == 'NICK':
            print client.send(':127.0.0.1 001 DaWoop :Welcome to the 2600net Internet Relay Chat Network DaWoop\r\n')
        if data[:4] == 'JOIN':
            client.send(':DaWoop!~DaWoop@modemcable054.215-130-66.mc.videotron.ca JOIN :#chat\r\n')


